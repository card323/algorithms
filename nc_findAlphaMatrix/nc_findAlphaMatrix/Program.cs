using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nc_findAlphaMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            var array = new string[50];
            for (int i = 0; i < array.Length; i++)
                array[i] = "aaaaaaaaaaaa";
            Console.WriteLine(p.findAlphaMatrix(array, array.Length));
        }

        public int findAlphaMatrix(string[] dic, int n)
        {
            if (n == 0)
                return 0;
            Dictionary<int, List<string>> all = new Dictionary<int, List<string>>();
            DicTree tree = new DicTree();

            foreach (string s in dic)
            {
                List<string> list;
                if (!all.TryGetValue(s.Length, out list))
                {
                    all.Add(s.Length, list = new List<string>());
                }
                list.Add(s);
                tree.Add(s, 0);
            }

            List<int> ls = new List<int>(all.Keys);
            ls.Sort();
            int max = 0;
            foreach (int i in ls.Reverse<int>())
            {
                if (max >= i * i)
                    break;

                List<string> candidates = all[i].ToList();
                DicTree[] initTrees = new DicTree[i];
                for (int j = 0; j < i; j++)
                    initTrees[j] = tree;
                findAlphaMatrixInternal(candidates, initTrees, 0);
                if (max2 * i > max)
                    max = max2 * i;

            }

            return max;
        }

        int max2 = 0;
        private int findAlphaMatrixInternal(List<string> candidates, DicTree[] initTrees, int size)
        {
            if (max2 >= candidates[0].Length)
                return 0;
            int r = size;
            for (int i = 0; i < candidates.Count; i++)
            {
                DicTree[] updatedTrees = initTrees.ToArray();
                if (findAlphaMatrixInternal(candidates[i], initTrees, updatedTrees))
                {
                    int result = findAlphaMatrixInternal(candidates, updatedTrees, size + 1);
                    if (updatedTrees.All(t => t.isLeaf))
                    {
                        if (result > max2)
                            max2 = result;
                    }
                }

            }
            return r;
        }

        private bool findAlphaMatrixInternal(string candidate, DicTree[] initTrees, DicTree[] updatedTrees)
        {
            for (int i = 0; i < candidate.Length; i++)
            {
                if (!initTrees[i].children.TryGetValue(candidate[i], out updatedTrees[i]))
                    return false;
            }
            return true;
        }
    }

    class DicTree
    {
        public bool isLeaf;
        public Dictionary<char, DicTree> children = new Dictionary<char, DicTree>();
        public void Add(string str, int pos)
        {
            if (pos == str.Length)
            {
                isLeaf = true;
                return;
            }
            DicTree child;
            if (!children.TryGetValue(str[pos], out child))
            {
                children.Add(str[pos], child = new DicTree());
            }
            child.Add(str, pos + 1);
        }
    }
}
