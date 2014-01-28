using System.Data.Entity;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<Order> Orders
    {
      get { return Db.Orders; }
    }

    public bool CreateOrder(Order instance)
    {
      if (instance.Id == 0)
      {
        Db.Orders.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateOrder(Order instance)
    {
      Order cache = Db.Orders.FirstOrDefault(p => p.Id == instance.Id);

      if (cache != null)
      {
        cache.CustomerId = instance.CustomerId;
        cache.Description = instance.Description;
        cache.ManagerId = instance.ManagerId;

        Db.Entry(cache).State = EntityState.Modified;
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool RemoveOrder(int idOrder)
    {
      Order instance = Db.Orders.FirstOrDefault(p => p.Id == idOrder);

      if (instance != null)
      {
        Db.Orders.Remove(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }
  }
}