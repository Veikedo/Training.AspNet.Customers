using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Customers.Db;
using Customers.Db.Models;

namespace Customers.Test1
{
  public class Program
  {
    private static void Main()
    {
/*
      using (var ctx = new ProjectsDbContext())
      {
        var boss = new Employee {Name = "Boss"};
        var employee = new Employee {Name = "Slave"};

        boss.Slaves.Add(employee);
        ctx.Employees.Add(boss);
        ctx.SaveChanges();
      }

      Print();

      using (var ctx = new ProjectsDbContext())
      {
        Employee boss = ctx.Employees.First(x => x.Slaves.Count > 0);

        boss.Slaves.Clear();
        boss.Slaves = new Collection<Employee> {new Employee {Name = "Slave2"}};
        ctx.Entry(boss).State = EntityState.Modified;

        ctx.SaveChanges();
      }

      Console.WriteLine();
      Console.WriteLine();
      Print();

      Console.WriteLine("Done");
      Console.ReadLine();
*/
    }

/*
    private static void Print()
    {
      using (var ctx = new ProjectsDbContext())
      {
        foreach (Employee boss in ctx.Employees.Where(x => x.Slaves.Count > 0))
        {
          Console.WriteLine("Boss name:" + boss.Name);
          foreach (Employee slave in boss.Slaves)
          {
            Console.WriteLine(slave.Name);
          }
        }

        Console.WriteLine("All");
        foreach (Employee employee in ctx.Employees)
        {
          Console.WriteLine(employee.Name);
        }
      }
    }
*/
  }
}