using System;
using System.Collections.Generic;

public class Graph
{
    private int Vertices; // Number of vertices
    private List<int>[] adjacencyList; // Adjacency list to store the graph

    // Constructor to initialize the graph
    public Graph(int vertices)
    {
        Vertices = vertices;
        adjacencyList = new List<int>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    // Method to add an edge to the graph
    public void AddEdge(int v, int w)
    {
        adjacencyList[v].Add(w); // Add w to v's list
    }

    // Method to perform BFS traversal from a given starting node
    public void BFS(int start)
    {
        // Mark all vertices as not visited
        bool[] visited = new bool[Vertices];

        // Create a queue for BFS
        Queue<int> queue = new Queue<int>();

        // Mark the starting node as visited and enqueue it
        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            // Dequeue a vertex from the queue and print it
            int currentVertex = queue.Dequeue();
            Console.Write(currentVertex + " ");

            // Get all adjacent vertices of the dequeued vertex
            // If an adjacent vertex has not been visited, mark it visited and enqueue it
            foreach (int adjacentVertex in adjacencyList[currentVertex])
            {
                if (!visited[adjacentVertex])
                {
                    visited[adjacentVertex] = true;
                    queue.Enqueue(adjacentVertex);
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a graph with 6 vertices
        Graph graph = new Graph(6);

        // Add edges to the graph
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 5);
        graph.AddEdge(4, 5);

        Console.WriteLine("BFS traversal starting from vertex 0:");

        // Perform BFS traversal starting from vertex 0
        graph.BFS(0);
    }
}
