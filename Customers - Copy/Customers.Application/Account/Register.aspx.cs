using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using Microsoft.AspNet.Membership.OpenAuth;

namespace Customers.Application.Account
{
  public partial class Register : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
      var roleName = IsCustomer.Checked ? "Customer" : "Employee";
      Roles.AddUserToRole(RegisterUser.UserName, roleName);

      FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

      string continueUrl = RegisterUser.ContinueDestinationPageUrl;
      if (!OpenAuth.IsLocalUrl(continueUrl))
      {
        continueUrl = "~/";
      }
      
      Response.Redirect(continueUrl);
    }
  }
}