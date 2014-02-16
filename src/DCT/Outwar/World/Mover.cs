using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DCT.Pathfinding;
using DCT.Protocols.Http;
using DCT.Settings;
using DCT.UI;

namespace DCT.Outwar.World
{
    internal class Mover
    {
        internal Room Location { get; private set; }
        internal int MobsAttacked { get; set; }

        //private long mRageUsed;
        //internal long RageUsed
        //{
        //    get { return mRageUsed; }
        //    set { mRageUsed = value; }
        //}
        internal long ExpGained { get; set; }
        internal OutwarHttpSocket Socket { get; private set; }
        internal Account Account { get; private set; }
        internal ReturnToStartHandler ReturnToStartHandler { get; private set; }

        private int mTrainRoomStart;
        private List<int> mVisited;

        internal Mover(Account account, OutwarHttpSocket socket)
        {
            Socket = socket;
            Account = account;
            Location = new Room(this, 0);

            mTrainRoomStart = -1;
            MobsAttacked = 0;
            ExpGained = 0;

            ReturnToStartHandler = new ReturnToStartHandler(Account);
        }

        internal bool RefreshRoom()
        {
            Account.RefreshState();

            // Now load the actual room info
            int r = LoadRoom(0);
            if (r == 4)
            {
                MessageBox.Show("You logged onto Outwar and booted the program.  Hitting the \"Refresh\" button may solve this.\n\nTo correctly access your account while the program is running, go to Actions > Open in browser after logging in here.",
                    "Account Booted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private int LoadRoom(int id)
        {
            return LoadRoom(id, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>0 if good, 1 if error with retry, 2 if error with override</returns>
        private int LoadRoom(int id, bool isDoor)
        {
            Room tmp = new Room(this, id);
            tmp.IsDoor = isDoor;
            int r = tmp.Load();
            if (r == 0)
                Location = tmp;
            return r;
        }

        internal delegate void PathfindHandler(int roomid);
        internal void PathfindTo(int roomid)
        {
            if (Location == null || roomid == Location.Id || roomid < 0)
            {
                return;
            }

            CoreUI.Instance.LogPanel.Log("Constructing path for " + Account.Name + " to " + roomid);

            List<int> nodes = new List<int>();
            nodes = Pathfinder.BFS(Location.Id, roomid);

            if (nodes == null)
            {
                if (CoreUI.Instance.Settings.AutoTeleport ||
                    MessageBox.Show("The program cannot build a path from your current area to your chosen location.  Do you want to teleport to the nearest bar and try again?  Recommended 'Yes' unless you are in a separated area such as Stoneraven.\n\n(this option can be automatically enabled under the Attack tab)", "Pathfinding Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    CoreUI.Instance.LogPanel.Log(Account.Name + " teleporting...");

                    Account.Socket.Get("world.php?teleport=1");
                    RefreshRoom();
                    nodes = Pathfinder.BFS(Location.Id, roomid);
                }
                else
                {
                    CoreUI.Instance.StopAttacking(true);
                    return;
                }
                //DCErrorReport.Report(this, "Null nodes path (unfamiliar location); teleport attempt possible");
            }

            FollowPath(nodes);
        }

        internal void CoverArea()
        {
            mVisited = new List<int>();

            List<int> path = Pathfinder.CoverArea(Location.Id);
            FollowPath(path);

            CoreUI.Instance.LogPanel.Log("Area '" + Location.Name + "' coverage ended");
            mVisited.Clear();
        }

        private void FollowPath(IList<int> nodes)
        {
            if (nodes == null || nodes.Count < 1)
            {
                CoreUI.Instance.LogPanel.Log("Move E: " + Account.Name + "'s projected path does not exist");
                CoreUI.Instance.UpdateProgressbar(0, 0);
                //DCErrorReport.Report(this, "Projected path does not exist; movement attempt failed");
                return;
            }

            bool attackmode = Globals.AttackMode;

            for (int i = 0; i < nodes.Count; i++)
            {
                int node = nodes[i];
                if (Globals.Terminate)
                {
                    return;
                }
                if (attackmode != Globals.AttackMode)
                {
                    goto end;
                }

                // Send request
                if (!TryRoom(node, 0))
                {
                    // bad room link
                    CoreUI.Instance.LogPanel.Log("Room " + node + " is inaccessible");
                    /*
                    if (i < nodes.Count - 1)
                    {
                        // move to next room in list
                        PathfindTo(nodes[i + 1]);
                    }
                    */
                    continue;
                }
                CoreUI.Instance.UpdateProgressbar(i + 1, nodes.Count);

                if (mVisited != null)
                {
                    mVisited.Add(node);
                }
            }

        end:
            CoreUI.Instance.UpdateProgressbar(0, 0);
            CoreUI.Instance.LogPanel.Log(Account.Name + " path ended");
        }
        /// <summary>
        /// Attempts to move to a room as per specific id#
        /// </summary>
        /// <param name="id">Room id to move to</param>
        /// <param name="tries">Try # that it's on - will call recursively til limit is met</param>
        private bool TryRoom(int id, int tries)
        {
            if (id == Location.Id)
            {
                return true;
            }

            if (!Location.Links.Contains(id))
            {
                return false;
            }

            bool isDoor = id == Location.DoorId;

            switch (LoadRoom(id, isDoor))
            {
                case 3:
                case 1:
                    // error with override, meaning we STOP and try again

                    CoreUI.Instance.LogPanel.Log("Move E: Could not enter room");
                    RefreshRoom();

                    if (++tries > 2)
                    {
                        MessageBox.Show(Account.Name + " is having trouble moving.  Reasons for this include:\n\n- It's impossible to reach your destination (are you missing a key?)\n- The program just can't find a way to get where you want to go\n- Someone logged into your account - press refresh and start your run again", "Moving Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        CoreUI.Instance.StopAttacking(true);
                        return false;
                    }
                    return TryRoom(id, tries);
                case 2:
                    // error without override, ie. key
                    CoreUI.Instance.LogPanel.Log("Move E: Need key");
                    return false;
                default:
                    // otherwise things are all good
                    CoreUI.Instance.LogPanel.Log(Account.Name + " now in room "
                    + (Location.Id == 0 ? "world.php" : Location.Id.ToString()));

                    CoreUI.Instance.UpdateDisplay();

                    if (Globals.AttackOn)
                    {
                        Location.Attack();
                    }
                    return true;
            }
        }

        internal void Spider(object p_bound)
        {
                string bound = p_bound == null ? string.Empty : ((string)p_bound).ToLower();
                // should probably update UI as well
                CoreUI.Instance.Settings.AutoTeleport = false;

                // start in this room
                RefreshRoom();

                Stack<int> s = new Stack<int>();
                List<int> completed = new List<int>();

                // start spidering
                Globals.Spidering = true;
                do
                {
                    if (bound != string.Empty && bound == Location.Name.ToLower())
                    {
                        if (!completed.Contains(Location.Id))
                            completed.Add(Location.Id);
                        goto prep;
                    }

                    // make sure links of current room are in rooms db
                    List<MappedRoom> rooms = Pathfinder.Rooms.FindAll(delegate(MappedRoom rm)
                    {
                        return rm.Id == Location.Id;
                    });

                    if (rooms.Count < 1)
                    {
                        // new room
                        List<int> l = new List<int>();
                        foreach (int k in Location.Links)
                            l.Add(k);
                        MappedRoom mr = new MappedRoom(Location.Id, Location.Name, l);
                        Pathfinder.Rooms.Add(mr);
                        //rooms.Add(mr);

                        CoreUI.Instance.LogPanel.Log(string.Format("Added new room {0}", Location.Id));
                    }
                    else
                    {
                        if (rooms.Count > 1)
                        {
                            // should only be one match
                            MessageBox.Show("problem");
                            CoreUI.Instance.LogPanel.Log(string.Format("Potential duplicate room {0}", Location.Id));
                        }

                        // already exists
                        // add links to map skeleton
                        foreach (MappedRoom rm in rooms)
                        {
                            rm.Name = Location.Name;
                            foreach (int id in Location.Links)
                            {
                                if (!rm.Neighbors.Contains(id) && id > 0)
                                {
                                    rm.Neighbors.Add(id);
                                    CoreUI.Instance.LogPanel.Log(string.Format("Added link {0} from {1}", id, Location.Id));
                                }
                            }
                        }
                    }

                    // bookkeeping
                    if (!completed.Contains(Location.Id))
                        completed.Add(Location.Id);
                    foreach (int id in Location.Links)
                    {
                        if (id > 0 && !s.Contains(id) && !completed.Contains(id))
                        {
                            Console.WriteLine("Adding link {0}->{1}", Location.Id, id);
                            List<int> nbrslist = new List<int> {Location.Id};
                            MappedRoom mr = new MappedRoom(id, string.Empty, nbrslist);
                            Pathfinder.Rooms.Add(mr);
                            s.Push(id);
                        }
                    }
                    // sort for pathfinding search
                    Pathfinder.Rooms.Sort();
                    Pathfinder.LinkRooms();

                    // add mobs
                    foreach (Mob mb in Location.Mobs)
                    {
                        mb.Initialize();
                        Pathfinder.Mobs.Add(new MappedMob(mb.Name, mb.Id, Location.Id, mb.Level, mb.Rage));
                    }

                    prep:

                    if (s.Count < 1)
                        // done
                        break;

                    // move to top of stack
                    int next = s.Pop();
                    Console.WriteLine("Pathing from {0} to {1}", Location.Id, next);
                    PathfindTo(next);
                    if(!completed.Contains(next))
                        completed.Add(next);
                } while (Globals.AttackMode);

                Globals.Spidering = false;
                MessageBox.Show("Done spidering");
        }

        internal void Train()
        {
            if (!Account.NeedsLevel)
            {
                CoreUI.Instance.LogPanel.Log(Account.Name + " doesn't need leveling");
                return;
            }

            Account.Socket.Get("levelup.php");
            CoreUI.Instance.LogPanel.Log(Account.Name + " has been leveled.");
            //CoreUI.Instance.LogPanel.Log("Loading all possible bars...");

            //mTrainRoomStart = Location.Id;

            //List<List<int>> paths = new List<List<int>>();
            //paths.Add(Pathfinder.BFS(Location.Id, 258)); // dustglass
            //paths.Add(Pathfinder.BFS(Location.Id, 377)); // drunkenclam
            //paths.Add(Pathfinder.BFS(Location.Id, 401)); //hardiron

            //bool tmp = CoreUI.Instance.Settings.AutoTrain;
            //CoreUI.Instance.Settings.AutoTrain = true;

            //int shortest = 0;
            //for (int i = 1; i < paths.Count; i++)
            //{
            //    List<int> path = paths[i];
            //    if (path != null && path.Count < paths[shortest].Count)
            //    {
            //        shortest = i;
            //    }
            //}

            //FollowPath(paths[shortest]);

            //CoreUI.Instance.Settings.AutoTrain = tmp;
            //Location.Train();

            //if (Location.Trained)
            //    CoreUI.Instance.LogPanel.Log(Account.Name + " has been leveled");
            //else
            //    CoreUI.Instance.LogPanel.Log(Account.Name + " not leveled - can't find bartender");
        }

        internal void TrainReturn()
        {
            PathfindTo(mTrainRoomStart);
            mTrainRoomStart = -1;
        }
    }
}
