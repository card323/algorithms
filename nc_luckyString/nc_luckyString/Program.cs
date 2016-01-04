using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nc_luckyString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "nwlrbbmqbhcdarzowkkyhiddqscdxrjmowfrxsjybldbefsarcbynecdyggxxpklorellnmpapqfwkhopkmcoqhnwnkuewhsqmgb";
            // Console.ReadLine();
            SortedSet<string> set = new SortedSet<string>();
            int f1 = 0;
            int f2 = 1;
            for (int i = 0; ; i++)
            {
                int f = f1 + f2;
                if (f > str.Length)
                    break;
                AddAllSubString(str, f, set);
                f1 = f2;
                f2 = f;
            }

            foreach (string s in set)
                Console.WriteLine(s);
        }

        private static void AddAllSubString(string s, int f, SortedSet<string> set)
        {
            for (int i = 0; i < s.Length + 1 - f; i++)
            {
                var result = GetSub(s, f, i);
                foreach (string str in result)
                    set.Add(str);
            }
        }

        private static List<string> GetSub(string s, int f, int p)
        {
            List<string> result = new List<string>();
            HashSet<char> set = new HashSet<char>();
            int i = p;
            for (; set.Count <= f && i < s.Length; i++)
            {
                if (set.Count == f)
                    result.Add(s.Substring(p, i - p));
                set.Add(s[i]);
            }
            if (set.Count == f)
                result.Add(s.Substring(p, i - p));
            return result;
        }

    }
}
