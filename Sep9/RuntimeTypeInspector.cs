using System;
using System.Reflection;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Company { get; set; }

    public Person(string name, int age, string address)
    {
        Name = name;
        Age = age;
        Company = address; 
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person("Sai Kumar", 23, "Wipro");
        Type type = typeof(Person);
        PropertyInfo[] properties = type.GetProperties();
        Console.WriteLine("Details of Persons : ");
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"Property: {property.PropertyType}, Value: {property.GetValue(person)}");
        }

        FieldInfo[] fields = type.GetFields();

       // Console.WriteLine("\nPublic Fields: ");
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine($"Name: {field.Name}, Value: {field.GetValue(person)}");
        }
    }
}