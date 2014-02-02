using System.Data.Entity;
using System.Linq;
using Customers.Application.Annotations;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  [UsedImplicitly]
  public class UsersDataSource : BaseDataSource
  {
    public void UpdateUser(int id, string name)
    {
      var user = Repository.Users.AsNoTracking().First(x => x.Id == id);
      user.Name = name;
      Repository.UpdateUser(user);
    }

    public User GetUser(int id)
    {
      return Repository.Users.FirstOrDefault(x => x.Id == id);
    }
  }
}