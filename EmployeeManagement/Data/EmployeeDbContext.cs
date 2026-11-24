using EmployeeManagement.Models.Entitties;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Data
{
    public class EmployeeDbContext : IdentityDbContext<ApplicationUser>
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
        {
        }

        // This represents tables in SQL Server
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
