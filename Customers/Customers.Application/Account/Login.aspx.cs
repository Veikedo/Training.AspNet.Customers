using System;
using Customers.Application.App_GlobalResources;

namespace Customers.Application.Account
{
  public partial class Login : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Page.Title = GlobalRes.Login;
    }

    protected void OnLoggedIn(object sender, EventArgs e)
    {
      Response.Redirect("~/");
    }
  }
}