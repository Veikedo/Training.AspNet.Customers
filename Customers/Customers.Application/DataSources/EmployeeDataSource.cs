using System.Linq;
using Customers.Application.Annotations;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  [UsedImplicitly]
  public class EmployeeDataSource : BaseDataSource
  {
    public void UpdateEmployee(Employee employee)
    {
      Repository.UpdateEmployee(employee);
    }

    public Employee GetEmployee(int id)
    {
      return Repository.Employees.FirstOrDefault(x => x.Id == id);
    } 
  }
}