using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public interface IRepository
  {
    #region CustomerInfo

    IQueryable<CustomerInfo> CustomersInfo { get; }

    bool CreateCustomerInfo(CustomerInfo instance);
    bool UpdateCustomerInfo(CustomerInfo instance);
    bool RemoveCustomerInfo(int idCustomer);

    #endregion

    #region User

    IQueryable<User> Users { get; }
    bool CreateUser(User instance);
    bool UpdateUser(User instance);
    bool RemoveUser(int idEmployee);

    #endregion

    #region Order

    IQueryable<Order> Orders { get; }
    bool CreateOrder(Order instance);
    bool UpdateOrder(Order instance);
    bool RemoveOrder(int idOrder);

    #endregion

    #region Role

    IQueryable<Role> Roles { get; }
    bool CreateRole(Role instance);
    bool UpdateRole(Role instance);
    bool RemoveRole(int idRole);

    #endregion
  }
}