using System.Data.Entity;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<User> Users
    {
      get { return Db.Users; }
    }

    public bool CreateUser(User instance)
    {
      if (instance.Id == 0)
      {
        Db.Users.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateUser(User instance)
    {
      int res = Db.Database.ExecuteSqlCommand("UPDATE Users " +
                                              "SET Name=@p0, Version=@p1 " +
                                              "WHERE Id=@p2 AND Version=@p3",
                                              instance.Name, instance.Version + 1,
                                              instance.Id, instance.Version);

      Db.Entry(instance).State = EntityState.Modified;
      Db.SaveChanges();
      return res > 0;
    }

    public bool RemoveUser(int idEmployee)
    {
      User instance = Db.Users.FirstOrDefault(p => p.Id == idEmployee);

      if (instance != null)
      {
        Db.Users.Remove(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }
  }
}