using System.Data.Entity;
using System.Linq;
using Customers.Application.Annotations;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  [UsedImplicitly]
  public class EmployeeDataSource : BaseDataSource
  {
    public void UpdateEmployee(User user)
    {
      var oldUser = Repository.Users.AsNoTracking().First(x => x.Id == user.Id);
      oldUser.Name = user.Name;
      Repository.UpdateUser(oldUser);
    }

    public User GetEmployee(int id)
    {
      return Repository.Users.FirstOrDefault(x => x.Id == id);
    } 
  }
}