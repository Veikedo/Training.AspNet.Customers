using System.Linq;
using Customers.Application.Annotations;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  [UsedImplicitly]
  public class CustomersDataSource : DataSourceBase
  {
    public IQueryable<Customer> GetCustomers()
    {
      return Repository.Customers;
    }
  }
}