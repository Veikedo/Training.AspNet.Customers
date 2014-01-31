using System.Data.Entity;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<PasswordResetLink> PasswordResetLinks
  {
    get { return Db.PasswordResetLinks; }
  }

    public bool CreatePasswordResetLink(PasswordResetLink instance)
    {
      if (instance.UserId == 0)
      {
        Db.PasswordResetLinks.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdatePasswordResetLink(PasswordResetLink instance)
    {
      PasswordResetLink cache = Db.PasswordResetLinks.FirstOrDefault(p => p.UserId == instance.UserId);

      if (cache != null) 
      {
        //TODO : Update fields for PasswordResetLink
        

        Db.Entry(cache).State = EntityState.Modified;
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool RemovePasswordResetLink(int idPasswordResetLink)
    {
      PasswordResetLink instance = Db.PasswordResetLinks.FirstOrDefault(p => p.UserId == idPasswordResetLink);

      if (instance != null)
      {
        Db.PasswordResetLinks.Remove(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }
  }
}