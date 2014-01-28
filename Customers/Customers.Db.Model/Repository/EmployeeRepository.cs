using System.Data.Entity;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<Employee> Employees
    {
      get { return Db.Employees; }
    }

    public bool CreateEmployee(Employee instance)
    {
      if (instance.Id == 0)
      {
        Db.Employees.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateEmployee(Employee instance)
    {
      Employee cache = Db.Employees.FirstOrDefault(p => p.Id == instance.Id);

      if (cache != null)
      {
        cache.ManagerId = instance.ManagerId;
        cache.Name = instance.Name;

        cache.Orders.Clear();
        cache.Orders = instance.Orders;

        cache.Slaves.Clear();
        cache.Slaves = instance.Slaves;

        Db.Entry(cache).State = EntityState.Modified;
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool RemoveEmployee(int idEmployee)
    {
      Employee instance = Db.Employees.FirstOrDefault(p => p.Id == idEmployee);

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