using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<Role> Roles
  {
    get { return Db.Roles; }
  }

    public bool CreateRole(Role instance)
    {
      if (instance.Id == 0)
      {
        Db.Roles.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateRole(Role instance)
    {
      Role cache = Db.Roles.FirstOrDefault(p => p.Id == instance.Id);

      if (cache != null)
      {
        cache.Code = instance.Code;

        Db.Entry(cache).State = EntityState.Modified;
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool RemoveRole(int idRole)
    {
      Role instance = Db.Roles.FirstOrDefault(p => p.Id == idRole);

      if (instance != null)
      {
        Db.Roles.Remove(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }
  }
}
