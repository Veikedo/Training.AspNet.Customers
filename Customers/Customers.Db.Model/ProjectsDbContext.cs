using System.Data.Entity;
using Customers.Db.Migrations;
using Customers.Db.Models;

namespace Customers.Db
{
  public class ProjectsDbContext : DbContext
  {
    public ProjectsDbContext()
    {
      Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectsDbContext, Configuration>());
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Role> Roles { get; set; }
  }
}