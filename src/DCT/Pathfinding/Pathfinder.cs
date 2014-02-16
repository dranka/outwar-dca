using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DCT.Protocols.Http;
using DCT.Security;
using DCT.UI;
using DCT.Util;

namespace DCT.Pathfinding
{
    internal static class Pathfinder
    {
        private const string MUTEX_NAME = "DCT_PATHFINDER_MUTEX";
        public static string GroupName;

        internal static List<MappedRoom> Rooms { get; private set; }
        internal static List<MappedMob> Mobs { get; private set; }
        internal static SortedList<string, int> Adventures { get; private set; }
        internal static SortedList<string, int> Quest { get; private set; }
        internal static List<MappedMob> Spawns { get; private set; }

        internal static void BuildMap(object update)
        {
            BuildMap((bool)update);
        }

        internal static void BuildMap(bool update)
        {
            using (Mutex mutex = new Mutex(false, MUTEX_NAME))
            {
                if (!mutex.WaitOne(0, true))
                {
                    MessageBox.Show(
                        "Can't build multiple maps at once - wait until the other program is done opening.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                DoBuildMap(update);
            }
        }

        private static void DoBuildMap(bool update)
        {
            Rooms = new List<MappedRoom>();
            Mobs = new List<MappedMob>();
            Spawns = new List<MappedMob>();
            Adventures = new SortedList<string, int>();
            Quest = new SortedList<string, int>();

            string map;
            List<int> nbrs;
            string name;
            int id;
            string[] tmp;

            //*
            for (int i = 0; i < 2 && Rooms.Count < 1; i++)
            {
                if (!File.Exists("rooms.dat") || update)
                {
                    Download("rooms");
                }
                if ((map = ReadDecrypt("rooms")) == null)
                    continue;

                foreach (string token in map.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (string.IsNullOrEmpty(token.Trim()) || token.StartsWith("#"))
                        continue;

                    tmp = token.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (!int.TryParse(tmp[0], out id))
                    {
                        continue;
                    }
                    name = tmp[tmp.Length - 1];
                    nbrs = new List<int>();
                    for (int j = 1; j < tmp.Length - 1; j++)
                    {
                        nbrs.Add(int.Parse(tmp[j]));
                    }
                    if (nbrs.Count < 1)
                        continue;
                    Rooms.Add(new MappedRoom(id, name, nbrs));
                }
            }
            Rooms.Sort();
            LinkRooms();
            //*/

            // ------------------

            MappedMob mm;
            string[] parts;
            for (int i = 0; i < 2 && Mobs.Count < 1; i++)
            {
                if (!File.Exists("mobs.dat") || update)
                {
                    Download("mobs");
                }
                if ((map = ReadDecrypt("mobs")) == null)
                    continue;
                foreach (string token in map.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (string.IsNullOrEmpty(token.Trim()) || token.StartsWith("#"))
                        continue;
                    parts = token.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 5)
                    {
                        // not good input
                        continue;
                    }
                    mm = new MappedMob(parts[0], long.Parse(parts[1]), int.Parse(parts[2]), long.Parse(parts[3]), long.Parse(parts[4]));
                    Mobs.Add(mm);
                }
                i++;
            }
            Mobs.Sort();

            // -----------------

            for (int i = 0; i < 2 && Adventures.Count < 1; i++)
            {
                if (!File.Exists("raids.dat") || update)
                {
                    Download("raids");
                }
                if ((map = ReadDecrypt("raids")) == null)
                    continue;
                
                foreach (string token in map.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (string.IsNullOrEmpty(token.Trim()) || token.StartsWith("#"))
                        continue;

                    string[] j = token.Split(';');
                    name = j[0];
                    id = int.Parse(j[1]);
                    CoreUI.Instance.RaidsPanel.Group = j[2];
                    CoreUI.Instance.RaidsPanel.AddRaidItem(name, id.ToString());

                    //int j = token.IndexOf(";");
                    //name = token.Substring(0, j);
                    //id = int.Parse(token.Substring(j + 1));
                    //Adventures.Add(name, id);
                }
                i++;
            }

            //------------------
            //Quest Mobs

            CoreUI.Instance.TalkPanel.BuildView();
            for (int i = 0; i < 2 && Quest.Count < 1; i++)
            {
                if (!File.Exists("quest.dat") || update)
                {
                    Download("quest");
                }
                if ((map = ReadDecrypt("quest")) == null)
                    continue;

                foreach (string token in map.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (string.IsNullOrEmpty(token.Trim()) || token.StartsWith("#"))
                        continue;

                    string[] j = token.Split(';');
                    CoreUI.Instance.TalkPanel.LoadQuestMobs(j[0], j[1], j[2]);
                }

                i++;
            }

            // ------------------
            // Spawns

            for (int i = 0; i < 2 && Spawns.Count < 1; i++)
            {
                if (!File.Exists("spawns.dat") || update)
                {
                    Download("spawns");
                }
                if ((map = ReadDecrypt("spawns")) == null)
                    continue;
                foreach (string token in map.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (string.IsNullOrEmpty(token.Trim()) || token.StartsWith("#"))
                        continue;
                    parts = token.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 3)
                    {
                        // not good input
                        continue;
                    }
                    mm = new MappedMob(parts[0], -1, int.Parse(parts[2]), long.Parse(parts[1]), -1);
                    Spawns.Add(mm);
                }
                i++;
            }
            Spawns.Sort();
        }



        internal static void LinkRooms()
        {
            // Rooms must be sorted
            foreach (MappedRoom r in Rooms)
            {
                foreach (int i in r.Neighbors)
                {
                    int idx = FindRoom(i);
                    if (idx < 0)
                    {
                        // shouldn't happen - broken link!
                        //Console.WriteLine("Broken link {0} to {1}", r.Id, i);
                        continue;
                    }
                    r.MappedNeighbors.Add(Rooms[idx]);
                }
            }
        }

