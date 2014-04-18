namespace DCT.Security
{
    static internal class Version
    {
        internal const string Id = "3.2";
        internal const string mini = "0";
        internal const string beta = "";

        internal static string Full
        {
            get { return string.Format("{0}.{1}", Id, mini); }
        }

        internal static string Beta
        {
            get { return beta; }
        }
    }
}