namespace Customers.Db.Model
{
  public class VersionableEntity
  {
    public VersionableEntity()
    {
      Version = 1;
    }

    public int Version { get; set; }
  }
}