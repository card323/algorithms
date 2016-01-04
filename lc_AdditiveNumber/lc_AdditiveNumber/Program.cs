using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_AdditiveNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add("523456", "523456"));
            Program p = new Program();
            //Console.WriteLine(p.IsAdditiveNumber("199100199"));
            Console.WriteLine(p.IsAdditiveNumber("123"));
            Console.WriteLine(p.IsAdditiveNumber("10120121141"));
        }

        public bool IsAdditiveNumber(string num)
        {
            int l = num.Length / 3;
            for (int i = 1; i <= l; i++)
            {
                if (IsAdditiveNumberInternal(num.Substring(0, i), num.Substring(i)))
                    return true;
            }

            return false;
        }

        private bool IsAdditiveNumberInternal(string n1, string rest)
        {
            int l = rest.Length / 2;
            for (int i = 1; i <= l; i++)
            {
                string n2 = rest.Substring(0, i);
                string sum = Add(n1, n2);
                string temp = rest.Substring(n2.Length);
                while (temp.Length > 0 && temp.StartsWith(sum))
                {
                    temp = temp.Substring(sum.Length);
                    string updated = Add(n2, sum);
                    n2 = sum;
                    sum = updated;
                }
                if (temp.Length == 0)
                    return true;
            }
            return false;
        }


        public static string Add(string n1, string n2)
        {
            int jw = 0;
            LinkedList<char> list = new LinkedList<char>();
            int l = Math.Max(n1.Length, n2.Length);
            for (int i = 0; i < l; i++)
            {
                int i2;
                int i1;
                if (i >= n2.Length)
                    i2 = 0;
                else
                    i2 = n2[n2.Length - 1 - i] - '0';
                if (i >= n1.Length)
                    i1 = 0;
                else
                    i1 = n1[n1.Length - 1 - i] - '0';
                int sum = i1 + i2 + jw;
                if (sum >= 10)
                    jw = 1;
                else
                    jw = 0;

                list.AddFirst((char)(sum % 10 + '0'));
            }
            if (jw > 0)
                list.AddFirst('1');
            return new string(list.ToArray());
        }
    }

}
