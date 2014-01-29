using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Db.Models
{
  public class Employee : VersionableModel
  {
    public Employee()
    {
      Slaves = new Collection<Employee>();
      Orders = new Collection<Order>();
      Roles = new Collection<Role>();
      Version = 1;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public int? ManagerId { get; set; }
    public virtual Employee Manager { get; set; }

    public string Password { get; set; }
    public string Email { get; set; }

    public virtual ICollection<Employee> Slaves { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
  }
}
