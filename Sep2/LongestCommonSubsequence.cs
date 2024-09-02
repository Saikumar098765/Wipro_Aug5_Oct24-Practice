using System;

class Program
{
    static void Main()
    {
        string A = "aabcdefghij";
        string B = "ecdgi";

        string lcs = FindLCS(A, B);
        Console.WriteLine("Longest Common Subsequence: " + lcs);
    }

    static string FindLCS(string A, string B)
    {
        int m = A.Length;
        int n = B.Length;

        // Create a 2D array to store the length of LCS
        int[,] dp = new int[m + 1, n + 1];

        // Build the dp array
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (A[i - 1] == B[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        // Traceback to find the LCS string
        int x = m, y = n;
        string lcs = "";
        while (x > 0 && y > 0)
        {
            if (A[x - 1] == B[y - 1])
            {
                lcs = A[x - 1] + lcs;
                x--;
                y--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
            {
                x--;
            }
            else
            {
                y--;
            }
        }

        return lcs;
    }
}
