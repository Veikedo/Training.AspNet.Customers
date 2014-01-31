﻿using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;

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
        Response.Redirect("~/ErrorPages/NoSuchPage.aspx", true);
      }
    }

    protected void UserView_OnItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
      FormsAuthentication.SignOut();

      var newName = (string) e.NewValues["Name"];
      FormsAuthentication.SetAuthCookie(newName, true);

      Response.Redirect(Request.RawUrl);
    }
  }
}