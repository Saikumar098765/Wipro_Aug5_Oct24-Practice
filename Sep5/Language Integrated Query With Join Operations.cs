using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string Pincode { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public string Address { get; set; }
    public DateTime Datetime { get; set; }
    public int CustomerId { get; set; }
}

class Program
{
    static void Main()
    {
        
        List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Sai Kumar", Gender = "Male", Age = 30, Pincode = "123456" },
            new Customer { Id = 2, Name = "Sunil", Gender = "Male", Age = 25, Pincode = "789012" },
            new Customer { Id = 3, Name = "Mahesh", Gender = "Male", Age = 28, Pincode = "345678" },
            new Customer { Id = 4, Name = "Shiva", Gender = "Male", Age = 22, Pincode = "901234" },
            new Customer { Id = 5, Name = "Karan", Gender = "Male", Age = 26, Pincode = "567890" }
        };

        Console.WriteLine("List of Customers :");
        foreach (var customer in customers)
        {
            Console.WriteLine($"Id Number : {customer.Id}, Name: {customer.Name}, Gender: {customer.Gender}, Age: {customer.Age}, Pincode: {customer.Pincode}");
        }

        
        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, Address = "Address 1", Datetime = DateTime.Now, CustomerId = 1 },
            new Order { OrderId = 2, Address = "Address 2", Datetime = DateTime.Now, CustomerId = 2 },
            new Order { OrderId = 3, Address = "Address 3", Datetime = DateTime.Now, CustomerId = 3 },
            new Order { OrderId = 4, Address = "Address 4", Datetime = DateTime.Now, CustomerId = 4 },
            new Order { OrderId = 5, Address = "Address 5", Datetime = DateTime.Now, CustomerId = 5 }
        };

        var innerJoinResult = InnerJoin(orders, customers);
        var leftJoinResult = LeftJoin(orders, customers);
        var leftToRightJoinResult = LeftToRightJoin(orders, customers);
        var rightToLeftJoinResult = RightToLeftJoin(orders, customers);

      
        Console.WriteLine("\nInner Join Result:");
        foreach (var order in innerJoinResult)
        {
            Console.WriteLine(
                $"OrderId: {order.OrderId}, " +
                $"Address: {order.Address}, " +
                $"Datetime: {order.Datetime}, " +
                $"CustomerName: {order.Name}"
            );
        }

        Console.WriteLine("\nLeft Join Result:");
        foreach (var order in leftJoinResult)
        {
            Console.WriteLine(
                $"OrderId: {order.OrderId}, " +
                $"Address: {order.Address}, " +
                $"Datetime: {order.Datetime}, " +
                $"CustomerName: {order.Name}"
            );
        }

        Console.WriteLine("\nLeft to Right Join Result:");
        foreach (var order in leftToRightJoinResult)
        {
            Console.WriteLine(
                $"OrderId: {order.OrderId}, " +
                $"Address: {order.Address}, " +
                $"Datetime: {order.Datetime}, " +
                $"CustomerName: {order.Name}"
            );
        }

        Console.WriteLine("\nRight to Left Join Result:");
        foreach (var order in rightToLeftJoinResult)
        {
            Console.WriteLine(
                $"OrderId: {order.OrderId}, " +
                $"Address: {order.Address}, " +
                $"Datetime: {order.Datetime}, " +
                $"CustomerName: {order.Name}"
            );
        }
    }
    static IEnumerable<dynamic> InnerJoin(List<Order> orders, List<Customer> customers)
    {
        return orders
            .Join(
                customers,
                o => o.CustomerId,
                c => c.Id,
                (o, c) => new { o.OrderId, o.Address, o.Datetime, c.Name }
            );
    }
    static IEnumerable<dynamic> LeftJoin(List<Order> orders, List<Customer> customers)
    {
        return orders
            .GroupJoin(
                customers,
                o => o.CustomerId,
                c => c.Id,
                (o, c) => new { o, c }
            )
            .SelectMany(
                x => x.c.DefaultIfEmpty(),
                (x, c) => new { x.o.OrderId, x.o.Address, x.o.Datetime, Name = c?.Name }
            );
    }

    static IEnumerable<dynamic> LeftToRightJoin(List<Order> orders, List<Customer> customers)
    {
        return orders
            .GroupJoin(
                customers,
                o => o.CustomerId,
                c => c.Id,
                (o, c) => new { o, Customer = c.DefaultIfEmpty().FirstOrDefault() }
            )
            .Select(x => new { x.o.OrderId, x.o.Address, x.o.Datetime, Name = x.Customer?.Name });
    }

    static IEnumerable<dynamic> RightToLeftJoin(List<Order> orders, List<Customer> customers)
    {
        return customers
            .GroupJoin(
                orders,
                c => c.Id,
                o => o.CustomerId,
                (c, o) => new { c, Order = o.DefaultIfEmpty().FirstOrDefault() }
            )
            .Select(x => new { x.Order?.OrderId, x.Order?.Address, x.Order?.Datetime, Name = x.c.Name });
    }
}
