using System;
using System.Linq;
using Customers.Db.Model;

namespace Test1
{
  public class Program
  {
    private static void Main()
    {
      /*      using (var ctx = new ProjectsDbContext())
      {
        var boss = new Employee {Name = "Boss", Version = 2};
        var employee = new Employee {Name = "First"};

        boss.Slaves.Add(employee);

        ctx.Employees.Add(boss);

        ctx.SaveChanges();
      }*/

      using (var ctx = new ProjectsDbContext())
      {
        var boss = ctx.Employees.First(x => x.Slaves.Count > 0);
        int res = ctx.Database.ExecuteSqlCommand("UPDATE dbo.Employees " +
                                                 "SET Version = @p0, Name = @p1 " +
                                                 "WHERE Version = @p2", boss.Version + 1, "NewBoss5", boss.Version+5);
        Console.WriteLine(res);

        foreach (var employee in ctx.Employees)
        {
          Console.WriteLine("Employee: " + employee.Name);
          var manager = employee.Manager ?? new Employee();
          Console.WriteLine("Manager: " + manager.Name);

          if (employee.Slaves.Count > 0)
          {
            Console.WriteLine("\tSlaves");
            foreach (Employee slave in employee.Slaves)
            {
              Console.WriteLine("\t\t" + slave.Name);
            }
          }

          Console.WriteLine();
        }
      }

      Console.WriteLine("Done");
      Console.ReadLine();
    }
  }
}