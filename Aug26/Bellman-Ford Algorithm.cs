using System;
using System.Collections.Generic;

public class Edge1
{
    public int Source { get; set; }
    public int Destination { get; set; }
    public int Weight { get; set; }

    public Edge1(int source, int destination, int weight)
    {
        Source = source;
        Destination = destination;
        Weight = weight;
    }
}

public class BellmanFordAlgorithm
{
    public bool FindShortestPaths1(int vertices, List<Edge> edges, int source)
    {
        // Initialize distances from source to all other vertices as infinite
        int[] distances = new int[vertices];
        for (int i = 0; i < vertices; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[source] = 0;

        // Relax all edges |V| - 1 times
        for (int i = 0; i < vertices - 1; i++)
        {
            foreach (var edge in edges)
            {
                if (distances[edge.Source] != int.MaxValue &&
                    distances[edge.Source] + edge.Weight < distances[edge.Destination])
                {
                    distances[edge.Destination] = distances[edge.Source] + edge.Weight;
                }
            }
        }

        // Check for negative-weight cycles
        foreach (var edge in edges)
        {
            if (distances[edge.Source] != int.MaxValue &&
                distances[edge.Source] + edge.Weight < distances[edge.Destination])
            {
                Console.WriteLine("Graph contains a negative-weight cycle.");
                return false; // Negative cycle detected
            }
        }

        // Print distances from source
        PrintDistances(distances, source);
        return true;
    }

    private void PrintDistances(int[] distances, int source)
    {
        Console.WriteLine($"Vertex distances from source {source}:");
        for (int i = 0; i < distances.Length; i++)
        {
            Console.WriteLine($"Vertex {i} - Distance: {(distances[i] == int.MaxValue ? "Infinity" : distances[i].ToString())}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int vertices = 5;
        List<Edge1> edges = new List<Edge1>
        {
            new Edge1(0, 1, -1),
            new Edge1(0, 2, 4),
            new Edge1(1, 2, 3),
            new Edge1(1, 3, 2),
            new Edge1(1, 4, 2),
            new Edge1(3, 2, 5),
            new Edge1(3, 1, 1),
            new Edge1(4, 3, -3)
        };

        BellmanFordAlgorithm bellmanFord = new BellmanFordAlgorithm();
        int source = 0;

        if (bellmanFord.FindShortestPaths1(vertices, edges, source))
        {
            Console.WriteLine("Shortest paths found successfully.");
        }
        else
        {
            Console.WriteLine("Shortest paths could not be found due to negative-weight cycles.");
        }
    }
}
