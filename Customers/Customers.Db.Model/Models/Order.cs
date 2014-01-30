using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Db.Models
{
  public class Order
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public virtual CustomerInfo Customer { get; set; }

    public int ManagerId { get; set; }

    [ForeignKey("ManagerId")]
    public virtual EmployeeInfo Manager { get; set; }
  }
}