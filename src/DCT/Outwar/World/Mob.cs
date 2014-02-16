using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DCT.Parsing;
using DCT.Pathfinding;
using DCT.Threading;
using DCT.Settings;
using DCT.UI;

namespace DCT.Outwar.World
{
    internal class Mob : Occupier
    {
        private const int MAX_ITEM_LEN = 80;

        private bool mAttacked;
        private bool mInitialized;
        internal bool IsTrainer { get; private set; }
        internal bool IsTalkable { get; private set; }
        internal bool IsSpawn { get; private set; }
        internal bool Attacking { get; private set; }
        internal AttackPanel AttackPanel { get; private set; }
        private bool mQuit;

        public string[] RemoveDuplicates(string[] myList)
        {
            System.Collections.ArrayList newList = new System.Collections.ArrayList();

            foreach (string str in myList)
                if (!newList.Contains(str))
                    newList.Add(str);
            return (string[])newList.ToArray(typeof(string));
        }



        private bool FilterOK
        {
            get
            {
                if (!CoreUI.Instance.Settings.FilterMobs)
                {
                    return true;
                }

                // a mob should get through:
                // If there are only normal filters, then ONLY if it matches
                // If there are only ignore filters, then ONLY if it doesn't match
                // If there are normal and ignore filters, then ignore the ignore filters and let it through only if it matches

                bool ignorefilter = false;
                bool passedignore = true;
                bool normalfilter = false;

                foreach (string str in CoreUI.Instance.Settings.MobFilters)
                {
                    if (str.StartsWith("!"))
                    {
                        ignorefilter = true;
                        if (mName.ToLower().Contains(str.Substring(1)))
                            passedignore = false;
                    }
                    else
                    {
                        normalfilter = true;
                        if (mName.ToLower().Contains(str))
                            return true;    // matches, so return true unconditionally
                    }
                }

                if (ignorefilter && normalfilter)
                {
                    return false;
                }
                if (ignorefilter)
                {
                    return passedignore;
                }
                if (normalfilter)
                {
                    // this should never happen
                }

                return false;
            }
        }

        private int mExpGained;
        private long mRage, mLevel;

        internal long Level
        {
            get { return mLevel; }
            set { mLevel = Level; }
        }

        internal long Rage
        {
            get { return mRage; }
            set { mRage = Rage; }
        }
        private bool mSkipLoad;
        private string mAttackUrl;

          internal Mob(string name, string url, string attackurl, bool isQuest, bool isTrainer, bool isSpawn, Room room) : base(name, url, room)
        {
            mAttackUrl = attackurl;
            IsTalkable = isQuest;
            IsTrainer = isTrainer;
            IsSpawn = isSpawn;

            // add it to collector if we don't already have it in the database, excluding spawns
            if (Pathfinding.Pathfinder.Mobs.Find(delegate(Pathfinding.MappedMob m) { return m.Name.Equals(name) && (m.Id == mId || mId > 1000000); }) == null)
            {

                Initialize();

                // it's new
                Pathfinding.MobCollector.Add(this);
            }
        }

        internal void Initialize()
        {
            if (mInitialized)
            {
                return;
            }

            CoreUI.Instance.LogPanel.Log("Loading '" + mName + "'");

            mLoadSrc = mRoom.Mover.Socket.Get(mURL);

            if (mQuit)
            {
                return;
            }

            // Parse level and rage
            Parser mm = new Parser(mLoadSrc);
            if (!long.TryParse(mm.Parse("(Level ", ")</b></font>"), out mLevel)
                || !long.TryParse(mm.Parse("Attack!</a> (<b>", " rage</b>)"), out mRage))
            {

                mQuit = true;
                return;
           }

            mInitialized = true;
        }


