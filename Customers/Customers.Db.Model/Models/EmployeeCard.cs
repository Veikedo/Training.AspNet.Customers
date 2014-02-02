using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Db.Models
{
  public class EmployeeCard
  {
    public EmployeeCard()
    {
      Slaves = new Collection<EmployeeCard>();
    }

    [Key, ForeignKey("User")]
    public int UserId { get; set; }

    public virtual User User { get; set; }
    
    public int? ManagerId { get; set; }

    [ForeignKey("ManagerId")]
    public virtual EmployeeCard Manager { get; set; }
    public virtual ICollection<EmployeeCard> Slaves { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
  }
}