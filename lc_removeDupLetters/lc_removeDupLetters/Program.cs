using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_removeDupLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.RemoveDuplicateLetters("cbacdcbc"));
            Console.WriteLine(p.RemoveDuplicateLetters(""));
            Console.WriteLine(p.RemoveDuplicateLetters("a"));
            Console.WriteLine(p.RemoveDuplicateLetters("abc"));
            Console.WriteLine(p.RemoveDuplicateLetters("caba"));
        }

        public string RemoveDuplicateLetters(string s)
        {
            StringBuilder sb = new StringBuilder();
            SortedDictionary<char, List<int>> dict = new SortedDictionary<char, List<int>>();
            int j = 0;
            foreach (char c in s)
            {
                List<int> list;
                if (!dict.TryGetValue(c, out list))
                {
                    dict.Add(c, list = new List<int>());
                }
                list.Add(j++);
            }

            SortedSet<int> set = new SortedSet<int>();
            foreach (var pair in dict)
            {
                set.Add(pair.Value[pair.Value.Count - 1]);
            }

            int pos = -1;
            char last = default(char);
            while (dict.Count > 0)
            {
                foreach (var pair in dict)
                {
                    int p = pair.Value[-1 * (pair.Value.BinarySearch(pos) + 1)];
                    if (p <= set.Min)
                    {
                        sb.Append(pair.Key);
                        pos = p;
                        last = pair.Key;
                        set.Remove(pair.Value[pair.Value.Count - 1]);
                        break;
                    }
                }
                dict.Remove(last);
            }


            return sb.ToString();

        }





    }
}
