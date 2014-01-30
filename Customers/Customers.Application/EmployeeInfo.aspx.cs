using System;

namespace Customers.Application
{
  public partial class EmployeeInformation : BasePage
  {
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