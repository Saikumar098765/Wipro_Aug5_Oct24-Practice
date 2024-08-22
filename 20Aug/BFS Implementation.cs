using System;
using System.Collections.Generic;
namespace pre
{
    class program
    {
        public class Graph
        {
            private Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

            // Add a node to the graph
            public void AddNode(int node)
            {
                if (!adjacencyList.ContainsKey(node))
                {
                    adjacencyList[node] = new List<int>();
                }
            }

            // Add an edge between two nodes (since it's an undirected graph, add both ways)
            public void AddEdge(int node1, int node2)
            {
                if (!adjacencyList.ContainsKey(node1))
                {
                    AddNode(node1);
                }
                if (!adjacencyList.ContainsKey(node2))
                {
                    AddNode(node2);
                }

                adjacencyList[node1].Add(node2);
                adjacencyList[node2].Add(node1); // Undirected graph: add the reverse edge
            }

            // Perform BFS starting from the given start node
            public void BFS(int startNode)
            {
                // Track visited nodes
                HashSet<int> visited = new HashSet<int>();
                Queue<int> queue = new Queue<int>();

                // Start from the given node
                visited.Add(startNode);
                queue.Enqueue(startNode);

                while (queue.Count > 0)
                {
                    int currentNode = queue.Dequeue();
                    Console.WriteLine(currentNode); // Print the current node

                    // Visit each neighbor of the current node
                    foreach (int neighbor in adjacencyList[currentNode])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
        }

        class ProgramOne
        {
            static void Main(string[] args)
            {
                Graph graph = new Graph();

                // Add edges to the graph
                graph.AddEdge(1, 2);
                graph.AddEdge(1, 3);
                graph.AddEdge(2, 4);
                graph.AddEdge(2, 5);
                graph.AddEdge(3, 6);
                graph.AddEdge(3, 7);

                // Perform BFS starting from node 1
                Console.WriteLine("BFS traversal starting from node 1:");
                graph.BFS(1);
            }
        }


    }

}