        private bool TestRage(bool useRageLimit)
        {
            if (!IsInRoom)
            {
                return false;
            }

            if (mRoom.Mover.Account.Rage < 0)
            {
                // Rage level is -1 because it's not yet initialized, so we can't tell.
                return true;
            }

            MappedMob m = Pathfinder.Mobs.Find(PreeliminationPredicate);
            if (m != null)
            {
                if (m.Level == 0 && m.Rage == 0)
                {
                    // this mob probably isn't mapped fully
                    return true;
                }

                mSkipLoad = true;

                if ((useRageLimit && CoreUI.Instance.Settings.RageLimit != 0 && m.Rage > CoreUI.Instance.Settings.RageLimit)
                    || m.Rage > mRoom.Mover.Account.Rage)
                {
                    return false;
                }

                if (mRoom.Mover.Account.Rage > -1 && mRoom.Mover.Account.Rage < Math.Max(1, CoreUI.Instance.Settings.StopBelowRage))
                {
                    // TODO this all needs cleaning
                    // go to next account
                    CoreUI.Instance.LogPanel.Log(string.Format("Stopping attacks on {0}, reached rage limit", mRoom.Mover.Account.Name));
                    mQuit = true;
                    Globals.AttackOn = false;
                    return false;
                }
            }
            return true;
        }

        private bool TestLevel()
        {
            if (!IsInRoom)
            {
                return false;
            }

            MappedMob m = Pathfinder.Mobs.Find(PreeliminationPredicate);
            if (m != null)
            {
                if (m.Level == 0 && m.Rage == 0)
                {
                    // this mob probably isn't mapped fully
                    return true;
                }

                mSkipLoad = true;

                if ((m.Level > CoreUI.Instance.Settings.LvlLimit && CoreUI.Instance.Settings.LvlLimit != 0)
                       || m.Level < CoreUI.Instance.Settings.LvlLimitMin)
                {
                    return false;
                }
            }
            return true;
        }


        private bool PreeliminationPredicate(MappedMob m)
        {
            return m.Name.Equals(mName);
        }

        internal void Train()
        {
            if (mRoom.Mover.Account.NeedsLevel)
            {
                    CoreUI.Instance.LogPanel.Log("Leveling up " + mRoom.Mover.Account.Name + " automatically " + "...");
                    Initialize();
               // mRoom.Mover.Socket.Get("mob_train.php?id=" + Parser.Parse(mLoadSrc, "mob_train.php?id=", "\""));
                    mRoom.Mover.Account.Socket.Get("levelup.php");
            }
        }

        private void GeneralTestAttack()
        {
            // for mob attacking too
            if (mRage > mRoom.Mover.Account.Rage)
            {
                mQuit = true;
                CoreUI.Instance.LogPanel.Log("You don't have enough rage to attack " + mName + " (" + mRage + " > "
                                    + mRoom.Mover.Account.Rage + ")");
            }
            else if (mRoom.Mover.Account.Rage > -1 && mRoom.Mover.Account.Rage < Math.Max(1, CoreUI.Instance.Settings.StopBelowRage))
            {
                // go to next account
                CoreUI.Instance.LogPanel.Log(string.Format("Stopping attacks on {0}, reached rage limit", mRoom.Mover.Account.Name));
                mQuit = true;
                Globals.AttackOn = false;

            }
                /*
            else if (mRoom.Mover.Account.Rage < CoreUI.Instance.Settings.StopBelowRage)
            {
                mQuit = true;
                CoreUI.Instance.LogPanel.Log("Not enough rage to attack " + mName + " with " + mRage
                                    + " and stay above rage quota");
            }
            else if (mRoom.Mover.Account.Rage < 1)
            {
                mQuit = true;
                CoreUI.Instance.LogPanel.Log("Can't attack " + mName + ", you're out of rage");
                Globals.AttackOn = false; // TODO: stop it
            }
                 * */
        }

