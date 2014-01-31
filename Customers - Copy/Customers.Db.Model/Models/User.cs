using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Customers.Db.Models
{
  public class User : VersionableModel
  {
    public User()
    {
      Slaves = new Collection<User>();
      Orders = new Collection<Order>();
      Roles = new Collection<Role>();
      Version = 1;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public int? ManagerId { get; set; }
    public virtual User Manager { get; set; }

    public string Password { get; set; }
    public string Email { get; set; }

    public virtual ICollection<User> Slaves { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Role> Roles { get; set; }

    public virtual CustomerInfo CustomerInfo { get; set; }

    public bool IsCustomer
    {
      get { return Roles.Any(x => x.Code == "Customer"); }
    }
  }
}