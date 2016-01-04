using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_LengthOfLIS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 4, 5 };
            Console.WriteLine(list.BinarySearch(3));

            Program p = new Program();
            Console.WriteLine(p.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
        }

        public int LengthOfLIS(int[] nums)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int pos;
                if ((pos = list.BinarySearch(nums[i])) >= 0)
                    continue;
                else
                {
                    pos = -pos - 1;
                    if (pos == list.Count)
                        list.Add(nums[i]);
                    else
                        list[pos] = nums[i];
                }
            }

            return list.Count;
        }
    }
}