        private void TestAttack()
        {
            // for not mob attacking
            if (mLevel > CoreUI.Instance.Settings.LvlLimit && CoreUI.Instance.Settings.LvlLimit != 0)
            {
                mQuit = true;
                CoreUI.Instance.LogPanel.Log(mName + "'s level is too high (" + mLevel + " > " + CoreUI.Instance.Settings.LvlLimit + ")");
            }
            else if (mLevel < CoreUI.Instance.Settings.LvlLimitMin)
            {
                mQuit = true;
                CoreUI.Instance.LogPanel.Log(mName + "'s level is too low (" + mLevel + " < " + CoreUI.Instance.Settings.LvlLimitMin
                                    + ")");
            }
            else if (mRage > CoreUI.Instance.Settings.RageLimit && CoreUI.Instance.Settings.RageLimit != 0 && !(IsSpawn && CoreUI.Instance.Settings.IgnoreSpawnRage))
            {
                mQuit = true;
                CoreUI.Instance.LogPanel.Log(mName + " requires too much rage (" + mRage + "), over the rage limit");
            }
        }


        internal bool Attack()
        {
            return Attack(true);
        }

        /// <summary>
        /// Attempts to start attack thread
        /// </summary>
        /// <param name="test">True if we should test mob stats for preelimination</param>
        /// <returns>True if thread started; False otherwise</returns>
        internal bool Attack(bool test)
        {
            if (mAttacked || (!FilterOK && test) || !IsInRoom
                || (!Globals.AttackOn || !Globals.AttackMode))
            {
                mQuit = true;
                return false;
            }
            if (CoreUI.Instance.Settings.AutoTrain && mRoom.Mover.Account.Rage <= 100 && mRoom.Mover.Account.NeedsLevel)
            {
                Train();
            }
            if (IsTalkable && (CoreUI.Instance.Settings.AutoQuest || CoreUI.Instance.Settings.AlertQuests))
            {
//talk()
            }

            if (
                (test && (!TestLevel() || !FilterOK || !TestRage(true)))
                || (!test && !TestRage(false))
                )
            {
                if (mRoom.Mover.Account.Rage <= CoreUI.Instance.Settings.StopBelowRage)
                {
                    if (CoreUI.Instance.Settings.UseFury == true)
                    {
                        string chkFury = mRoom.Mover.Account.Socket.Get("/backpack.php?potion=1");
                        if (chkFury.IndexOf("/images/rfury.jpg") > 0)
                        {
                            Parser fury = new Parser(chkFury);
                            string FuryID = fury.Parse("/images/rfury.jpg", "kill();makemenu");
                            Parser ID = new Parser(FuryID);
                            FuryID = ID.Parse("itempopup(event,'", "')");
                            chkFury = mRoom.Mover.Account.Socket.Get("/home.php?itemaction=" + FuryID);
                            CoreUI.Instance.Trainpanel.IncreaseFuryCounter();
                                CoreUI.Instance.LogPanel.Log(string.Format("Fury casted on {0}", mRoom.Name));
                        }
                        else
                        {
                            // go to next account
                            CoreUI.Instance.LogPanel.Log(string.Format("Fury not cast on {0}, none found.", mRoom.Name));
                            mQuit = true;
                            mRoom.Mover.Account.RefreshState();
                            return false;
                        }
                    }
                    else
                    {
                        CoreUI.Instance.LogPanel.Log(mName + " does not meet specifications.");
                        mQuit = true;
                        mRoom.Mover.Account.RefreshState();
                        return false;
                    }
                }
            }

            if (mSkipLoad)
            {
                if (CoreUI.Instance.Settings.MultiThread == true)
                {
                    MethodInvoker d = SendAttack;
                    d.BeginInvoke(AttackCallback, d);
                }
                    else
                {
                    SendAttack();
                }
                return true;
            }

            Initialize();
            if (mQuit)
            {
                return false;
            }

            GeneralTestAttack();
            if (test)
            {
                TestAttack();
            }

            if (mQuit)
            {
                return false;
            }

            //Launch attack thread
            if (CoreUI.Instance.Settings.MultiThread == true)
            {
                MethodInvoker d = SendAttack;
                d.BeginInvoke(AttackCallback, d);
            }
            else
            {
                SendAttack();
            }

            return true;
        }

