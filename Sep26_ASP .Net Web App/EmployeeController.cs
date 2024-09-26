using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
        {

            new Employee { Id = 1, FirstName = "Gill", MiddleName = "Shubman", LastName = "GS", Email = "shu@gmail.com", PhoneNumber = "9876543210", Salary = 60000, Age = 28, DateOfBirth = new DateTime(1994, 06, 01), Address = "Delhi", Country = "India" },
            new Employee { Id = 2, FirstName = "Yash", MiddleName = "Jai", LastName = "Shwal", Email = "yash@gmail.com", PhoneNumber = "9772220333", Salary = 90000, Age = 20, DateOfBirth = new DateTime(1982, 11, 01), Address = "UP", Country = "India" },
            new Employee { Id = 3, FirstName = "Sai", MiddleName = "Kumar", LastName = "U", Email = "sai@gmail.com", PhoneNumber = "9014322322", Salary = 60000, Age = 23, DateOfBirth = new DateTime(1994, 4, 22), Address = "Hyderabad", Country = "India" },
            new Employee { Id = 4, FirstName = "Virat", MiddleName = "Kohli", LastName = "VK", Email = "vk@gmail.com", PhoneNumber = "9876543210", Salary = 55000, Age = 35, DateOfBirth = new DateTime(1996, 7, 19), Address = "Delhi", Country = "India" },
            new Employee { Id = 5, FirstName = "Rohit", MiddleName = "Sharma", LastName = "RK", Email = "rs45@gmail.com", PhoneNumber = "9216540987", Salary = 50000, Age = 35, DateOfBirth = new DateTime(1989, 11, 2), Address = "Vizag", Country = "India" },
            new Employee { Id = 6, FirstName = "Rishab", MiddleName = "Pant", LastName = "RS", Email = "risbah@gmail.com", PhoneNumber = "9543219870", Salary = 70000, Age = 32, DateOfBirth = new DateTime(1992, 2, 18), Address = "Delhi", Country = "India" },
            new Employee { Id = 7, FirstName = "Ashwin", MiddleName = "Ash", LastName = "Ash", Email = "ash@gmail.com", PhoneNumber = "9871234560", Salary = 75000, Age = 40, DateOfBirth = new DateTime(1984, 6, 5), Address = "Chennai", Country = "India" }
        };

        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = employees.Count + 1; // Simple ID generation
                employees.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
