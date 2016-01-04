using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_NumMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[4, 5] {
            {3, 0, 1, 4, 2},
            {5, 6, 3, 2, 1},
            {1, 2, 0, 1, 5},
            {4, 1, 0, 1, 7},
        };
            NumMatrix m = new NumMatrix(matrix);
            Console.WriteLine(m.SumRegion(1, 1, 2, 2));
            Console.WriteLine(matrix.GetLength(0));
        }

        public class NumMatrix
        {
            int[,] sums;
            public NumMatrix(int[,] matrix)
            {
                int l0 = matrix.GetLength(0);
                int l1 = matrix.GetLength(1);
                sums = new int[l0, l1];
                for (int i = 0; i < l0; i++)
                {
                    for (int j = 0; j < l1; j++)
                    {
                        int i1 = i == 0 ? 0 : sums[i - 1, j];
                        int i2 = j == 0 ? 0 : sums[i, j - 1];
                        int i3 = i == 0 || j == 0 ? 0 : sums[i - 1, j - 1];
                        sums[i, j] = i1 + i2 - i3 + matrix[i, j];
                    }
                }
            }


            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                int i1 = row1 == 0 ? 0 : sums[row1 - 1, col2];
                int i2 = col1 == 0 ? 0 : sums[row2, col1 - 1];
                int i3 = row1 == 0 || col1 == 0 ? 0 : sums[row1 - 1, col1 - 1];
                return sums[row2, col2] - i1 - i2 + i3;
            }
        }

    }
}
