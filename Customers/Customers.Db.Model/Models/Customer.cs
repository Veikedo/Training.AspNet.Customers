using System.Collections.Generic;

namespace Customers.Db.Models
{
  public class Customer : VersionableModel
  {
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public virtual Address Address { get; set; }
    public ICollection<Order> Orders { get; set; }
  }
}