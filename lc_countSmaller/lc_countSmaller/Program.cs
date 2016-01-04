using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_countSmaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            foreach (int i in p.CountSmaller(new int[] { -1, -1 }))
            {
                Console.WriteLine(i);
            }
        }

        public IList<int> CountSmaller(int[] nums)
        {
            int[] result = new int[nums.Length];
            SortedDictionary<int, List<int>> dict = new SortedDictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                List<int> l;
                if (!dict.TryGetValue(nums[i], out l))
                {
                    dict.Add(nums[i], l = new List<int>());
                }
                l.Add(i);
            }
            SegmentTree tree = new SegmentTree(0, nums.Length - 1);
            foreach (var pair in dict)
            {
                foreach (int pos in pair.Value)
                {
                    result[pos] = tree.CountRange(pos + 1, nums.Length - 1);
                }
                foreach (int pos in pair.Value)
                {
                    tree.Add(pos);
                }
            }
            return result.ToList();
        }

        class SegmentTree
        {
            public int count;
            public SegmentTree left;
            public SegmentTree right;
            public int s;
            public int e;

            public SegmentTree(int l, int r)
            {
                s = l;
                e = r;
                if (e > s)
                {
                    int m = s + (e - s) / 2;
                    left = new SegmentTree(s, m);
                    right = new SegmentTree(m + 1, e);
                }
            }

            public void Add(int p)
            {
                if (p <= e && p >= s)
                {
                    count++;
                    if (left != null)
                        left.Add(p);
                    if (right != null)
                        right.Add(p);
                }
            }

            public int CountRange(int l, int r)
            {
                if (l > r || l > e || r < s || count == 0)
                    return 0;
                if (l < s)
                    l = s;
                if (r > e)
                    r = e;
                if (l == s && r == e)
                    return count;
                return left.CountRange(l, r) + right.CountRange(l, r);
            }
        }
    }


}
