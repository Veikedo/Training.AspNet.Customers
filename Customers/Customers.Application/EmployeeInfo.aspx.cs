using System;
using System.Linq;

namespace Customers.Application
{
  public partial class EmployeeInformation : BasePage
  {
    public bool IsOwner
    {
      get { return User.Identity.Name == Repository.Users.FirstOrDefault(x => x.Id == EmployeeId).Name; }
    }

    public int EmployeeId
    {
      get { return Convert.ToInt32(Request.QueryString["id"]); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      bool hasNoId = string.IsNullOrEmpty(Request.QueryString["id"]);

      if (hasNoId)
      {
        Response.Redirect("~/Default.aspx");
      }
    }
  }
}