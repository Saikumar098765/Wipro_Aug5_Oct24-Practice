using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Merge_Jump
{
    
        class Program
        {
            static void Main()
            {
                // Creating a queue for integers
                CustomQueue<int> intQueue = new CustomQueue<int>();
                // Creating a queue for strings
                CustomQueue<string> stringQueue = new CustomQueue<string>();

                // Enqueue integers - just like dividing in Merge Sort
                intQueue.Enqueue(1);
                intQueue.Enqueue(2);
                intQueue.Enqueue(3);

                // Enqueue strings - another division in Merge Sort
                stringQueue.Enqueue("Hello");
                stringQueue.Enqueue("World");

                // Dequeue and print integers - merging step in Merge Sort
                Console.WriteLine("Integer Queue:");
                while (!intQueue.IsEmpty())
                {
                    Console.WriteLine(intQueue.Dequeue()); // Output: 1, 2, 3
                }

                // Dequeue and print strings - merging step in Merge Sort
                Console.WriteLine("String Queue:");
                while (!stringQueue.IsEmpty())
                {
                    Console.WriteLine(stringQueue.Dequeue()); // Output: Hello, World
                }
            }
        }

    
}
