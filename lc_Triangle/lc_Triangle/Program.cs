using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> triangle = new List<IList<int>>() 
            { 
                new List<int>{2},
                new List<int>{3,4},
                new List<int>{6,5,7},
                new List<int>{4,1,8,3}
            };

            Program p = new Program();
            Console.WriteLine(p.MinimumTotal(triangle));
        }

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 0)
                return 0;

            int[] cost = new int[triangle.Count];

            for (int i = 0; i < cost.Length; i++)
            {
                cost[i] = int.MaxValue;
            }
            for (int i = 0; i < triangle.Count; i++)
            {
                for (int j = triangle[i].Count - 1; j >= 0; j--)
                {
                    if (i == 0 && j == 0)
                        cost[j] = triangle[i][j];
                    else if (j == 0)
                    {
                        cost[j] += triangle[i][j];
                    }
                    else
                    {
                        cost[j] = Math.Min(cost[j], cost[j - 1]) + triangle[i][j];
                    }
                }
            }


            return cost.Min();
        }
    }
}
