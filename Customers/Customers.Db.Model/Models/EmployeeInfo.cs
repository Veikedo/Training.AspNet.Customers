using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Db.Models
{
  [Table("EmployeeInfo")]
  public class EmployeeInfo
  {
    public EmployeeInfo()
    {
      Slaves = new Collection<EmployeeInfo>();
    }

    [Key, ForeignKey("User")]
    public int UserId { get; set; }

    public virtual User User { get; set; }
    
    public int? ManagerId { get; set; }

    [ForeignKey("ManagerId")]
    public virtual EmployeeInfo Manager { get; set; }
    public virtual ICollection<EmployeeInfo> Slaves { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
  }
}