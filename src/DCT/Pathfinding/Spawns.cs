using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using DCT.Outwar.World;
using DCT.Protocols.Http;

namespace DCT.Pathfinding
{
    internal static class Spawns
    {
        private const string SUBMIT_URL = " http://fuckplayingfair.com/Typpo/submit_spawns.php";

        private static List<string> mSpawns;
        private static List<string> mSubmitted;

        internal static int Count
        {
            get { return mSpawns.Count; }
        }

        static Spawns()
        {
            mSpawns = new List<string>();
            mSubmitted = new List<string>();
        }

        internal static void Add(string name)
        {
            string mm = name;
            if (!mSpawns.Contains(mm))
            {
                mSpawns.Add(mm);
            }
        }

        internal static void Clear()
        {
            mSpawns.Clear();
        }

        internal static void Submit()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string mb in mSpawns)
            {
                sb.AppendLine(mb.ToString());
            }

            // send data
            HttpSocket s = new HttpSocket();
            s.Post(SUBMIT_URL, string.Format("mobs={0}", HttpUtility.UrlEncode(sb.ToString())));

            mSubmitted.AddRange(mSpawns);
            mSpawns.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}