using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffWaysToCompute
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            foreach (int i in p.DiffWaysToCompute("2-1-1"))
            {
                Console.WriteLine(i);
            }
        }

        public IList<int> DiffWaysToCompute(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new List<int>() { 0 };
            IList<int> list = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '+')
                    Comp(list, DiffWaysToCompute(input.Substring(0, i)), DiffWaysToCompute(input.Substring(i + 1)), (n1, n2) => n1 + n2);
                else if (c == '*')
                    Comp(list, DiffWaysToCompute(input.Substring(0, i)), DiffWaysToCompute(input.Substring(i + 1)), (n1, n2) => n1 * n2);
                else if (c == '-')
                    Comp(list, DiffWaysToCompute(input.Substring(0, i)), DiffWaysToCompute(input.Substring(i + 1)), (n1, n2) => n1 - n2);
            }
            if (list.Count == 0)
                list.Add(Convert.ToInt32(input));
            return list;
        }

        private void Comp(IList<int> list, IList<int> l1, IList<int> l2, Func<int, int, int> f)
        {
            foreach (int i in l1)
            {
                foreach (int j in l2)
                {
                    list.Add(f(i, j));
                }
            }
        }
    }
}
