using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public interface IRepository
  {
    #region Customer

    IQueryable<CustomerInfo> Customers { get; }
    bool CreateCustomer(CustomerInfo instance);
    bool UpdateCustomer(CustomerInfo instance);
    bool RemoveCustomer(int idCustomer);

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

    #region Employee

    IQueryable<EmployeeInfo> Employees { get; }
    bool CreateEmployee(EmployeeInfo instance);
    bool UpdateEmployee(EmployeeInfo instance);
    bool RemoveEmployee(int idRole);

    #endregion

    #region PasswordResetLink

    IQueryable<PasswordResetLink> PasswordResetLinks { get; }
    bool CreatePasswordResetLink(PasswordResetLink instance);
    bool UpdatePasswordResetLink(PasswordResetLink instance);
    bool RemovePasswordResetLink(int idResetLink);

    #endregion 
  }
}