namespace MVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName} ";
    }

}
