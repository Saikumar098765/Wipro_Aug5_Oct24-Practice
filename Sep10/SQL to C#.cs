using System;
using System.Data.SqlClient;

class Program
{
    private static string connectionString = "Server=localhost;Database=MyDatabase;User Id=myUsername;Password=myPassword;"; // Update with your actual connection string

    static void Main()
    {
        // Example Usage
        InsertEmployee("John Doe", 'M', 30, 50000.00m, 1);
        ReadEmployees();
        UpdateEmployee("John Doe", 35, 55000.00m);
        DeleteEmployee("John Doe");
    }

    // Create Operation
    public static void InsertEmployee(string name, char gender, int age, decimal salary, int deptId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Employee (Name, Gender, Age, Salary, DeptId) VALUES (@Name, @Gender, @Age, @Salary, @DeptId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Age", age);
            command.Parameters.AddWithValue("@Salary", salary);
            command.Parameters.AddWithValue("@DeptId", deptId);

            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("Employee inserted successfully.");
        }
    }

    // Read Operation
    public static void ReadEmployees()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Employee";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Name: {reader["Name"]}, Gender: {reader["Gender"]}, Age: {reader["Age"]}, Salary: {reader["Salary"]}, DeptId: {reader["DeptId"]}");
            }
        }
    }

    // Update Operation
    public static void UpdateEmployee(string name, int age, decimal salary)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Employee SET Age = @Age, Salary = @Salary WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Age", age);
            command.Parameters.AddWithValue("@Salary", salary);
            command.Parameters.AddWithValue("@Name", name);

            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("Employee updated successfully.");
        }
    }

    // Delete Operation
    public static void DeleteEmployee(string name)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Employee WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);

            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("Employee deleted successfully.");
        }
    }
}
