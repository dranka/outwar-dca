using System.Collections.Generic;
using System;
using DCT.Parsing;
using DCT.Settings;
using DCT.Threading;
using DCT.UI;
using DCT.Util;
using DCT.Pathfinding;

namespace DCT.Outwar.World
{
    internal class Room
    {
        internal Mover Mover { get; private set; }
        internal int Id { get; private set; }
        internal string Name { get; set; }
        internal bool Trained { get; private set; }
        internal List<int> Links { get; private set; }
        internal List<Mob> Mobs { get; private set; }
        internal bool IsDoor { get; set; }

        // Door handling
        internal int DoorId { get; private set; }
        private string mDoorUrl;

        internal Room(Mover mover, int id)
        {
            Id = id;
            Mover = mover;
            DoorId = -1;
            mDoorUrl = null;

            Trained = false;
            Links = new List<int>();
            IsDoor = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>0 on success, 1 on hash error, 2 on key, 3 on DC broken.  4 to stop all attacking</returns>
        internal int Load()
        {
            // create url
            string url = string.Format("ajax_changeroomb.php?room={0}&lastroom={1}", Id, Mover.Location.Id);

            if (IsDoor)
            {
                url += "&door=1";
            }
            string src = Mover.Socket.Get(url);
            //if (Globals.Spidering)
            //{
            //    // normal rooms
            //    int n, s, e, w;
            //    n = s = e = w = -1;
            //    int.TryParse(Parser.Parse(src, "\"north\":\"", "\""), out n);
            //    int.TryParse(Parser.Parse(src, "\"south\":\"", "\""), out s);
            //    int.TryParse(Parser.Parse(src, "\"east\":\"", "\""), out e);
            //    int.TryParse(Parser.Parse(src, "\"west\":\"", "\""), out w);
            //    List<int> nbrs = new List<int>();
            //    nbrs.Add(n);
            //    nbrs.Add(e);
            //    nbrs.Add(s);
            //    nbrs.Add(w);
            //    Pathfinding.MappedRoom nr = new Pathfinding.MappedRoom(Mover.Location.Id, Mover.Location.Name, nbrs);
                
            //    Pathfinding.sRooms.Add(nr);
            //}
            if (src.Contains("Could not connect, please try again."))
            {
                src = Mover.Socket.Get(url);
            }
            else
            {
                try
                {
            src = System.Text.RegularExpressions.Regex.Unescape(src);
                }
                catch (Exception Ex)
                {

                }

            }



            Parser p = new Parser(src);
            // TODO look how error messages changed
            if (src.Contains("Error #301"))
            {
                // hash error
                return 1;
            }
            if (src.Contains("you must be carrying") || src.Contains("cast on you to enter this room."))
            {
                // need a key
                return 2;
            }
            if (src.Contains("Rampid Gaming Login"))
            {
                // logged out
                return 4;
            }

            if (Id == 0)
            {
                // loading world.php; figure out where we are
                string tmp = Parser.Parse(src, "\"curRoom\":\"", "\"");
                int tmpid;
                if (!int.TryParse(tmp, out tmpid))
                {
                    return 3;
                }
                Id = tmpid;
            }
            Name = p.Parse("\"name\":\"", "\"");

            EnumRooms(src);

            if (Globals.AttackMode || Globals.Spidering)
            {
                EnumMobs(src);
            }
            else if (CoreUI.Instance.Settings.AutoTrain|| CoreUI.Instance.Settings.AutoQuest || CoreUI.Instance.Settings.AlertQuests)
            {
                EnumMobs(src);

                if (CoreUI.Instance.Settings.AutoTrain)
                    Trained = Train();
                if (CoreUI.Instance.Settings.AutoQuest || CoreUI.Instance.Settings.AlertQuests)
                    Quest();
            }

            return 0;
        }

        internal void EnumMobs(string src)
        {
            // TODO this should really just throw an exception
            if (string.IsNullOrEmpty(src))
            {
                Load();
            }
            Mobs = new List<Mob>();


            foreach (string s in Parser.MultiParse(src, "<TR><table width=100% cellpadding=0 cellspacing=0 border=0", "spacer.gif"))
            {
                Parser p = new Parser(s);

                string url = "mob.php?" + p.Parse("mob.php?", "\"");
                string name;
                string attackurl = string.Empty;
                bool trainer = false;
                bool quest = false;
                bool spawn = false;

                if (s.Contains("Spawned by"))
                {

                    //parsing for server spawns needs fixed here
                    string level = Parser.Parse(s, "<br>Level: ", "</font>");
                    name = Parser.CutTrailing(Parser.CutLeading(s, " size=\"2\"><b>"), "<");
                    if (name.Contains("<"))
                    {
                        // TODO this is a bandaid fix re: a bug with the parser.  It will pick up html from killed spawn mobs
                        continue;
                    }
                    spawn = true;
                    // log spawn sighting, but don't attack it if we shouldn't
                    if (Globals.AttackOn)
                    {
                        CoreUI.Instance.SpawnsPanel.Log(string.Format("{0} sighted {1} in room {2} - Level: {3}", Mover.Account.Name, name, Id, level));
                        //bool exists = CoreUI.Instance.SpawnsPanel.SearchSpawns(name, level, Id.ToString());
                        //if (!exists)
                        //    Spawns.Add(name + ";" + level + ";" + Id + ";");
                        ////CoreUI.Instance.SpawnsPanel.Log(name + ";" + level + ";" + Id + ";");
                        //CoreUI.Instance.SpawnsPanel.Sighted(Id);
                        if (!CoreUI.Instance.Settings.AttackSpawns)
                            continue;
                    }
                }
                else
                {
                    name = Parser.Parse(Parser.CutLeading(s, url + "\">"), "><b>", "</b><br>Level");
                    //name = Parser.Parse(Parser.CutLeading(s, "Level:"), "><b>", "</b><br>");
                }
                if (s.Contains("questicon.png"))
                {
                    string ModID = p.Parse("id=", "&h=");
                    CoreUI.Instance.TalkPanel.AddMob(name, ModID, Id.ToString());
                    quest = true;
                    //StartQuest();
                }

                if (s.Contains("trainicon.png"))
                {
                    trainer = true;
                }

                if (s.Contains("somethingelse.php"))
                {
                    attackurl = "somethingelse.php" + p.Parse("somethingelse.php", "\"");
                }
                else
                {
                    continue;
                }



                /*
                if (string.IsNullOrEmpty(attackurl) && !quest && !trainer)
                {
                    continue;
                }*/

                Mob mb = new Mob(name, url, attackurl, quest, trainer, spawn, this);
                Mobs.Add(mb);
            }
        }

        internal void EnumRooms(string src)
        {
            // normal rooms
            int n, s, e, w;
            n = s = e = w = -1;
            int.TryParse(Parser.Parse(src, "\"north\":\"", "\""), out n);
            int.TryParse(Parser.Parse(src, "\"south\":\"", "\""), out s);
            int.TryParse(Parser.Parse(src, "\"east\":\"", "\""), out e);
            int.TryParse(Parser.Parse(src, "\"west\":\"", "\""), out w);
            Links.Add(n);
            Links.Add(s);
            Links.Add(e);
            Links.Add(w);


            // doors
            if (src.Contains("door=1"))
            {
                mDoorUrl = Parser.Parse(src, "world.php?room=", "&door");
                int tmpDoorId;
                string doorIdStr = mDoorUrl.Substring(0, mDoorUrl.IndexOf("&"));
                if (!int.TryParse(doorIdStr, out tmpDoorId))
                {
                    CoreUI.Instance.LogPanel.Log("E: Couldn't read door for room " + Id + " from " + doorIdStr);
                    return;
                }
                DoorId = tmpDoorId;
                Links.Add(DoorId);
            }
            else
            {
                mDoorUrl = null;
                DoorId = -1;
            }
        }

        /// <summary>
        /// Attack all the mobs in this room
        /// </summary>
        internal void Attack()
        {
            if (Mobs == null)
            {
                // TODO when does this happen?
                System.Windows.Forms.MessageBox.Show("Enum mobs has not occured before attack; report this error");
                return;
            }
            if (Mobs.Count < 1)
            {
                return;
            }

            for (int i = 0; i < Mobs.Count; i++)
            {
                Mob mob = Mobs[i];
                if (!Globals.AttackOn || !Globals.AttackMode)
                {
                    return;
                }
                mob.Attack();
            }
            // TODO should be done with callback
            CoreUI.Instance.LogPanel.Log("Waiting for Outwar to respond...");
            for (int i = 0; i < Mobs.Count; i++)
            {
                Mob mob = Mobs[i];
                while (mob.Attacking)
                {
                    ThreadEngine.Sleep(10);
                }
            }
        }

        internal void AttackMob(int id)
        {
            if (Mobs == null || Mobs.Count < 1)
            {
                return;
            }

            // TODO mMobs should be in a dictionary by id
            foreach (Mob mb in Mobs)
            {
                if (mb.Id == id)
                {
                    AttackMob(mb);
                    return;
                }
            }
        }

        internal void AttackMob(string name)
        {
            foreach (Mob mb in Mobs)
            {
                if (mb.Name == name)
                {
                    AttackMob(mb);
                    return;
                }
            }
        }

        internal void AttackSpawns()
        {
            foreach (Mob mb in Mobs)
            {
                if (mb.IsSpawn)
                {
                    AttackMob(mb);
                    return;
                }
            }
        }

        private static void AttackMob(Mob mb)
        {
            mb.Attack(false);
        }

        internal bool Train()
        {
            if (Mobs == null || Mobs.Count < 1)
            {
                return false;
            }

            foreach (Mob mb in Mobs)
            {
                if (mb.IsTrainer)
                {
                    mb.Train();
                    return true;
                }
            }
            return false;
        }

        internal void Quest()
        {
            foreach (Mob mb in Mobs)
            {
                if (mb.IsTalkable)
                {
                    //mb.Talk();
                }
            }
        }
    }
}
