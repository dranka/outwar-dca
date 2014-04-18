using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using DCT.Outwar.World;
using DCT.Protocols.Http;

namespace DCT.Pathfinding
{
    internal static class sRooms
    {
        private const string SUBMIT_URL = " http://fuckplayingfair.com/Typpo/submit_rooms.php";

        private static List<MappedRoom> mRooms;
        private static List<MappedRoom> mSubmitted;

        internal static int Count
        {
            get { return mRooms.Count; }
        }

        static sRooms()
        {
            mRooms = new List<MappedRoom>();
            mSubmitted = new List<MappedRoom>();
        }

        internal static void Add(MappedRoom name)
        {
            MappedRoom mm = name;
            if (!mRooms.Contains(mm))
            {
                mRooms.Add(mm);
            } 
        }

        internal static void Clear()
        {
            mRooms.Clear();
        }

        internal static void Submit()
        {
            StringBuilder sb = new StringBuilder();
            foreach (MappedRoom mb in mRooms)
            {
                sb.AppendLine(mb.ToString());
            }

            // send data
            HttpSocket s = new HttpSocket();
            s.Post(SUBMIT_URL, string.Format("mobs={0}", HttpUtility.UrlEncode(sb.ToString())));

            mSubmitted.AddRange(mRooms);
            mRooms.Clear();
        }
    }
}