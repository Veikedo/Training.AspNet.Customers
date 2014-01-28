namespace Customers.Db.Models
{
  public class Order : VersionableModel
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public int ManagerId { get; set; }
    public virtual Employee Manager { get; set; }
  }
}