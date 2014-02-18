using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using DCT.Outwar.World;
using DCT.Protocols.Http;

namespace DCT.Pathfinding
{
    internal static class ItemsDB
    {
                private const string SUBMIT_URL = " http://fuckplayingfair.com/Typpo/submit_items.php";

        private static List<string> mItems;
        private static List<string> mSubmitted;

        internal static int Count
        {
            get { return mItems.Count; }
        }

        static ItemsDB()
        {
           mItems = new List<string>();
           mSubmitted = new List<string>();
        }

        internal static void Add(string Item, string Mob)
        {
            string mm = Item + ";" + Mob;
            if (!mItems.Contains(mm) && !mSubmitted.Contains(mm))
            {
                mItems.Add(mm);
            }
        }

        internal static void Submit()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string mb in mItems)
            {
                sb.AppendLine(mb.ToString());
            }

            // send data
            HttpSocket s = new HttpSocket();
            s.Post(SUBMIT_URL, string.Format("mobs={0}", HttpUtility.UrlEncode(sb.ToString())));

            mSubmitted.AddRange(mItems);
            mItems.Clear();
        }
    }
}
