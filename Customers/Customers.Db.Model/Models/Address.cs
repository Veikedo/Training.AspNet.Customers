using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Db.Models
{
  public class Address
  {
    [Key, ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public virtual CustomerCard Customer { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
  }
}