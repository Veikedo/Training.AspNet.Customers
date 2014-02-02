using System.Collections.Generic;
using System.Linq;
using Customers.Application.Annotations;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  [UsedImplicitly]
  public class OrdersDataSource : BaseDataSource
  {
    public IEnumerable<Order> GetCustomerOrders(int customerId)
    {
      return Repository.Orders.Where(x => x.CustomerId == customerId);
    }
  }
}