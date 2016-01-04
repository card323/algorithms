using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_3d
{
    class Program
    {
        static SortedSet<Ele> mset = new SortedSet<Ele>(new EleComparer());

        static void Main(string[] args)
        {
            NewMethod(ReadLine);
        }

        static string[] input = new string[] { "(?(?(??)", "1 2", "2 8", "1 5", "3 6" };
           
        
        static int i = 0;

        private static string ReadLine()
        {
            return input[i++];
        }

        private static void NewMethod(Func<string> readLine)
        {
            string str = readLine();
            char[] s = str.ToArray();
            int size = 0;

            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (s[i] == '?')
                {
                    size++;
                    int left, right;
                    string[] items = readLine().Split(' ');
                    left = Convert.ToInt32(items[0]);
                    right = Convert.ToInt32(items[1]);

                    Ele e = new Ele();
                    e.left = left;
                    e.right = right;
                    e.pos = i;
                    mset.Add(e);
                }
            }

            if (i % 2 == 1 || !isValid(s, true) || !isValid(s, false))
            {
                Console.Write(-1);
                return;
            }

            foreach (Ele e in mset)
            {
                if (e.left < e.right)
                {
                    s[e.pos] = '(';
                    if (!isValid(s, false))
                        s[e.pos] = ')';
                }
                else
                {
                    s[e.pos] = ')';
                    if (!isValid(s, true))
                        s[e.pos] = '(';
                }
            }

            Console.WriteLine(GetResult(s, mset));
            Console.Write(new string(s));

            return;
        }

        private static int GetResult(char[] s, SortedSet<Ele> mset)
        {
            int result = 0;
            foreach (Ele e in mset)
            {
                if (s[e.pos] == '(')
                    result += e.left;
                else
                    result += e.right;
            }
            return result;
        }

        static bool isValid(char[] s, bool fromLeft)
        {
            int n = 0;
            int m = 0;
            int i;
            int last = -1;
            if (fromLeft)
            {
                for (i = 0; i < s.Length; i++)
                {
                    switch (s[i])
                    {
                        case '(':
                            n++;
                            break;
                        case ')':
                            n--;
                            if (m + n < 0)
                                return false;
                            if (m == 1 && n == 0)
                            {
                                s[last] = '(';

                                m--;
                                n++;
                            }
                            break;
                        case '?':
                            last = i;
                            m++;
                            break;
                    }
                }
            }
            else
            {
                n = 0;
                m = 0;
                last = -1;
                for (i = s.Length - 1; i >= 0; i--)
                {
                    switch (s[i])
                    {
                        case '(':
                            n--;
                            if (m + n < 0)
                                return false;
                            if (m == 1 && n == 0)
                            {
                                s[last] = ')';

                                m--;
                                n++;
                            }
                            break;
                        case ')': 
                            n++;
                            break;
                        case '?':
                            last = i;
                            m++;
                            break;
                    }
                }
            }
            return true;
        }
    }


    class Ele
    {
        public int left;
        public int right;
        public int pos;
    }

    class EleComparer : IComparer<Ele>
    {
        public int Compare(Ele e1, Ele e2)
        {
            return Math.Abs(e2.left - e2.right) - Math.Abs(e1.left - e1.right);
        }
    }
}
