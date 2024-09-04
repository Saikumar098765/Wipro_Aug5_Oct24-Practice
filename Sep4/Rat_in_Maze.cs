using System;

class RatInMaze
{
    
    static int N = 4;
    static void PrintSolution(int[,] solution)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(solution[i, j] + " ");
            Console.WriteLine();
        }
    }

    static bool IsSafe(int[,] maze, int x, int y)
    {
      
        return (x >= 0 && x < N && y >= 0 && y < N && maze[x, y] == 1);
    }

    
    static bool SolveMaze(int[,] maze)
    {
        int[,] solution = new int[N, N];

        
        if (!SolveMazeUtil(maze, 0, 0, solution))
        {
            Console.WriteLine("No solution found.");
            return false;
        }

        PrintSolution(solution);
        return true;
    }

    static bool SolveMazeUtil(int[,] maze, int x, int y, int[,] solution)
    {
        
        if (x == N - 1 && y == N - 1 && maze[x, y] == 1)
        {
            solution[x, y] = 1;
            return true;
        }

        if (IsSafe(maze, x, y))
        {
           
            solution[x, y] = 1;

           
            if (SolveMazeUtil(maze, x + 1, y, solution))
                return true;

            if (SolveMazeUtil(maze, x, y + 1, solution))
                return true;
            solution[x, y] = 0;
            return false;
        }

        return false;
    }

    static void Main()
    {
      
        int[,] maze = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 1, 1, 0, 0 },
            { 0, 1, 1, 1 }
        };
        Console.WriteLine("Rat in a Maze : ");

        SolveMaze(maze);
    }
}
