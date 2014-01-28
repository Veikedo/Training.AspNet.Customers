using System.Data.Entity;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<Customer> Customers
    {
      get { return Db.Customers; }
    }

    public bool CreateCustomer(Customer instance)
    {
      if (instance.Id == 0)
      {
        Db.Customers.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateCustomer(Customer instance)
    {
      Customer cache = Db.Customers.FirstOrDefault(p => p.Id == instance.Id);

      if (cache != null)
      {
        cache.Address = instance.Address;
        cache.CompanyName = instance.CompanyName;

        cache.Orders.Clear();
        cache.Orders = instance.Orders;

        Db.Entry(cache).State = EntityState.Modified;
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool RemoveCustomer(int idCustomer)
    {
      Customer instance = Db.Customers.FirstOrDefault(p => p.Id == idCustomer);

      if (instance != null)
      {
        Db.Customers.Remove(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }
  }
}