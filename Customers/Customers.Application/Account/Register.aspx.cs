using System;
using System.Linq;
using System.Web.Security;
using Customers.Db.Models;
using Microsoft.AspNet.Membership.OpenAuth;

namespace Customers.Application.Account
{
  public partial class Register : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (User.Identity.IsAuthenticated)
      {
        Response.Redirect("~/");
      }

      RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
      AddUserToRole();

      FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

      string continueUrl = RegisterUser.ContinueDestinationPageUrl;
      if (!OpenAuth.IsLocalUrl(continueUrl))
      {
        continueUrl = "~/";
      }

      Response.Redirect(continueUrl);
    }

    private void AddUserToRole()
    {
      User user = Repository.Users.First(x => x.Name == RegisterUser.UserName);

      if (IsCustomer.Checked)
      {
        Roles.AddUserToRole(user.Name, "Customer");

        var address = new Address
        {
          House = HouseTextBox.Text,
          Street = StreetTextBox.Text
        };

        var customerInfo = new CustomerInfo
        {
          Address = address,
          CompanyName = CompanyTextBox.Text,
          User = user
        };

        Repository.CreateCustomer(customerInfo);
      }
      else
      {
        Roles.AddUserToRole(user.Name, "Employee");

        var employeeInfo = new EmployeeInfo
        {
          User = user
        };

        Repository.CreateEmployee(employeeInfo);
      }
    }

    protected void IsCustomer_OnCheckedChanged(object sender, EventArgs e)
    {
      CustomerInfoDiv.Visible = !CustomerInfoDiv.Visible;
    }
  }
}