using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_NumArray
{
    class NumArray
    {
        static void Main(string[] args)
        {
            NumArray array = new NumArray(new int[] {7,2,7,2,0 });
            array.Update(4, 6); 
            array.Update(0, 2); 
            array.Update(0, 9); 
            Console.WriteLine( array.SumRange(4, 4));
            array.Update(3, 8); 
            Console.WriteLine(       array.SumRange(0, 4));
            array.Update(4, 1); 
         Console.WriteLine(          array.SumRange(0, 3));
          Console.WriteLine(         array.SumRange(0, 4)); 
            array.Update(0, 4);


        }

        Node root;
        int[] numbers;
        public NumArray(int[] nums)
        {
            root = Node.CreateRoot(0, nums.Length - 1, nums);
            numbers = nums;
        }

        public void Update(int i, int val)
        {
            if (root == null)
                return;
            int delta = val - numbers[i];
            numbers[i] = val;
            root.Update(i, delta);
        }

        public int SumRange(int i, int j)
        {
            if (root == null)
                return 0;
            return root.SumRange(i, j);
        }

        class Node
        {
            int start;
            int end;
            int sum;
            Node l;
            Node r;

            public Node(int s, int e, int v)
            {
                start = s;
                end = e;
                sum = v;
            }

            internal int SumRange(int i, int j)
            {
                if (start == end || i == start && j == end)
                    return sum;
                if (j <= l.end)
                {
                    return l.SumRange(i, j);
                }

                if (i >= r.start)
                {
                    return r.SumRange(i, j);
                }

                return l.SumRange(i, l.end) + r.SumRange(r.start, j);
            }

            internal static Node CreateRoot(int s, int e, int[] nums)
            {
                if (nums == null || nums.Length == 0)
                    return null;
                Node n = new Node(s, e, nums[s]);
                if (s == e)
                    return n;
                int mid = s + (e - s) / 2;
                n.l = CreateRoot(s, mid, nums);
                n.r = CreateRoot(mid + 1, e, nums);
                n.sum = n.l.sum + n.r.sum;
                return n;
            }

            internal void Update(int i, int delta)
            {
                if (delta == 0)
                    return;
                sum += delta;
                if (start == end)
                    return;
                if (i <= l.end)
                    l.Update(i, delta);
                if (i >= r.start)
                    r.Update(i, delta);
            }
        }
    }
}
