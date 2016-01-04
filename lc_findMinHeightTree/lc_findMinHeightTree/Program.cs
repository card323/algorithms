using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_findMinHeightTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //n = 6, edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]
            Program p = new Program();
            foreach (int i in p.FindMinHeightTrees(6, new int[,] { { 0, 3 }, { 0, 1 }, { 0, 2}, { 4, 3 }, { 5, 4 } }))
            {
                Console.WriteLine(i);
            }
            foreach (int i in p.FindMinHeightTrees(4, new int[,] { { 1, 0 }, { 1, 2 }, { 1, 3 } }))
            {
                Console.WriteLine(i);
            }
            foreach (int i in p.FindMinHeightTrees(3, new int[,] { { 1, 0 }, { 1, 2 } }))
            {
                Console.WriteLine(i);
            }


        }

        public IList<int> FindMinHeightTrees(int n, int[,] edges)
        {
            List<int> l = new List<int>();
            if (n <= 2)
            {
                for (int i = 0; i < n; i++)
                    l.Add(i);
                return l;
            }
            List<int[]> edgeList = new List<int[]>();

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                edgeList.Add(new int[] { edges[i, 0], edges[i, 1] });
            }
            HashSet<int> ps = new HashSet<int>();
            int[] dushu = new int[n];
            List<int[]> temp = new List<int[]>();
            while (true)
            {
                ps.Clear();
                for (int i = 0; i < n; i++)
                {
                    dushu[i] = 0;
                }
                foreach (int[] e in edgeList)
                {
                    dushu[e[0]]++;
                    dushu[e[1]]++;
                }

                temp.Clear();
                foreach (int[] e in edgeList)
                {
                    if (dushu[e[0]] > 1 && dushu[e[1]] > 1)
                        temp.Add(e);
                    if (dushu[e[0]] > 1)
                        ps.Add(e[0]);
                    if (dushu[e[1]] > 1)
                        ps.Add(e[1]);
                }
                var t = edgeList;
                edgeList = temp;
                temp = t;
                if (ps.Count <= 2)
                    break;
            }

            return ps.ToList();
        }
    }
}
