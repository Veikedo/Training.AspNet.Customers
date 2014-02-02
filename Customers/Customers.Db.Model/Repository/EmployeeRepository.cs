using System.Data.Entity;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<EmployeeCard> EmployeeCards
    {
      get { return Db.EmployeeCards; }
    }

    public bool CreateEmployeeCard(EmployeeCard instance)
    {
      if (instance.UserId == 0)
      {
        Db.EmployeeCards.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateEmployeeCard(EmployeeCard instance)
    {
      EmployeeCard cache = Db.EmployeeCards.FirstOrDefault(p => p.UserId == instance.UserId);

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

    public bool RemoveEmployeeCard(int idEmployeeCard)
    {
      EmployeeCard instance = Db.EmployeeCards.FirstOrDefault(p => p.UserId == idEmployeeCard);

      if (instance != null)
      {
        Db.EmployeeCards.Remove(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }
  }
}