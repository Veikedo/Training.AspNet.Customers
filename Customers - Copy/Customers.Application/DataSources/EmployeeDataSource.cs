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
      Repository.UpdateUser(user);
    }

    public User GetEmployee(int id)
    {
      return Repository.Users.FirstOrDefault(x => x.Id == id);
    } 
  }
}