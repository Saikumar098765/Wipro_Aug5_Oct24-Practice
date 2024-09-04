using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public decimal Salary { get; set; }
}

class Program
{
    static void Main()
    {
        
        List<Person> persons = new List<Person>
        {
            new Person { FirstName = "Madhu", LastName = "Reddy", Age = 35, Gender = "Male", Salary = 50000 },
            new Person { FirstName = "Divya", LastName = "Sree", Age = 28, Gender = "Female", Salary = 60000 },
            new Person { FirstName = "Adhi", LastName = "Reddy", Age = 40, Gender = "Female", Salary = 70000 },
            new Person { FirstName = "Sai", LastName = "Kumar", Age = 25, Gender = "Male", Salary = 40000 },
            new Person { FirstName = "Kalyan", LastName = "Kumar", Age = 32, Gender = "Female", Salary = 55000 }
        };
        var personsOver30 = persons.Where(p => p.Age > 30).Select(p => $"{p.FirstName} {p.LastName}");

        Console.WriteLine("Persons age above 30:");
        foreach (var name in personsOver30)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine("---------------");
        var personsUnder30 = persons.Where(p => p.Age < 30).Select(p => $"{p.FirstName} {p.LastName}");

        Console.WriteLine("Persons age below 30:");
        foreach (var name in personsUnder30)
        {
            Console.WriteLine(name);
        }



        var sortedPersons = persons.OrderBy(p => p.LastName).ThenBy(p => p.FirstName);
        Console.WriteLine("---------------");
        Console.WriteLine("list of persons:");
        foreach (var person in sortedPersons)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}, Age: {person.Age}");
        }
    }
}
