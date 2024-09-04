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

class Program1
{
    static void Main()
    {
        List<Person> persons = new List<Person>
        {
            new Person { FirstName = "Kalyan", Age = 35, Gender = "Male", Salary = 50000 },
            new Person { FirstName = "Uday", Age = 28, Gender = "Female", Salary = 60000 },
            new Person { FirstName = "Kumar", Age = 40, Gender = "Female", Salary = 70000 },
            new Person { FirstName = "Gireesh", Age = 25, Gender = "Male", Salary = 40000 },
            new Person { FirstName = "Pawan", Age = 32, Gender = "Female", Salary = 55000 }
        };

        var averageAge = persons.Average(p => p.Age);
        Console.WriteLine($"Average age of all persons in the List: {averageAge:F2}");

        var oldestPerson = persons.OrderByDescending(p => p.Age).First();
        var youngestPerson = persons.OrderBy(p => p.Age).First();

        Console.WriteLine($"\nOldest person Name : {oldestPerson.FirstName} {oldestPerson.LastName}, Age: {oldestPerson.Age}");
        Console.WriteLine($"Youngest person Name : {youngestPerson.FirstName} {youngestPerson.LastName}, Age: {youngestPerson.Age}");
    }
}
