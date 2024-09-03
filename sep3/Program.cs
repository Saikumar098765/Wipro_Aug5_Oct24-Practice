using System;

class OptimalBST
{
  
    static int Sum(int[] freq, int i, int j)
    {
        int sum = 0;
        for (int k = i; k <= j; k++)
        {
            sum = sum + freq[k];
        }
        return sum;
    }

   
    static int OptimalSearchTree(int[] keys, int[] freq, int n)
    {
        
        int[,] cost = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            cost[i, i] = freq[i];
        }

        for (int l = 2; l <= n; l++)
        {
            for (int i = 0; i <= n - l; i++)
            {
                int j = i + l - 1;
                cost[i, j] = int.MaxValue;

                for (int r = i; r <= j; r++)
                {
                    
                    int c = (r > i ? cost[i, r - 1] : 0) + (r < j ? cost[r + 1, j] : 0) + Sum(freq, i, j);

                    
                    if (c < cost[i, j])
                    {
                        cost[i, j] = c;
                    }
                }
            }
        }

        return cost[0, n - 1];
    }

    public static void Main()
    {
        int[] keys = { 10, 20, 30, 40 };
        int[] freq = { 4, 2, 6, 3 };
        int n = keys.Length;

        int minCost = OptimalSearchTree(keys, freq, n);
        Console.WriteLine("Cost of Optimal Binary Search Tree : " + minCost);
    }
}
