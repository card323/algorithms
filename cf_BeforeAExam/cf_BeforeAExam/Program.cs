using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_BeforeAExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int day = Convert.ToInt32(inputs[0]);
            int time = Convert.ToInt32(inputs[1]);
            int[] mins = new int[day];
            int[] maxs = new int[day];
            for (int i = 0; i < day; i++)
            {
                string[] range = Console.ReadLine().Split(' ');
                mins[i] = Convert.ToInt32(range[0]);
                maxs[i] = Convert.ToInt32(range[1]);
            }
            int minSum = mins.Sum();
            int maxSum = maxs.Sum();
            if (minSum > time || maxSum < time)
            {
                Console.WriteLine("NO");
                return;
            }
            Console.WriteLine("YES");
            int[] results = new int[day];
            int delta = time - minSum;
            for (int i = 0; i < day; i++)
            {
                if (delta > maxs[i] - mins[i])
                {
                    results[i] = maxs[i];
                    delta -= maxs[i] - mins[i];
                }
                else if (delta == 0)
                {
                    results[i] = mins[i];
                }
                else
                {
                    results[i] = mins[i] + delta;
                    delta = 0;
                }
            }

            Console.WriteLine(string.Join(" ", results));
        }
    }
}
