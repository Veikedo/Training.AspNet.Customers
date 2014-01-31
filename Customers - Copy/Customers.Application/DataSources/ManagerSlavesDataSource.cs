using System.Collections.Generic;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  public class ManagerSlavesDataSource : BaseDataSource
  {
    public IEnumerable<User> GetSlaves(int managerId)
    {
      User manager = Repository.Users.FirstOrDefault(x => x.Id == managerId);
      return manager == null ? Enumerable.Empty<User>() : manager.Slaves;
    }
  }
}