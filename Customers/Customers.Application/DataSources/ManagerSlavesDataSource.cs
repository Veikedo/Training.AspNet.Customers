using System.Collections.Generic;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  public class ManagerSlavesDataSource : BaseDataSource
  {
    public IEnumerable<EmployeeInfo> GetSlaves(int managerId)
    {
      User manager = Repository.Users.FirstOrDefault(x => x.Id == managerId);
      return manager == null ? Enumerable.Empty<EmployeeInfo>() : manager.EmployeeInfo.Slaves;
    }
  }
}