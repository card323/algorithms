using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_FractionToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.FractionToDecimal(1, 90));
            Console.WriteLine(p.FractionToDecimal(1, 17));
            Console.WriteLine(p.FractionToDecimal(10, 17));
            Console.WriteLine(p.FractionToDecimal(1, 6));
            Console.WriteLine(p.FractionToDecimal(1, 7));
            Console.WriteLine(p.FractionToDecimal(10,7));
            Console.WriteLine(p.FractionToDecimal(100, 7));
            Console.WriteLine(p.FractionToDecimal(1000, 7));
        }

        public string FractionToDecimal(int numerator, int denominator)
        {
            return FractionToDecimalInternal((long)numerator, (long)denominator);
        }
        public string FractionToDecimalInternal(long numerator, long denominator)
        {
            if (numerator == 0)
                return "0";
            bool neg = numerator >= 0 ^ denominator >= 0;
            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);
            Dictionary<long, int> dict = new Dictionary<long, int>();
            List<long> list = new List<long>();
            int index = 0;

            int negPos = -1;
            while (true)
            {
                long ys = 0;
                long result = numerator / denominator;
                list.Add(result);
                if ((ys = numerator % denominator) != 0)
                {
                    int pos = -1;
                    if (dict.TryGetValue(ys, out pos))
                    {
                        return GetResult(list, pos, negPos, neg);
                    }

                    numerator = ys;
                    numerator *= 10;
                    index++;

                    dict.Add(ys, index);

                    if (negPos == -1)
                        negPos = index;
                }
                else
                {
                    return GetResult(list, -1, negPos, neg);
                }

            }
        }

        private string GetResult(List<long> list, int pos, int negPos, bool neg)
        {
            StringBuilder sb = new StringBuilder();
            if (neg)
                sb.Append('-');
            for (int i = 0; i < list.Count; i++)
            {
                if (i == negPos)
                    sb.Append('.');
                if (i == pos)
                    sb.Append('(');
                sb.Append(list[i]);


            }
            if (pos >= 0)
                sb.Append(')');
            return sb.ToString();
        }
    }
}
