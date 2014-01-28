using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Customers.Db.Models
{
  public class Customer : VersionableModel
  {
    public int Id { get; set; }

    [Required]
    public string CompanyName { get; set; }

    [Required]
    public virtual Address Address { get; set; }
    public ICollection<Order> Orders { get; set; }
  }
}