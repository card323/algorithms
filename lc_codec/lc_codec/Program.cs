using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_codec
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            TreeNode node = new TreeNode(-1) { left = new TreeNode(-2), right = new TreeNode(-3) };
            Console.WriteLine(p.serialize(node));
            node = p.deserialize(p.serialize(node));
        }

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            serializeInternal(sb, root);
            return sb.ToString();
        }

        private void serializeInternal(StringBuilder sb, TreeNode root)
        {
            if (root == null)
                return;
            sb.Append('(');
            sb.Append(root.val);
            sb.Append(',');
            serializeInternal(sb, root.left);
            sb.Append(',');
            serializeInternal(sb, root.right);
            sb.Append(')');
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            int pos = 0;
            return deserializeInternal(data, 0, out pos);
        }

        private TreeNode deserializeInternal(string data, int start, out int i)
        {
            TreeNode node = null;
            int count = 0;
            bool rightFlag = false;
            bool neg = false;
            i = start;
            while (++i < data.Length)
            {
                if (data[i] == ')')
                {
                    break;
                }
                else if (data[i] == ',')
                {
                    if (node == null)
                        node = new TreeNode(neg ? -count : count);
                    else
                        rightFlag = true;
                }
                else if (data[i] == '(')
                {
                    if (rightFlag)
                        node.right = deserializeInternal(data, i, out i);
                    else
                        node.left = deserializeInternal(data, i, out i);
                }
                else if (data[i] == '-')
                {
                    neg = true;
                }
                else
                {
                    int n = data[i] - '0';
                    count = 10 * count + n;
                }
            }
            return node;
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
