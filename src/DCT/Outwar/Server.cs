using System;
using System.Collections.Generic;

namespace DCT.Outwar
{
    public enum ServerName
    {
        sigil,
        torax,
        fabar,
        zimbob,
        rancid,
        quiver
    }

    internal class Server
    {
        internal const int NUM_SERVERS = 6;

        internal static List<string> NamesList
        {
            get
            {
                List<string> ret = new List<string>();
                ret.Add("Sigil");
                ret.Add("Torax");
                ret.Add("Fabar");
                ret.Add("Zimbob");
                ret.Add("Rancid");
                ret.Add("Quiver");
                return ret;
            }
        }

        internal static int NameToId(ServerName n)
        {
            switch (n)
            {
                case ServerName.sigil:
                    return 1;
                case ServerName.torax:
                    return 2;
                case ServerName.fabar:
                    return 3;
                case ServerName.zimbob:
                    return 4;
                case ServerName.rancid:
                    return 5;
                case ServerName.quiver:
                    return 6;
            }
            return -1;
        }

        internal static ServerName IdToName(int id)
        {
            switch (id)
            {
                case 1:
                    return ServerName.sigil;
                case 2:
                    return ServerName.torax;
                case 3:
                    return ServerName.fabar;
                case 4:
                    return ServerName.zimbob;
                case 5:
                    return ServerName.rancid;
                case 6:
                    return ServerName.quiver;
            }
            throw new ArgumentException("No server name correlates with " + id);
        }

        internal static string IdToString(int id)
        {
            try
            {
                return NamesList[id - 1];
            }
            catch (Exception)
            {
                throw new ArgumentException("No server name correlates with " + id);
            }
        }
    }
}