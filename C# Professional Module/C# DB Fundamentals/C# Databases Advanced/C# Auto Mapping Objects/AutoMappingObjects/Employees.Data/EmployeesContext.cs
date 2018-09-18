namespace Employees.Data
{
    using Employees.Models;

    using Microsoft.EntityFrameworkCore;

    public class EmployeesContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeesContext() { }
        public EmployeesContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}