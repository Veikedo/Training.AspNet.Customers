using System.Collections.Generic;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  public class ManagerSlavesDataSource : BaseDataSource
  {
    public IEnumerable<EmployeeCard> GetSlaves(int managerId)
    {
      User manager = Repository.Users.FirstOrDefault(x => x.Id == managerId);
      return manager == null ? Enumerable.Empty<EmployeeCard>() : manager.EmployeeCard.Slaves;
    }
  }
}