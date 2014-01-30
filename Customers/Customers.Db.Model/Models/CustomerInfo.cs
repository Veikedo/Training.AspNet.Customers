using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Db.Models
{
  [Table("CustomerInfo")]
  public class CustomerInfo
  {
    public CustomerInfo()
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

    public ICollection<Order> Orders { get; set; }
  }
}