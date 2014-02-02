using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Db.Models
{
  public class CustomerCard
  {
    public CustomerCard()
    {
      Orders = new Collection<Order>();
    }

    [Key, ForeignKey("User")]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    [Required]
    public string CompanyName { get; set; }

    [Required]
    public virtual Address Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
  }
}