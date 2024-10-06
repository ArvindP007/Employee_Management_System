using Employee_Management_System.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
