using System.Collections.Generic;
using System.Linq;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  public class ManagerSlavesDataSource : BaseDataSource
  {
    public IEnumerable<Employee> GetSlaves(int managerId)
    {
      Employee manager = Repository.Employees.FirstOrDefault(x => x.Id == managerId);
      return manager == null ? Enumerable.Empty<Employee>() : manager.Slaves;
    }
  }
}