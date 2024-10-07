// Controllers/EmployeeController.cs
using Microsoft.AspNetCore.Mvc;
using Permanent_Contract_Employee.Models;
using Permanent_Contract_Employee.Services;

namespace Permanent_Contract_Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest("Employee cannot be null");

            var savedEmployee = _employeeService.AddEmployee(employee);
            return Ok(savedEmployee);
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }
    }
}
