using System;
using System.Linq;

namespace Customers.Application
{
  public partial class EmployeeInformation : BasePage
  {
    protected bool IsOwner
    {
      get { return User.Identity.Name == Repository.Users.First(x => x.Id == QueryId).Name; }
    }

    private int? QueryId
    {
      get
      {
        int id;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
          return id;
        }

        return null;
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      // if employee with requested id is missing
      if (QueryId == null || Repository.Employees.All(x => x.UserId != QueryId))
      {
        Response.Redirect("~/Default.aspx");
      }
    }
  }
}