using System.Data.Entity;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<EmployeeInfo> Employees
    {
      get { return Db.Employees; }
    }

    public bool CreateEmployee(EmployeeInfo instance)
    {
      if (instance.UserId == 0)
      {
        Db.Employees.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateEmployee(EmployeeInfo instance)
    {
      EmployeeInfo cache = Db.Employees.FirstOrDefault(p => p.UserId == instance.UserId);

      if (cache != null)
      {
        cache.ManagerId = instance.ManagerId;
        cache.UserId = instance.UserId;

        Db.Entry(cache).State = EntityState.Modified;
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool RemoveEmployee(int idEmployee)
    {
      EmployeeInfo instance = Db.Employees.FirstOrDefault(p => p.UserId == idEmployee);

      if (instance != null)
      {
        Db.Employees.Remove(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }
  }
}