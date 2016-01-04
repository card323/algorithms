using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.FindDuplicate(new int[] { 1,2,3,3,5,4}));
        }

        public int FindDuplicate(int[] nums)
        {
            for(int i =0;i<nums.Length;i++)
            {
                int m = nums[i];
                if (nums[Math.Abs(m) - 1] < 0)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        nums[j] = Math.Abs(nums[j]);
                    }
                    return Math.Abs(m);
                }
                nums[Math.Abs(m) - 1] *= -1;
            }
            return -1;
        }
    }
}
