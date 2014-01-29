using System.Linq;
using Customers.Application.Annotations;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  [UsedImplicitly]
  public class OrdersDataSource : BaseDataSource
  {
    public IQueryable<Order> GetCustomerOrders(int customerId)
    {
      return Repository.Orders.Where(x => x.CustomerId == customerId);
    }
  }
}