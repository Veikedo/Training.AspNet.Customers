using System.Data.Entity;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<CustomerCard> CustomerCards
    {
      get { return Db.CustomerCards; }
    }

    public bool CreateCustomerCard(CustomerCard instance)
    {
      if (instance.UserId == 0)
      {
        Db.CustomerCards.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateCustomerCard(CustomerCard instance)
    {
      CustomerCard cache = Db.CustomerCards.FirstOrDefault(p => p.UserId == instance.UserId);

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

    public bool RemoveCustomerCard(int idCustomerCard)
    {
      CustomerCard instance = Db.CustomerCards.FirstOrDefault(p => p.UserId == idCustomerCard);

      if (instance != null)
      {
        Db.CustomerCards.Remove(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }
  }
}