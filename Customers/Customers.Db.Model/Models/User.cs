using System.Collections.Generic;
using System.Collections.ObjectModel;
using Customers.Db.Repository;

namespace Customers.Db.Models
{
  public class User
  {
    public User()
    {
      Roles = new Collection<Role>();
      Version = 1;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
    public virtual PasswordResetLink PasswordResetLink { get; set; }
    public virtual CustomerCard CustomerCard { get; set; }
    public virtual EmployeeCard EmployeeCard { get; set; }
    public int Version { get; set; }
  }
}