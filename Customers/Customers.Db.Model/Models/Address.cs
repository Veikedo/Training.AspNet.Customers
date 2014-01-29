using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Db.Models
{
  public class Address
  {
    [Key, ForeignKey("CustomerInfo")]
    public int CustomerId { get; set; }

    public virtual CustomerInfo CustomerInfo { get; set; }
    public string Street { get; set; }
    public int House { get; set; }
  }
}