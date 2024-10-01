using Microsoft.EntityFrameworkCore;
using Restful_Web_API.Models;

namespace Restful_Web_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet for employees
        public DbSet<Employee> Employees { get; set; }
    }
}
