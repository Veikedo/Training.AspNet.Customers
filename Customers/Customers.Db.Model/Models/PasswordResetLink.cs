using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Db.Models
{
  public class PasswordResetLink
  {
    [Key, ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string Guid { get; set; }
  }
}