using System.Data.Entity;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<CustomerInfo> Customers
    {
      get { return Db.Customers; }
    }

    public bool CreateCustomer(CustomerInfo instance)
    {
      if (instance.UserId == 0)
      {
        Db.Customers.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateCustomer(CustomerInfo instance)
    {
      CustomerInfo cache = Db.Customers.FirstOrDefault(p => p.UserId == instance.UserId);

      if (cache != null)
      {
        cache.Address = instance.Address;
        cache.CompanyName = instance.CompanyName;
        cache.User = instance.User;

        Db.Entry(cache).State = EntityState.Modified;
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool RemoveCustomer(int idCustomer)
    {
      CustomerInfo instance = Db.Customers.FirstOrDefault(p => p.UserId == idCustomer);

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