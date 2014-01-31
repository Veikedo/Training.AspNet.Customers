using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public partial class EntityRepository
  {
    public IQueryable<User> Users
    {
      get { return Db.Employees; }
    }

    public bool CreateUser(User instance)
    {
      if (instance.Id == 0)
      {
        Db.Employees.Add(instance);
        Db.SaveChanges();
        return true;
      }

      return false;
    }

    public bool UpdateUser(User instance)
    {
      int res = Db.Database.ExecuteSqlCommand("UPDATE Users " +
                                              "SET Name=@p0, ManagerId=@p1, Version=@p2 " +
                                              "WHERE Id=@p3 AND Version=@p4",
                                              instance.Name, instance.ManagerId,
                                              instance.Version + 1, instance.Id, instance.Version);
      return res > 0;
    }

    public bool RemoveUser(int idEmployee)
    {
      User instance = Db.Employees.FirstOrDefault(p => p.Id == idEmployee);

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