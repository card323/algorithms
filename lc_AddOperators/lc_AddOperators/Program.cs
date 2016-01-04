//#define LC_DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lc_AddOperators
{
    /// <summary>
    /// "123", 6 -> ["1+2+3", "1*2*3"] 
    /// "232", 8 -> ["2*3+2", "2+3*2"]
    /// "105", 5 -> ["1*0+5","10-5"]
    /// "00", 0 -> ["0+0", "0-0", "0*0"]
    /// "3456237490", 9191 -> []
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //printStrings(p.AddOperators("123456789", 45));
            Stopwatch w = new Stopwatch();
            w.Start();
            for (int i = 0; i < 100; i++)
            {
                p.AddOperators("123456789", 45);
                p.AddOperators("1000000009", 9);
            }
            w.Stop();
            Console.WriteLine(w.ElapsedMilliseconds);
            //printStrings();
            //printStrings(p.AddOperators("000", 0));
            //printStrings(p.AddOperators("123", 6));
            //printStrings(p.AddOperators("232", 8));
            //printStrings(p.AddOperators("105", 5));
            //printStrings(p.AddOperators("00", 0));
            //printStrings(p.AddOperators("3456237490", 9191));
            //printStrings(p.AddOperators("5230", 300));
            //printStrings(p.AddOperators("", 300));

        }
        static void printStrings(IEnumerable<string> strs)
        {
            foreach (string s in strs)
            {
                Console.WriteLine(s);
            }
        }

        IList<string> finalResults = new List<string>();
        string numCopy;
        public IList<string> AddOperators(string num, int target)
        {
            if (num.Length == 0)
                return new List<string>();
            finalResults.Clear();
            numCopy = num;
            List<string> iList = num.Select(c => c.ToString()).ToList();
            char[] results = new char[num.Length - 1];
            AddOperatorsInternal(iList, target, results, 0, 1);
            return finalResults;

        }

        private void AddOperatorsInternal(List<string> list, int target, char[] results, int index, int mul)
        {
            if (list.Count == 1)
            {
                if (target == Convert.ToInt32(list[0]) * mul && (list[0].Length == 1 || list[0][0] != '0'))
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < numCopy.Length; i++)
                    {
                        sb.Append(numCopy[i]);
                        if (i != numCopy.Length - 1 && results[numCopy.Length - 2 - i] != ' ')
                            sb.Append(results[numCopy.Length - 2 - i]);
                    }
                    finalResults.Add(sb.ToString());
                }

                return;
            }

            string tailStr = list.Last();
            int tail = Convert.ToInt32(tailStr);
            list.RemoveAt(list.Count - 1);
            if (tailStr.Length > 1 && tailStr[0] == '0')
                goto CMB;

            results[index++] = '+';
            AddOperatorsInternal(list, target - tail * mul, results, index, 1);
            index--;

            results[index++] = '-';
            AddOperatorsInternal(list, target + tail * mul, results, index, 1);
            index--;

            results[index++] = '*';
            AddOperatorsInternal(list, target, results, index, mul * tail);
            index--;

        CMB:
            string last = list.Last();

            results[index++] = ' ';
            list[list.Count - 1] = last + tailStr;
            AddOperatorsInternal(list, target, results, index, mul);
            list[list.Count - 1] = last;
            index--;

            list.Add(tailStr);
        }

    }
}
