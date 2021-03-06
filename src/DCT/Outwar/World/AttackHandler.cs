using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DCT.Settings;
using DCT.Parsing;
using DCT.UI;
using DCT.Util;
using System.Threading;

namespace DCT.Outwar.World
{
    internal static class AttackHandler
    {
        internal class MobArg
        {
            internal string Name { get; private set; }
            internal int RoomId { get; private set; }
            internal int Id { get; private set; }
            public MobArg(int id, int roomid, string name)
            {
                Id = id;
                Name = name;
                RoomId = roomid;
            }
        }

        private static List<Account> mAccounts;
        private static AttackingType mType;

        private static Dictionary<int, string> mAreas = new Dictionary<int, string>();
        private static List<MobArg> mMobs = new List<MobArg>();
        private static List<int> mRooms = new List<int>();

        internal static void Set(List<Account> accounts, AttackingType type)
        {
            mAccounts = accounts;
            mType = type;
        }

        internal static void BeginArea()
        {
            StartRun();
        }

        internal static void BeginMultiArea(Dictionary<int, string> rooms)
        {
            mAreas = rooms;
            StartRun();
        }

        internal static void BeginMobs(List<MobArg> mobs)
        {
            mMobs = mobs;
            StartRun();
        }

        internal static void BeginRooms(List<int> rooms)
        {
            mRooms = rooms;
            StartRun();
        }

        /// <summary>
        /// Passes account processing to a ThreadPool thread
        /// </summary>
        private static void StartRun()
        {
            if (mAccounts.Count < 1)
            {
                CoreUI.Instance.LogPanel.LogAttack("E: You must enter an account first");
                return;
            }

            if (CoreUI.Instance.Settings.AttackMode != AttackingType.Mobs && CoreUI.Instance.Settings.FilterMobs && CoreUI.Instance.Settings.MobFilters.Length < 1)
            {
                CoreUI.Instance.LogPanel.LogAttack("E: You have filters enabled but you haven't set them.  Nothing will be attacked with these settings - turn filtering off.");
                return;
            }

            CoreUI.Instance.ToggleAttack(true);

            if (mType == AttackingType.CurrentArea)
            {
                lock (mAccounts)
                {
                    foreach (Account m in mAccounts)
                    {
                        ThreadPool.QueueUserWorkItem(o => Run(m));
                        Thread.Sleep(500);
                    }
                }
            }
            else
            {
                MethodInvoker d = Run1;
                d.BeginInvoke(RunCallback, d);
            }     
        }

        /// <summary>
        /// Attacks with accounts
        /// </summary>
        private static void Run(Account a)
        {
            // save settings
            //RegistryUtil.Save();
            
            IniWriter.Save();
            ConfigSerializer.WriteFile("config.xml", CoreUI.Instance.Settings);

            CoreUI.Instance.ToggleNotifyIcon(true);

            //lock (mAccounts)
            //{
               // foreach (Account a in mAccounts)
               // {
                    
                    CoreUI.Instance.LogPanel.Log("Refreshing " + a.Name + "'s position...");
                    if (!a.Mover.RefreshRoom())
                    {
                        CoreUI.Instance.ToggleNotifyIcon(false);
                        return;
                    }

                    // no point in moving if we don't have rage
                    if (a.Mover.Account.Rage > -1 && a.Mover.Account.Rage < Math.Max(1, CoreUI.Instance.Settings.StopBelowRage))
                    {
                        if (CoreUI.Instance.Settings.UseFury == true)
                        {
                            string chkFury = a.Mover.Account.Socket.Get("/backpack.php?potion=1");
                            if (chkFury.IndexOf("/images/rfury.jpg") > 0)
                            {
                                Parser fury = new Parser(chkFury);
                                string FuryID = fury.Parse("/images/rfury.jpg", "kill();makemenu");
                                Parser ID = new Parser(FuryID);
                                FuryID = ID.Parse("itempopup(event,'", "')");
                                chkFury = a.Mover.Account.Socket.Get("/home.php?itemaction=" + FuryID);
                                CoreUI.Instance.Trainpanel.IncreaseFuryCounter();
                                CoreUI.Instance.LogPanel.Log(string.Format("Fury casted on {0}", a.Name));
                            }
                            else
                            {
                                // go to next account
                                CoreUI.Instance.LogPanel.Log(string.Format("Fury not cast on {0}, none found.", a.Name));
                                //continue;
                            }
                        }
                        else
                        {
                            // go to next account
                            CoreUI.Instance.LogPanel.Log(string.Format("Not attacking on {0}, reached rage limit", a.Name));
                            //continue;
                        }
                    }

                    a.Mover.ReturnToStartHandler.SetOriginal();

                    CoreUI.Instance.AccountsPanel.Engine.SetMain(a);
                    switch (mType)
                    {
                        case AttackingType.CurrentArea:
                            CoreUI.Instance.DoAttackArea();
                            break;
                        case AttackingType.MultiArea:
                            CoreUI.Instance.DoAttackMultiAreas(mAreas);
                            break;
                        case AttackingType.Mobs:
                            CoreUI.Instance.DoAttackMobs(mMobs);
                            break;
                        case AttackingType.Rooms:
                            CoreUI.Instance.DoAttackRooms(mRooms);
                            break;
                    }


                    // update account state
                    a.RefreshState();

                    // Finished
                    CoreUI.Instance.LogPanel.Log(a.Name + " attack coverage complete");

                    if (!Globals.AttackMode)
                    {
                        //break;
                    }
                //}
           // }

            CoreUI.Instance.ToggleNotifyIcon(false);

            // submit any newfound mobs to pathfinding database
            if (Pathfinding.MobCollector.Count > 0)
            {
                CoreUI.Instance.LogPanel.Log("Submitting " + Pathfinding.MobCollector.Count + " new mobs");
                //Pathfinding.MobCollector.UpdateMobs();
                Pathfinding.MobCollector.Submit();
            }

            if (Pathfinding.Spawns.Count > 0)
            {
                CoreUI.Instance.LogPanel.Log("Submitting " + Pathfinding.Spawns.Count + " new spawns");
                Pathfinding.Spawns.Submit();
            }

            if (Pathfinding.QuestMobs.Count > 0)
            {
                CoreUI.Instance.LogPanel.Log("Submitting " + Pathfinding.QuestMobs.Count + " new quest mobs");
                Pathfinding.QuestMobs.Submit();
            }
            if (Pathfinding.ItemsDB.Count > 0)
            {
                CoreUI.Instance.LogPanel.Log("Submitting " + Pathfinding.ItemsDB.Count + "new items");
                Pathfinding.ItemsDB.Submit();
            }

            CoreUI.Instance.ToggleAttack(false);
            Globals.AttackOn = false;

            if (CoreUI.Instance.Settings.ReturnToStart)
            {
                foreach (Account m in mAccounts)
                {
                    m.Mover.ReturnToStartHandler.InvokeReturn();
                }
            }

            if (CoreUI.Instance.Settings.UseCountdownTimer || CoreUI.Instance.Settings.UseHourTimer)
            {
                CoreUI.Instance.Countdown(mType);
            }

            mAreas.Clear();
            mMobs.Clear();
        }

