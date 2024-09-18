using System.Linq;
using System.Windows;
using System.ComponentModel.DataAnnotations;

namespace Employee_Dashboard
{

    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        public string EmployeeName { get; set; }

        public string Gender { get; set; }
    }

    public partial class MainWindow : Window
    {
        private EmployeeContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new EmployeeContext();
        }

        private void GetEmployee(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EmployeeIdTextBox.Text, out int employeeId))
            {
                var employee = db.Employees.Find(employeeId);

                if (employee != null)
                {
                    EmployeeNameTextBox.Text = employee.EmployeeName;
                    GenderTextBox.Text = employee.Gender;
                }
                else
                {
                    MessageBox.Show("Employee not found");
                }
            }
            else
            {
                MessageBox.Show("Invalid Employee ID");
            }
        }

        private void CreateEmployee(object sender, RoutedEventArgs e)
        {
            var employee = new Employee()
            {
                EmployeeName = EmployeeNameTextBox.Text,
                Gender = GenderTextBox.Text
            };

            db.Employees.Add(employee);
            db.SaveChanges();

            MessageBox.Show("Employee created successfully");
        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EmployeeIdTextBox.Text, out int employeeId))
            {
                var employee = db.Employees.Find(employeeId);

                if (employee != null)
                {
                    employee.EmployeeName = EmployeeNameTextBox.Text;
                    employee.Gender = GenderTextBox.Text;

                    db.SaveChanges();
                    MessageBox.Show("Employee updated successfully");
                }
                else
                {
                    MessageBox.Show("Employee not found");
                }
            }
            else
            {
                MessageBox.Show("Invalid Employee ID");
            }
        }

        private void ViewEmployee(object sender, RoutedEventArgs e)
        {
        }
    }
}
