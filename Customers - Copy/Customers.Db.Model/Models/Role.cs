using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Customers.Db.Models
{
  public class Role
  {
    public Role()
    {
      Users = new Collection<User>();
    }

    public int Id { get; set; }

    public string Code { get; set; }
    public virtual ICollection<User> Users { get; set; }
  }
}