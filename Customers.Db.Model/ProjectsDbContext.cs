using System.Data.Entity;
using Customers.Db.Model.Migrations;

namespace Customers.Db.Model
{
  public class ProjectsDbContext : DbContext
  {
    public ProjectsDbContext()
    {
      Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectsDbContext, Configuration>());
      
    }

    public DbSet<Employee> Employees { get; set; }
  }
}