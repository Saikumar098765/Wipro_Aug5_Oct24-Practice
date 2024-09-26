using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number must have 10 digits.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must have exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Salary must be in LPA.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Age Must be 20 to 100 required.")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date of Birth.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please provide a correct address for quality purposes.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        // Alternative FullName implementation without $ sign
        public string GetFullName()
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }
    }
}
