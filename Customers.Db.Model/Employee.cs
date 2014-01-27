using System.Collections.Generic;

namespace Customers.Db.Model
{
  public class Employee : VersionableEntity
  {
    public Employee()
    {
      Slaves = new List<Employee>();
      Version = 1;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public int? ManagerId { get; set; }
    public virtual Employee Manager { get; set; }

    public virtual ICollection<Employee> Slaves { get; set; }
  }
}