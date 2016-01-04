using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_lca
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode n = new TreeNode(1);
            n.left = new TreeNode(0);
            n.right = new TreeNode(8);

            Program p = new Program();
            Console.WriteLine(p.LowestCommonAncestor(n, n.left, n.right).val);
        }
        bool pFound = false;
        bool qFound = false;
        TreeNode ancestor = null;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            if (!pFound && root == p)
            {
                if (qFound)
                    return ancestor;
                else
                {
                    pFound = true;
                    ancestor = p;
                }
            }

            if (!qFound && root == q)
            {
                if (pFound)
                    return ancestor;
                else
                {
                    qFound = true;
                    ancestor = q;
                }
            }
            stack.Push(root);
            TreeNode r;
            r = LowestCommonAncestor(root.left, p, q);
            if (r != null)
                return r;
            r = LowestCommonAncestor(root.right, p, q);
            if (r != null)
                return r;
            stack.Pop();
            if (root == ancestor)
                ancestor = stack.Peek();
            return null;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
