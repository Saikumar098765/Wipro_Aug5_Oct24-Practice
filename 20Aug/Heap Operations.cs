/*Task 3: Implementing Heap Operations
Code a min-heap in C# with methods for insertion, deletion, and fetching the minimum element. 
Ensure that the heap property is maintained after each operation.
 * */

using System;
using System.Collections.Generic;

public class MinHeap
{
    private List<int> heap;

    public MinHeap()
    {
        heap = new List<int>();
    }

    public void Insert(int element)
    {
        heap.Add(element);
        HeapifyUp(heap.Count - 1);
    }

    public int ExtractMin()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");

        int min = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);

        HeapifyDown(0);
        return min;
    }

    public int GetMin()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");
        return heap[0];
    }

    private void HeapifyUp(int index)
    {
        while (index > 0 && heap[index] < heap[Parent(index)])
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private void HeapifyDown(int index)
    {
        int smallest = index;
        int left = LeftChild(index);
        int right = RightChild(index);

        if (left < heap.Count && heap[left] < heap[smallest])
        {
            smallest = left;
        }
        if (right < heap.Count && heap[right] < heap[smallest])
        {
            smallest = right;
        }

        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    private int Parent(int index) => (index - 1) / 2;
    private int LeftChild(int index) => 2 * index + 1;
    private int RightChild(int index) => 2 * index + 2;

    private void Swap(int index1, int index2)
    {
        int temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
}

class Program11
{
    static void Main(string[] args)
    {
        MinHeap minHeap = new MinHeap();
        minHeap.Insert(10);
        minHeap.Insert(4);
        minHeap.Insert(15);
        minHeap.Insert(7);

        Console.WriteLine(minHeap.GetMin()); // Output: 4
        minHeap.ExtractMin();
        Console.WriteLine(minHeap.GetMin()); // Output: 7
    }
}