        private void SendAttack()
        {
            if (mQuit || !IsInRoom || !(Globals.AttackOn || Globals.AttackMode))
            {
                return;
            }

            Attacking = true;

            CoreUI.Instance.LogPanel.Log("Attacking " + mName + " (" + mId + ") in rm. " + mRoom.Id);

            /*if (!mSkipLoad)
            {
                mAttackUrl = "somethingelse.php?attackid=" + new Parser(mLoadSrc).Parse("?attackid=", "&r=world") + "&r=world";
            }*/
            var tempURL = mRoom.Mover.Socket.Get(mAttackUrl);
            EvaluateOutcome(tempURL);

            //reloads stats
            //Room.Mover.Socket.Get("security_prompt.php");

            Attacking = false;
        }

        private void AttackCallback(IAsyncResult ar)
        {
            MethodInvoker d = (MethodInvoker) ar.AsyncState;
            d.EndInvoke(ar);
        }

        //private string[] CreateRequestFromForm()
        //{
        //    Parser mm;
        //    try
        //    {
        //        mm =
        //            new Parser(
        //                mLoadSrc.Substring(mLoadSrc.IndexOf("<form"),
        //                                   mLoadSrc.IndexOf("</form>") - mLoadSrc.IndexOf("<form")));
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        mFinished = true;
        //        return null;
        //    }
        //    string[] ret = { mm.Parse("action=\"", "\""), "" };

        //    Parser tm;
        //    bool amp = false;

        //    string[] tokens = mm.MultiParse("<input type=\"", ">");

        //    for (int i = 0; i < tokens.Length - 1; i++)
        //    {
        //        string token = tokens[i];

        //        if (token.Contains("type=\"image\""))
        //            continue;

        //        tm = new Parser(token);

        //        if (amp)
        //            ret[1] += "&";
        //        else
        //            amp = true;

        //        ret[1] += tm.Parse("name=\"", "\"") + "=" + tm.Parse("value=\"", "\"");
        //    }

        //    return mRoom.Mover.Account.Ret == mRoom.Mover.Account.Name ? ret : null;
        //}

