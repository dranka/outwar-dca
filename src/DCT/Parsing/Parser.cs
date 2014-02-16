using System;

namespace DCT.Parsing
{
    internal class Parser
    {
        internal const string ERR_CONST = "ERROR";
        internal string String { get; set; }

        internal Parser(string whole)
        {
            String = whole;
        }

        internal int Count(string sub)
        {
            return Count(String, sub);
        }

        internal static int Count(string whole, string sub)
        {
            int ret = 0;
            while (whole.IndexOf(sub) != -1)
            {
                ret++;
                whole = CutLeading(whole, sub);
            }
            return ret;
        }

        internal void CutLeading(string sub)
        {
            String = CutLeading(String, sub);
        }

        internal static string CutLeading(string whole, string cutoff)
        {
            try
            {
                return whole.Substring(whole.IndexOf(cutoff) + cutoff.Length);
            }
            catch (ArgumentOutOfRangeException)
            {
                return ERR_CONST;
            }
        }

        internal void CutTrailing(string cutoff)
        {
            String = CutTrailing(String, cutoff);
        }

        internal static string CutTrailing(string whole, string cutoff)
        {
            try
            {
                return whole.Substring(0, whole.IndexOf(cutoff));

            }
            catch (Exception Ex)
            {
                if (Ex is StackOverflowException || Ex is ArgumentOutOfRangeException)
                {
                return ERR_CONST;
                }
                else
                {
                return ERR_CONST;
                }

            }
        }

        internal void RemoveRange(string start, string end)
        {
            String = RemoveRange(String, start, end);
        }

        internal static string RemoveRange(string whole, string start, string end)
        {
            try
            {
                foreach (string t in MultiParse(whole, start, end))
                {
                    whole = whole.Replace(start + t + end, "");
                }
                return whole;
            }
            catch (ArgumentOutOfRangeException)
            {
                return ERR_CONST;
            }
        }

        internal string Parse(string start, string end)
        {
            return Parse(String, start, end);
        }

        internal static string Parse(string whole, string start, string end)
        {
            //System.Text.RegularExpressions.Match m = (new System.Text.RegularExpressions.Regex(start + "(*+)" + end, System.Text.RegularExpressions.RegexOptions.Compiled)).Match(whole);
            //return m.Success ? m.Value : ERR_CONST;
            try
            {
                return CutTrailing(CutLeading(whole, start), end);
            }
            catch (ArgumentOutOfRangeException)
            {
                return ERR_CONST;
            }
        }

        internal string[] MultiParse(string start, string end)
        {
            return MultiParse(String, start, end);
        }

        internal static string[] MultiParse(string whole, string start, string end)
        {
            try
            {
                string[] tokens = whole.Split(new string[] {start}, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 1)
                {
                    return new string[] { };
                }
                string[] ret = new string[tokens.Length];

                for (int i = 0; i < tokens.Length; i++)
                {
                    ret[i] = CutTrailing(tokens[i], end);
                }

                return ret;
            }
            catch (ArgumentOutOfRangeException)
            {
                return new string[] {ERR_CONST};
            }
        }
    }
}