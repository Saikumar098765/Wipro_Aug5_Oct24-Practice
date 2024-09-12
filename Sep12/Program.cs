using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Runtime.Remoting.Contexts;
using Microsoft.EntityFrameworkCore.SqlServer;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public int DeptId { get; set; }
    public Department Department { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Employee> Employees { get; set; }
}

public class MyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MyDb;Integrated Security=True");
    }
}

public class MyDbContextSeed
{
    public static void Seed(MyDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var departments = new[]
        {
            new Department { Name = "HR" },
            new Department { Name = "IT" },
            new Department { Name = "Finance" }
        };

        context.Departments.AddRange(departments);
        context.SaveChanges();

        var employees = new[]
        {
            new Employee { Name = "John", Gender = "Male", Age = 30, Salary = 50000, DeptId = 1 },
            new Employee { Name = "Alice", Gender = "Female", Age = 25, Salary = 40000, DeptId = 2 },
            new Employee { Name = "Bob", Gender = "Male", Age = 40, Salary = 60000, DeptId = 3 }
        };

        context.Employees.AddRange(employees);
        context.SaveChanges();
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new MyDbContext())
        {
            MyDbContextSeed.Seed(context);
        }

        // Migration commands (run in Package Manager Console)
        // Enable-Migrations
        // Add-Migration InitialCreate
        // Update-Database

        // Add-Migration AddNewColumn
        // Update-Database

        // Add-Migration UpdateTableName
        // Update-Database

        // Add-Migration AddNewTable
        // Update-Database

        // Add-Migration RemoveColumn
        // Update-Database

        // Update-Database -TargetMigration:UpdateTableName
    }
}