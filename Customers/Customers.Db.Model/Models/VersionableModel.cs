namespace Customers.Db.Models
{
  public class VersionableModel
  {
    public VersionableModel()
    {
      Version = 1;
    }

    public int Version { get; set; }
  }
}