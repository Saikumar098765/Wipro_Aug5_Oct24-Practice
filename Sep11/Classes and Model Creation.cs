using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DeptId);
    }
}

public class EmployeeRepository
{
    private readonly MyDbContext _context;

    public EmployeeRepository(MyDbContext context)
    {
        _context = context;
    }

    // Create
    public void CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    // Read
    public List<Employee> GetEmployees()
    {
        return _context.Employees.ToList();
    }

    public Employee GetEmployee(int id)
    {
        return _context.Employees.Find(id);
    }

    // Update
    public void UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    // Delete
    public void DeleteEmployee(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}

public class DepartmentRepository
{
    private readonly MyDbContext _context;

    public DepartmentRepository(MyDbContext context)
    {
        _context = context;
    }

    // Create
    public void CreateDepartment(Department department)
    {
        _context.Departments.Add(department);
        _context.SaveChanges();
    }

    // Read
    public List<Department> GetDepartments()
    {
        return _context.Departments.ToList();
    }

    public Department GetDepartment(int id)
    {
        return _context.Departments.Find(id);
    }

    // Update
    public void UpdateDepartment(Department department)
    {
        _context.Departments.Update(department);
        _context.SaveChanges();
    }

    // Delete
    public void DeleteDepartment(int id)
    {
        var department = _context.Departments.Find(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlServer("YourConnectionString")
            .Options;

        var employeeRepository = new EmployeeRepository(new MyDbContext(options));
        var departmentRepository = new DepartmentRepository(new MyDbContext(options));

        // Create an employee
        var employee = new Employee { Name = "John Doe", Gender = "Male", Age = 30, Salary = 50000, DeptId = 1 };
        employeeRepository.CreateEmployee(employee);

        // Get all employees
        var employees = employeeRepository.GetEmployees();

        // Update an employee
        var employeeToUpdate = employeeRepository.GetEmployee(1);
        employeeToUpdate.Salary = 60000;
        employeeRepository.UpdateEmployee(employeeToUpdate);

        // Delete an employee
        employeeRepository.DeleteEmployee(1);

        // Create a department
        var department = new Department { Name = "Sales" };
        departmentRepository.CreateDepartment(department);

        // Get all departments
        var departments = departmentRepository.GetDepartments();

        // Update a department
        var departmentToUpdate = departmentRepository.GetDepartment(1);
        departmentToUpdate.Name = "Marketing";
        departmentRepository.UpdateDepartment(departmentToUpdate);

        // Delete a department
        departmentRepository.DeleteDepartment(1);
    }
}