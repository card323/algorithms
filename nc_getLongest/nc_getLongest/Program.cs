using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nc_getLongest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.getLongest(new string[] { "rb", "erb", "rbe", "e", "g", "mcxr" }, 6);
        }

        public int getLongest(string[] str, int n)
        {
            if (n == 0)
                return 0;

            HashSet<string> set = new HashSet<string>(str);
            int max = 1;
            foreach (string s in str)
            {
                set.Remove(s);
                if (getLongestInternal(set, s, 0))
                {
                    if (s.Length > max)
                        max = s.Length;
                }
                set.Add(s);
            }
            return max;
        }

        private bool getLongestInternal(HashSet<string> set, string s, int pos)
        {
            if (pos == s.Length)
                return true;

            for (int i = 1; i <= s.Length - pos; i++)
            {
                string head = s.Substring(pos, i);

                if (set.Contains(head))
                {
                    if (getLongestInternal(set, s, pos + i))
                        return true;
                }
            }
            return false;
        }

    }
}
