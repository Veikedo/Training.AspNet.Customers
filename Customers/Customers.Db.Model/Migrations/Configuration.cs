using System.Data.Entity.Migrations;
using Customers.Db.Models;

namespace Customers.Db.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<ProjectsDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
      AutomaticMigrationDataLossAllowed = true;
      ContextKey = "Customers.Db.Model.ProjectsDbContext";
    }

    protected override void Seed(ProjectsDbContext context)
    {
      context.Roles.AddOrUpdate(role => role.Code,
                                new Role {Code = "Customer"},
                                new Role {Code = "Employee"});
    }
  }
}