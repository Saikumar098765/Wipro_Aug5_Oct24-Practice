// Models/Employee.cs
using System.ComponentModel.DataAnnotations;

namespace Permanent_Contract_Employee.Models
{
    public class Employee
    {
        public int Id { get; set; } // Primary Key

        [Required]
        public string Name { get; set; }

        [Required]
        public string EmployeeType { get; set; } // Permanent or Contractual

        public decimal Bonus { get; set; } = 0; // Default value

        public decimal Pay { get; set; } = 0;   // Default value
    }
}
