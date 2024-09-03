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
    
    private int CheckHeight(TreeNode node)
    {
        
        if (node == null)
        {
            return 0;
        }

      
        int leftHeight = CheckHeight(node.Left);
        int rightHeight = CheckHeight(node.Right);

      
        if (leftHeight == -1 || rightHeight == -1)
        {
            return -1;
        }


        if (Math.Abs(leftHeight - rightHeight) > 1)
        {
            return -1; 
        }

     
        return Math.Max(leftHeight, rightHeight) + 1;
    }

   
    public bool IsBalanced(TreeNode root)
    {
        return CheckHeight(root) != -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Right.Right = new TreeNode(6);

        BinaryTree tree = new BinaryTree();
        Console.WriteLine(tree.IsBalanced(root) ? "The tree is balanced." : "The tree is not balanced.");

        // Creating an unbalanced binary tree
        root.Left.Left.Left = new TreeNode(7);
        Console.WriteLine(tree.IsBalanced(root) ? "The tree is balanced." : "The tree is not balanced.");
    }
}
