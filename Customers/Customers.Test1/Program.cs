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
        var boss = new Users {Name = "Boss"};
        var employee = new Users {Name = "Slave"};

        boss.Slaves.Add(employee);
        ctx.Users.Add(boss);
        ctx.SaveChanges();
      }

      Print();

      using (var ctx = new ProjectsDbContext())
      {
        Users boss = ctx.Users.First(x => x.Slaves.Count > 0);

        boss.Slaves.Clear();
        boss.Slaves = new Collection<Users> {new Users {Name = "Slave2"}};
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
        foreach (Users boss in ctx.Users.Where(x => x.Slaves.Count > 0))
        {
          Console.WriteLine("Boss name:" + boss.Name);
          foreach (Users slave in boss.Slaves)
          {
            Console.WriteLine(slave.Name);
          }
        }

        Console.WriteLine("All");
        foreach (Users employee in ctx.Users)
        {
          Console.WriteLine(employee.Name);
        }
      }
    }
*/
  }
}