        private void EvaluateOutcome(string src)
        {
            // RESEND REQUEST
            if (src == "ERROR: Timeout"
                || src.Contains("operation has timed out"))
            {
                CoreUI.Instance.LogPanel.Log("Attack on " + mName + " failed - timed out by server");
                SendAttack();
                return;
            }
            if (src.Contains("an existing connection was forcibly closed by the remote host"))
            {
                CoreUI.Instance.LogPanel.Log("Attack on " + mName + " failed - connection forcibly closed by server");
                SendAttack();
                return;
            }
            if (src.Contains("underlying connection was closed"))
            {
                CoreUI.Instance.LogPanel.Log("Attack on " + mName + " failed - underlying connection closed by server");
                SendAttack();
                return;
            }

            // ALL GOOD

            // bookkeeping
            mAttacked = true;
            mRoom.Mover.MobsAttacked++;

            // spawn handling and logging
            if (src.Contains("steps out of the shadows"))
            {
                CoreUI.Instance.SpawnsPanel.Log(string.Format("{0} spawned a mob in room {1}", mRoom.Mover.Account.Name, mRoom.Id));

                if (CoreUI.Instance.Settings.AttackSpawns)
                {
                    // attack the spawn mob
                    CoreUI.Instance.SpawnsPanel.Log(string.Format("{0} attacking spawns in room {1}", mRoom.Mover.Account.Name, mRoom.Id));
                    if (mRoom.Load() != 0)
                    {
                        CoreUI.Instance.SpawnsPanel.Log(string.Format("{0} room {1} reload failed", mRoom.Mover.Account.Name, mRoom.Id));
                    }
                    else
                    {
                        mRoom.AttackSpawns();
                    }
                }
            }
            if (IsSpawn)
            {
                CoreUI.Instance.SpawnsPanel.Log(string.Format("{0} attacked {1}", mRoom.Mover.Account.Name, Name));
                CoreUI.Instance.SpawnsPanel.Attacked(mRoom.Id);
            }

            // other outcome handling
            if (src.Contains("has weakened"))
            {
                CoreUI.Instance.LogPanel.LogAttack(string.Format("{0} lost to {1}", mRoom.Mover.Account.Name, mName));
            }
            else if (src.Contains("battle_result"))
            {
                // quest kill count
                String killProgress = string.Empty;
                Regex killregex = new Regex(@"\d+/\d+ killed");
                Match m = killregex.Match(src);
                if (m.Groups.Count > 0)
                {
                    killProgress = m.Groups[0].Value;

                }

                // Build string to add to attack log.
                String attackLogString = "";
                if (src.Contains("has gained "))
                {
                    // xp gain
                    if (int.TryParse(Parser.Parse(src, "has gained ", " experience!"), out mExpGained))
                    {
                        Globals.ExpGained += mExpGained;
                        mRoom.Mover.ExpGained += mExpGained;
                        attackLogString = string.Format("{0} beat {1}, gained {2} exp", mRoom.Mover.Account.Name, mName, mExpGained);
                    }
                }
                else
                {
                    attackLogString = string.Format("{0} beat {1}", mRoom.Mover.Account.Name, mName);
                }
                attackLogString += killProgress;

                if (killProgress == "")
                {
                CoreUI.Instance.LogPanel.LogAttack(attackLogString);
                }
                else
                {
                    //Check to see if required kills has been met
                    //If yes then stop attacking
                if (CoreUI.Instance.Settings.StopQuestKills == true)
                {
                    string[] Kills = killProgress.Split('/');
                    char[] MyChar = { ' ', 'k', 'i', 'l', 'l', 'e', 'd'};
                    Kills[1] = Kills[1].TrimEnd(MyChar);
                    int KillsDone = Int32.Parse(Kills[0]);
                    int KillsNeeded = Int32.Parse(Kills[1]);

                    if (KillsDone == KillsNeeded)
                    {
                        CoreUI.Instance.ToggleAttack(false);
                        CoreUI.Instance.LogPanel.Log("Reached required kills");
                    }
                }
                CoreUI.Instance.LogPanel.LogAttack(attackLogString);
                }



                // item dropped
                if (src.Contains("WIN: Found"))
                {
                    //if (src.Contains("has no backpack space"))
                    //{
                    //    CoreUI.Instance.LogPanel.Log(string.Format("{0} found an item, but your backpack is full", mRoom.Mover.Account.Name));
                    //    // TODO what if we get one item, then the rest is full?
                    //}
                    //else
                    //{
                    string[] fs = Parser.MultiParse(src, "Found ", "</b>");
                        if (fs.Length > 1)
                        {
                            fs = RemoveDuplicates(fs);
                            bool reported = false;  // flag to keep track of whether this bug has been reported
                            for (int i = 1; i < fs.Length; i++)
                            {
                                string f = fs[i];
                                if (f.Length < MAX_ITEM_LEN)
                                {
                                    CoreUI.Instance.LogPanel.LogAttack(string.Format("{0} found {1}", mRoom.Mover.Account.Name, f));
                                    if (f.Contains(","))
                                    {
                                        string[] Items = f.Split(',');
                                        CoreUI.Instance.TalkPanel.AddItem(Items[0].Trim(), mName);
                                        CoreUI.Instance.TalkPanel.AddItem(Items[1].Trim(), mName);
                                    }
                                    else
                                    {
                                        CoreUI.Instance.TalkPanel.AddItem(f, mName);
                                    }
                                    if (IsSpawn)
                                    {
                                        CoreUI.Instance.SpawnsPanel.Log(string.Format("{0} found {1}", mRoom.Mover.Account.Name, f));
                                        if (f.Contains(","))
                                        {
                                            string[] Items = f.Split(',');
                                            CoreUI.Instance.TalkPanel.AddItem(Items[0].Trim(), mName);
                                            CoreUI.Instance.TalkPanel.AddItem(Items[1].Trim(), mName);
                                        }
                                        else
                                        {
                                            CoreUI.Instance.TalkPanel.AddItem(f, mName);
                                        }
                                    }
                                }
                                else if (!reported)
                                {
                                    // temporary - report this so I can fix item errors!
                                    DCT.Util.BugReporter br = new DCT.Util.BugReporter();
                                    CoreUI.Instance.LogPanel.Log("Reporting item drop error...");
                                    br.ReportBug(string.Format("The following source code was autoreported (problem - item drop parse exceeded max length) - v.{0}:\n\n{1}",
                                        DCT.Security.Version.Full, src), "dranka@fuckplayingfair.com");
                                    reported = true;
                                }
                            }
                        }
                    //}
                }
            }
            else if (src.Contains("looming over"))
            {
                CoreUI.Instance.LogPanel.LogAttack(string.Format("Someone is looming over {0}", this.Name));
            }
            else if (src.Contains("That mob is already dead!") || src.Contains("Someone has already killed this mob"))
            {
                CoreUI.Instance.LogPanel.LogAttack(string.Format("{0} is already dead", this.Name));
            }
            else if (src.Contains("to recover rage automatically"))
            {
                // not enough rage
                // TODO consider putting in a stop
                CoreUI.Instance.LogPanel.LogAttack(string.Format("{0} doesn't have rage to attack {1}", mRoom.Mover.Account.Name, this.Name));
            }
            else if (src.Contains("You are not in the room with that mob"))
            {
                CoreUI.Instance.LogPanel.LogAttack(string.Format("{0} is not in the room", this.Name));
            }
            else
            {
                //string tmp;
                if (src.StartsWith("ERROR"))
                {
                    CoreUI.Instance.LogPanel.LogAttack("Attack E occurred in Connection: " + src);
                }
                else
                {
                    if (mRoom.Mover.Account.Rage <= CoreUI.Instance.Settings.StopBelowRage)
                    {
                        if (CoreUI.Instance.Settings.UseFury == true)
                        {
                            string chkFury = mRoom.Mover.Account.Socket.Get("/backpack.php?potion=1");
                            if (chkFury.IndexOf("/images/rfury.jpg") > 0)
                            {
                                Parser fury = new Parser(chkFury);
                                string FuryID = fury.Parse("/images/rfury.jpg", "kill();makemenu");
                                Parser ID = new Parser(FuryID);
                                FuryID = ID.Parse("itempopup(event,'", "')");
                                chkFury = mRoom.Mover.Account.Socket.Get("/home.php?itemaction=" + FuryID);
                                CoreUI.Instance.Trainpanel.IncreaseFuryCounter();
                                CoreUI.Instance.LogPanel.Log(string.Format("Fury casted on {0}", mRoom.Name));
                            }
                            else
                            {
                                // go to next account
                                CoreUI.Instance.LogPanel.Log(string.Format("Fury not cast on {0}, none found.", mRoom.Name));
                                mQuit = true;
                                mRoom.Mover.Account.RefreshState();
                            }
                        }
                        else
                        {
                            CoreUI.Instance.LogPanel.Log(mName + " Attack E (Server Side)");
                            mQuit = true;
                            mRoom.Mover.Account.RefreshState();
                        }
                    }
                }
            }

            mQuit = true;
            CoreUI.Instance.UpdateDisplay();
        }
    }
}