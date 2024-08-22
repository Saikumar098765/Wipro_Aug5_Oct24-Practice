using System;
using System.Collections.Generic;

public class CustomQueue<T>
{
    private List<T> elements = new List<T>();

    // Enqueue: Add an element to the end of the queue
    public void Enqueue(T item)
    {
        elements.Add(item);
    }

    // Dequeue: Remove and return the front element of the queue
    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        T value = elements[0];
        elements.RemoveAt(0); // Moving forward just like a step in Jump Search
        return value;
    }

    // Peek: Return the front element without removing it
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return elements[0];
    }

    // IsEmpty: Check if the queue is empty
    public bool IsEmpty()
    {
        return elements.Count == 0;
    }
}
