/*Balanced Binary Tree Check
1. Create a tree with at least 10 items inside it then Write a function to check if a given binary tree is balanced. 
A balanced tree is one where the height of two subtrees of any node never differs by more than one.*/

using System;
namespace Binary1
{
    using System;

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public TreeNode Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

    
        public bool IsBalanced()
        {
            return CheckBalanced(Root) != -1;
        }

        private int CheckBalanced(TreeNode node)
        {
            if (node == null)
            {
                return 0; // An empty tree has height 0
            }

            int leftHeight = CheckBalanced(node.Left);
            int rightHeight = CheckBalanced(node.Right);

         
            if (leftHeight == -1 || rightHeight == -1 || Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1; 
            }

            return Math.Max(leftHeight, rightHeight) + 1; 
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a binary tree with at least 10 nodes
            BinaryTree tree = new BinaryTree();
            tree.Root = new TreeNode(1);
            tree.Root.Left = new TreeNode(2);
            tree.Root.Right = new TreeNode(3);
            tree.Root.Left.Left = new TreeNode(4);
            tree.Root.Left.Right = new TreeNode(5);
            tree.Root.Right.Left = new TreeNode(6);
            tree.Root.Right.Right = new TreeNode(7);
            tree.Root.Left.Left.Left = new TreeNode(8);
            tree.Root.Left.Left.Right = new TreeNode(9);
            tree.Root.Right.Right.Right = new TreeNode(10);

            
            bool isBalanced = tree.IsBalanced();
            Console.WriteLine("Tree Balance is : " + isBalanced);
        }
    }

}