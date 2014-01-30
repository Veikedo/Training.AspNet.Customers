using System.Collections.Generic;
using System.Linq;
using Customers.Application.Annotations;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  [UsedImplicitly]
  public class CustomersDataSource : BaseDataSource
  {
    public IEnumerable<CustomerInfo> GetCustomers()
    {
      return Repository.Customers;
    }
  }
}