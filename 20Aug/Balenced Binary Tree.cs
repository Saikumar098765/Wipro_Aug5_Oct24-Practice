/*Task 1: Balanced Binary Tree Check Write a function to check if a given binary tree is balanced. A balanced tree is 
        one where the height of two subtrees of any node never differs by more than one.

Sol 1 : 
*/
using System;

public class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinaryTree
{
    public TreeNode Root;

    public bool IsBalanced(TreeNode node)
    {
        return CheckHeight(node) != -1;
    }

    private int CheckHeight(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftHeight = CheckHeight(node.Left);
        if (leftHeight == -1) return -1;

        int rightHeight = CheckHeight(node.Right);
        if (rightHeight == -1) return -1;

        if (Math.Abs(leftHeight - rightHeight) > 1)
        {
            return -1;
        }
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        tree.Root = new TreeNode(1);
        tree.Root.Left = new TreeNode(2);
        tree.Root.Right = new TreeNode(3);
        tree.Root.Left.Left = new TreeNode(4);
        tree.Root.Left.Right = new TreeNode(5);
        tree.Root.Left.Left.Left = new TreeNode(6);

        bool isBalanced = tree.IsBalanced(tree.Root);
        Console.WriteLine("Is the tree balanced? " + isBalanced);
    }
}
