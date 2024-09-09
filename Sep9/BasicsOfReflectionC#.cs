using System;
using System.Reflection;

namespace ReflectionDemo
{
    public class AssemblyExplorer
    {
        public void ExploreAssembly(Assembly assembly)
        {
            Console.WriteLine($"Exploring assembly: {assembly.FullName}");

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"Type: {type.Name}");
                Console.WriteLine($"Base Type: {type.BaseType?.Name}");
                Console.WriteLine("No Interface Implemented ");
                Console.WriteLine("------------------------");
                foreach (var interfaceType in type.GetInterfaces())
                {
                    Console.WriteLine($"  {interfaceType.Name}");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var explorer = new AssemblyExplorer();
            explorer.ExploreAssembly(typeof(Program).Assembly);
            Console.ReadKey(); 
        }
    }
}