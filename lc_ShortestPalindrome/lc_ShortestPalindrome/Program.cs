using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_ShortestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            Console.WriteLine(p.ShortestPalindrome("baababaabab"));
        }

        string preProcess(string s)
        {
            StringBuilder sb = new StringBuilder();

            int n = s.Length;
            if (n == 0) return "^$";
            sb.Append('^');

            for (int i = 0; i < n; i++)
            {
                sb.Append("#");
                sb.Append(s[i]);
            }
            sb.Append("#$");
         
            return sb.ToString();
        }

        public string ShortestPalindrome(string s)
        {
            string T = preProcess(s);
            int n = T.Length;
            int[] P = new int[n];
            int C = 0, R = 0;
            for (int i = 1; i < n - 1; i++)
            {
                int i_mirror = 2 * C - i; // equals to i' = C - (i-C)

                P[i] = (R > i) ? Math.Min(R - i, P[i_mirror]) : 0;

                // Attempt to expand palindrome centered at i
                while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
                    P[i]++;

                // If palindrome centered at i expand past R,
                // adjust center based on expanded palindrome.
                if (i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }

            // Find the maximum element in P.
            int maxLen = 0;
            int centerIndex = 0;
            for (int i = 1; i < n - 1; i++)
            {
                if (P[i] >= i - 1 && P[i] > maxLen)
                {
                    maxLen = P[i];
                    centerIndex = i;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= maxLen; i--)
            {
                sb.Append(s[i]);
            }
            sb.Append(s);
            return sb.ToString();
        }
    }
}
