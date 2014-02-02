using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using Customers.Application.App_GlobalResources;

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
      if (QueryId == null || Repository.EmployeeCards.All(x => x.UserId != QueryId))
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

    protected void UserView_OnItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
      var name = (string) e.NewValues["Name"];
      var anyUser = Repository.Users.Any(x => x.Name == name);

      if (anyUser)
      {
        e.Cancel = true;
        Response.Redirect("~/Message.aspx?mes=" + GlobalRes.UserAlreadyExists, true);
      }
    }
  }
}