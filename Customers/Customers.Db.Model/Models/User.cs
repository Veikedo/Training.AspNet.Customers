using System.Collections.Generic;
using System.Collections.ObjectModel;

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
    public virtual CustomerInfo CustomerInfo { get; set; }
    public virtual EmployeeInfo EmployeeInfo { get; set; }
    public int Version { get; set; }
  }
}