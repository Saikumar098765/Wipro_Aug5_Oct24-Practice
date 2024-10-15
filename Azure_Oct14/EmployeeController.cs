using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_Web_API.Data;
using Restful_Web_API.Models;
using System.Threading.Tasks;

namespace Restful_Web_API.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
            if (!_context.Employees.Any())
            {
                _context.Employees.Add(new Employee
                {
                    FirstName = "Sai",
                    MiddleName = "Kumar",
                    LastName = "uruvakili",
                    Country = "India",
                    Gender = "Male",
                    PhoneNumber = "9745698745",
                    DateOfBirth = new DateTime(1990, 1, 1)
                });
                _context.SaveChanges();
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

    }
}
