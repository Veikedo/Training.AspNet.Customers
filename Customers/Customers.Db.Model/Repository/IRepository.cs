using System.Linq;
using Customers.Db.Models;

namespace Customers.Db.Repository
{
  public interface IRepository
  {
    #region Customer

    IQueryable<CustomerCard> CustomerCards { get; }
    bool CreateCustomerCard(CustomerCard instance);
    bool UpdateCustomerCard(CustomerCard instance);
    bool RemoveCustomerCard(int idCustomerCard);

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

    IQueryable<EmployeeCard> EmployeeCards { get; }
    bool CreateEmployeeCard(EmployeeCard instance);
    bool UpdateEmployeeCard(EmployeeCard instance);
    bool RemoveEmployeeCard(int idEmployeeCard);

    #endregion

    #region PasswordResetLink

    IQueryable<PasswordResetLink> PasswordResetLinks { get; }
    bool CreatePasswordResetLink(PasswordResetLink instance);
    bool UpdatePasswordResetLink(PasswordResetLink instance);
    bool RemovePasswordResetLink(int idResetLink);

    #endregion 
  }
}