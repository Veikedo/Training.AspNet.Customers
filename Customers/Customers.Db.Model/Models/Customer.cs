using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Customers.Db.Models
{
  public class Customer : VersionableModel
  {
    public Customer()
    {
      Roles = new Collection<Role>();
      Orders = new Collection<Order>();
    }

    public int Id { get; set; }

    [Required]
    public string CompanyName { get; set; }

    [Required]
    public virtual Address Address { get; set; }

    public ICollection<Order> Orders { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
  }
}