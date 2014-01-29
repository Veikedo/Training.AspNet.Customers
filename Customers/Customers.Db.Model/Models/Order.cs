namespace Customers.Db.Models
{
  public class Order : VersionableModel
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public int CustomerId { get; set; }
    public virtual CustomerInfo CustomerInfo { get; set; }
    public int ManagerId { get; set; }
    public virtual User Manager { get; set; }
  }
}