        private static void Run1()
        {
            // save settings
            RegistryUtil.Save();
            IniWriter.Save();
            ConfigSerializer.WriteFile("config.xml", CoreUI.Instance.Settings);

            CoreUI.Instance.ToggleNotifyIcon(true);

            lock (mAccounts)
            {
                foreach (Account a in mAccounts)
                {
                    CoreUI.Instance.LogPanel.Log("Refreshing " + a.Name + "'s position...");
                    if (!a.Mover.RefreshRoom())
                    {
                        CoreUI.Instance.ToggleNotifyIcon(false);
                        return;
                    }

                    // no point in moving if we don't have rage
                    if (a.Mover.Account.Rage > -1 && a.Mover.Account.Rage < Math.Max(1, CoreUI.Instance.Settings.StopBelowRage))
                    {
                        // go to next account
                        CoreUI.Instance.LogPanel.Log(string.Format("Not attacking on {0}, reached rage limit", a.Name));
                        continue;
                    }

                    a.Mover.ReturnToStartHandler.SetOriginal();

                    CoreUI.Instance.AccountsPanel.Engine.SetMain(a);
                    switch (mType)
                    {
                        case AttackingType.CurrentArea:
                            CoreUI.Instance.DoAttackArea();
                            break;
                        case AttackingType.MultiArea:
                            CoreUI.Instance.DoAttackMultiAreas(mAreas);
                            break;
                        case AttackingType.Mobs:
                            CoreUI.Instance.DoAttackMobs(mMobs);
                            break;
                        case AttackingType.Rooms:
                            CoreUI.Instance.DoAttackRooms(mRooms);
                            break;
                    }


                    // update account state
                    a.RefreshState();

                    // Finished
                    CoreUI.Instance.LogPanel.Log(a.Name + " attack coverage complete");

                    if (!Globals.AttackMode)
                    {
                        break;
                    }
                }
            }

            CoreUI.Instance.ToggleNotifyIcon(false);

            // submit any newfound mobs to pathfinding database
            // submit any newfound mobs to pathfinding database
            if (Pathfinding.MobCollector.Count > 0)
            {
                CoreUI.Instance.LogPanel.Log("Submitting " + Pathfinding.MobCollector.Count + " new mobs");
                //Pathfinding.MobCollector.UpdateMobs();
                Pathfinding.MobCollector.Submit();
            }

            if (Pathfinding.QuestMobs.Count > 0)
            {
                CoreUI.Instance.LogPanel.Log("Submitting " + Pathfinding.QuestMobs.Count + " new quest mobs");
                Pathfinding.QuestMobs.Submit();
            }
            if (Pathfinding.ItemsDB.Count > 0)
            {
                CoreUI.Instance.LogPanel.Log("Submitting " + Pathfinding.ItemsDB.Count + "new items");
                Pathfinding.ItemsDB.Submit();
            }
        }

        private static void RunCallback(IAsyncResult ar)
        {
            MethodInvoker d = (MethodInvoker)ar.AsyncState;
            d.EndInvoke(ar);

            CoreUI.Instance.ToggleAttack(false);
            Globals.AttackOn = false;

            if (CoreUI.Instance.Settings.ReturnToStart)
            {
                foreach (Account a in mAccounts)
                {
                    a.Mover.ReturnToStartHandler.InvokeReturn();
                }
            }

            if (CoreUI.Instance.Settings.UseCountdownTimer || CoreUI.Instance.Settings.UseHourTimer)
            {
                CoreUI.Instance.Countdown(mType);
            }

            mAreas.Clear();
            mMobs.Clear();
        }
    }
}