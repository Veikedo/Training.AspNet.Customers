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

    public DbSet<User> Users { get; set; }
    public DbSet<CustomerCard> CustomerCards { get; set; }
    public DbSet<EmployeeCard> EmployeeCards { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<PasswordResetLink> PasswordResetLinks { get; set; }
  }
}