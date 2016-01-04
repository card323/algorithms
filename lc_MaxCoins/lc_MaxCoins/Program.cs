using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_MaxCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.MaxCoins(new int[] { 3, 1, 1, 5, 8 }));
        }

        public int MaxCoins(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int[,] coins = new int[nums.Length, nums.Length];
            for (int s = 0; s < nums.Length; s++)
            {
                for (int i = 0; i < nums.Length - s; i++)
                {
                    if (s == 0)
                    {
                        coins[i, i + s] = GetCoin(nums, i) * GetCoin(nums, i + 1) * GetCoin(nums, i - 1);
                        continue;
                    }
                    int max = 0;
                    for (int j = i; j <= i + s; j++)
                    {
                        int left = i > j - 1 ? 0 : coins[i, j - 1];
                        int right = j + 1 > i + s ? 0 : coins[j + 1, i + s];
                        int coin = left + GetCoin(nums, i - 1) * nums[j] * GetCoin(nums, i + s + 1) + right;
                        if (max < coin)
                            max = coin;
                    }
                    coins[i, i + s] = max;
                }
            }
            return coins[0, nums.Length - 1];

        }

        private int GetCoin(int[] nums, int j)
        {
            if (j < 0 || j >= nums.Length)
                return 1;
            return nums[j];
        }



    }
}
