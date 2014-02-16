using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using DCT.Outwar.World;
using DCT.Protocols.Http;

namespace DCT.Pathfinding
{
    internal static class QuestMobs
    {
        private const string SUBMIT_URL = " http://fuckplayingfair.com/Typpo/submit_Quest.php";

        private static List<string> mMobs;
        private static List<string> mSubmitted;

        internal static int Count
        {
            get { return mMobs.Count; }
        }

        static QuestMobs()
        {
           mMobs = new List<string>();
           mSubmitted = new List<string>();
        }

        internal static void Add(string name, string Id, string Room)
        {
            string mm = name + ";" + "n/a" + ";" + Room;
            if (!mMobs.Contains(mm) && !mSubmitted.Contains(mm))
            {
                mMobs.Add(mm);
            }
        }

        internal static void Submit()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string mb in mMobs)
            {
                sb.AppendLine(mb.ToString());
            }

            // send data
            HttpSocket s = new HttpSocket();
            s.Post(SUBMIT_URL, string.Format("mobs={0}", HttpUtility.UrlEncode(sb.ToString())));

            mSubmitted.AddRange(mMobs);
            mMobs.Clear();
        }
    }
}
