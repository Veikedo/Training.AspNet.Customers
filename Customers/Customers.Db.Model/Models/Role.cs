using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Customers.Db.Models
{
  public class Role
  {
    public Role()
    {
      Employees = new Collection<Employee>();
      Customers = new Collection<Customer>();
    }

    public int Id { get; set; }
    
    public string Code { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
  }
}