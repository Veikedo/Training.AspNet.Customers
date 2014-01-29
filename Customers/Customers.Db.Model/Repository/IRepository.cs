using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public interface IRepository
  {
    #region Customer

    IQueryable<Customer> Customers { get; }

    bool CreateCustomer(Customer instance);
    bool UpdateCustomer(Customer instance);
    bool RemoveCustomer(int idCustomer);

    #endregion

    #region Employee

    IQueryable<Employee> Employees { get; }
    bool CreateEmployee(Employee instance);
    bool UpdateEmployee(Employee instance);
    bool RemoveEmployee(int idEmployee);

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