        internal static void Download(string maptype)
        {
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", HttpSocket.DefaultInstance.UserAgent);
            try
            {
                client.DownloadFile("http://fuckplayingfair.com/Typpo/maps/" + maptype + ".php", maptype + ".dat");
                CoreUI.Instance.Settings.LastMapUpdate = DateTime.Now.ToUniversalTime();
            }
            catch (WebException)
            {
                // 
            }
        }

        internal static string ReadDecrypt(string maptype)
        {
            if (!File.Exists(maptype + ".dat"))
                return null;

            StreamReader sr = new StreamReader(maptype + ".dat");
            string text;
            try
            {
                text = sr.ReadToEnd();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                sr.Close();
            }
            return Crypt.Get(Crypt.HexToBin(text), HttpSocket.DefaultInstance.UserAgent, false);
        }

        internal static string BadLinks()
        {
            StringBuilder sb = new StringBuilder();

            foreach (MappedRoom rm in Rooms)
            {
                foreach (int nbr in rm.Neighbors)
                {
                    if (FindRoom(nbr) == -1)
                    {
                        sb.Append("Room " + rm.Id + "/" + rm.Name + " invalid link to: " + nbr);
                    }
                }
            }

            foreach (MappedMob mb in Mobs)
            {
                if (mb != null && FindRoom(mb.Room) == -1)
                {
                    sb.Append("Mob " + mb.Id + "/" + mb.Name + " invalid placement in: " + mb.Room);
                }
            }

            return sb.ToString();
        }

        internal static List<int> BFS(int s, int d)
        {
            lock (Rooms)
            {
                InitBFSVertices();
                Queue<MappedRoom> Q = new Queue<MappedRoom>();
                int srcidx = FindRoom(s);    // logn
                if (srcidx < 0)
                    return null;
                MappedRoom source = Rooms[srcidx];
                source.Visited = true;
                Q.Enqueue(source);

                while (Q.Count > 0)
                {
                    MappedRoom dequeued = Q.Dequeue();
                    if (dequeued.Id == d)
                    {
                        // return a result
                        return BFSPath(source, dequeued);
                    }
                    foreach (MappedRoom neighbor in dequeued.MappedNeighbors)
                    {
                        if (!neighbor.Visited)
                        {
                            neighbor.Visited = true;
                            neighbor.Pi = dequeued;
                            Q.Enqueue(neighbor);
                        }
                    }
                }
                return null;
            }
        }

        private static void InitBFSVertices()
        {
            foreach (MappedRoom r in Rooms)
            {
                r.Pi = null;
                r.Visited = false;
            }
        }

        private static List<int> BFSPath(MappedRoom s, MappedRoom v)
        {
            // assume BFS has just been run

            List<int> ret = new List<int>();
            while (s.Id != v.Id)
            {
                if (v.Pi == null)
                    return null;    // no path

                ret.Add(v.Id);
                v = v.Pi;
            }
            ret.Reverse();
            return ret;
        }

        internal static List<int> CoverArea(int start)
        {
            List<int> idList = new List<int>();

            int idx = FindRoom(start);
            MappedRoom startRoom;
            if (idx > -1 && idx < Rooms.Count)
            {
                startRoom = Rooms[idx];
            }
            else
            {
                return null;
            }
            idList.Add(start);

            foreach (MappedRoom rm in Rooms)
            {
                if (rm != null && rm.Name.Equals(startRoom.Name))
                {
                    idList.Add(rm.Id);
                }
            }

            List<int> ret = BFS(start, idList[0]);
            if (ret == null)
            {
                return null;
            }

            for(int i = 1; i < idList.Count; i++)
            {
                List<int> tmp = BFS(idList[i - 1], idList[i]);
                if (tmp != null)
                {
                    ret.AddRange(tmp);
                }
            }

            return ret;
        }

        internal static void Benchmark(object n)
        {
            double total = 0.0;
            int j = (int)n;
            Console.WriteLine("Running...");
            for (int i = 0; i < j; i++)
            {
                int a = 0, b = 0;
                while (!Exists(a = Randomizer.Random.Next(1, Rooms.Count)));
                while (!Exists(a = Randomizer.Random.Next(1, Rooms.Count)));

                DateTime startTime = DateTime.Now;
                BFS(a, b);
                DateTime stopTime = DateTime.Now;
                TimeSpan duration = stopTime - startTime;
                total += duration.Milliseconds;
            }
            Console.WriteLine(string.Format("Ran {0} tests, average {1} ms", j, total / j));
        }

        /// <summary>
        /// Returns the index of a room with a given ID#
        /// </summary>
        /// <param name="find"></param>
        /// <returns></returns>
        internal static int FindRoom(int find)
        {
            return Rooms.BinarySearch(new MappedRoom(find, null, null));
        }

        internal static bool Exists(int id)
        {
            return FindRoom(id) > -1;
        }

        internal static void ExportRooms()
        {
            StringBuilder sb = new StringBuilder();
            foreach(MappedRoom rm in Rooms)
                sb.AppendFormat("{0}\n", rm);

            FileIO.SaveFileFromString("Export Rooms", "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                                      "DCT Rooms " + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second, sb.ToString());
        }

        internal static void ExportMobs()
        {
            StringBuilder sb = new StringBuilder();
            foreach (MappedMob mb in Mobs)
                sb.AppendFormat("{0}\n", mb);
 
            FileIO.SaveFileFromString("Export Mobs", "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                                      "DCT Mobs " + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second, sb.ToString());
        }
    }
}