using System;
using System.Collections.Generic;
namespace Symmetric_Tree
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left, right;
            public TreeNode(int val = 0)
            {
                this.val = val;
                left = right = null;
            }
        }
        static void Main(string[] args)
        {
            TreeNode node = new TreeNode(1);
            node.left = new TreeNode(2);
            node.right = new TreeNode(2);
            //node.left.left = new TreeNode(3);
            //node.left.right= new TreeNode(4);
            //node.right.left = new TreeNode(4);
            //node.right.right = new TreeNode(3);
            node.left.left = new TreeNode(3);
            node.right.right = new TreeNode(3);
            Console.WriteLine(IsSymmetric_Rec(node, node));
        }

        static bool IsSymmetric(TreeNode node)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(node);
            q.Enqueue(node);
            while (q.Count > 0)
            {
                TreeNode t1 = q.Dequeue();
                TreeNode t2 = q.Dequeue();
                if (t1 == null && t2 == null) continue;
                else if (t1 == null || t2 == null) return false;
                else if (t1.val != t2.val) return false;
                q.Enqueue(t1.left);
                q.Enqueue(t2.right);

                q.Enqueue(t1.right);
                q.Enqueue(t2.left);
            }

            return true;
        }

        static bool IsSymmetric_Rec(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1 == null || root2 == null) return false;
            bool leftsame = IsSymmetric_Rec(root1.left, root2.right);
            bool rightsame = IsSymmetric_Rec(root1.right, root2.left);
            return (root1.val == root2.val 
                && leftsame
                && rightsame);
        }
    }
}
