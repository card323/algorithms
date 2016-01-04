using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_RemoveInvalidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            foreach (string s in p.RemoveInvalidParentheses("(n(f)()()"))//"(n(f)()()"
            {
                Console.WriteLine(s);
            }
        }

        public IList<string> RemoveInvalidParentheses(string s)
        {
            IList<string> result = RemoveInvalidParentheses2(Trim(s));

            return result;
        }

        private string Trim(string s)
        {
            StringBuilder sb = new StringBuilder();
            bool flag = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (!flag && s[i] == '(')
                    flag = true;
                if (flag || s[i] != ')')
                    sb.Append(s[i]);
            }
            s = sb.ToString();
            sb.Clear();
            flag = false;
            LinkedList<char> list = new LinkedList<char>();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (!flag && s[i] == ')')
                    flag = true;
                if (flag || s[i] != '(')
                    list.AddFirst(s[i]);
            }

            return new string(list.ToArray());
        }

        private IList<string> RemoveInvalidParentheses2(string s)
        {
            IList<string> list = new List<string>();
            int l = 0;

            int index = -1;
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == ')')
                    break;
                if(s[j]=='(')
                {
                    index = j;
                    while (++j < s.Length && s[j] == '(') ;
                    
                    for (int i = index; i < s.Length; i++)
                    {
                        if (s[i] == ')')
                        {
                            while (++i < s.Length && s[i] == ')') ;
                            l = Comp(list, l, Trim2(s.Substring(0, index)), RemoveInvalidParentheses(s.Substring(index + 1, i - 2 - index)), RemoveInvalidParentheses(s.Substring(i)));
                        }
                    }
                }
            }

            if (list.Count == 0)
                list.Add(s);
            return list;
        }

        private string Trim2(string p)
        {
            return p.Replace("(", "").Replace(")", "");
        }

        private int Comp(IList<string> result, int l, string prefix, IList<string> list1, IList<string> list2)
        {
            foreach (string r1 in list1)
            {
                foreach (string r2 in list2)
                {
                    if (prefix.Length + r1.Length + r2.Length + 2 > l)
                    {
                        l = prefix.Length + r1.Length + r2.Length + 2;
                        result.Clear();
                    }
                    if (prefix.Length + r1.Length + r2.Length + 2 < l)
                        continue;
                    result.Add(string.Concat(prefix, "(", r1, ")", r2));
                }
            }
            return l;
        }
    }
}
