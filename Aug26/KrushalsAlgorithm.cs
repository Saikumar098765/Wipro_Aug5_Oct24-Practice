using System;
using System.Collections.Generic;
using System.Linq;

class Edge
{
    public int Source;
    public int Destination;
    public int Weight;
}

class KrushalsAlgorithm
{
    static void Main()
    {
        List<Edge> edges = new List<Edge>
        {
            new Edge { Source = 0, Destination = 1, Weight = 10 },
            new Edge { Source = 0, Destination = 2, Weight = 6 },
            new Edge { Source = 0, Destination = 3, Weight = 5 },
            new Edge { Source = 1, Destination = 3, Weight = 15 },
            new Edge { Source = 2, Destination = 3, Weight = 4 }
        };

        var mst = KruskalMST(edges, 4);

        Console.WriteLine("Edges in the Minimum Spanning Tree:");
        foreach (var edge in mst)
        {
            Console.WriteLine($"({edge.Source}, {edge.Destination}) - Weight: {edge.Weight}");
        }
    }

    static List<Edge> KruskalMST(List<Edge> edges, int vertices)
    {
        edges = edges.OrderBy(e => e.Weight).ToList();
        int[] parent = new int[vertices];

        for (int i = 0; i < vertices; i++)
        {
            parent[i] = i;
        }

        List<Edge> mst = new List<Edge>();

        foreach (var edge in edges)
        {
            int sourceRoot = Find(parent, edge.Source);
            int destinationRoot = Find(parent, edge.Destination);

            if (sourceRoot != destinationRoot)
            {
                mst.Add(edge);
                Union(parent, sourceRoot, destinationRoot);
            }
        }

        return mst;
    }

    static int Find(int[] parent, int vertex)
    {
        if (parent[vertex] != vertex)
        {
            parent[vertex] = Find(parent, parent[vertex]);
        }

        return parent[vertex];
    }

    static void Union(int[] parent, int vertex1, int vertex2)
    {
        parent[vertex1] = vertex2;
    }
}