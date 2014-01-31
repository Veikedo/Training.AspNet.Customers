using System;
using Customers.Application.App_GlobalResources;

namespace Customers.Application.Account
{
  public partial class Manage : BasePage
  {
    protected string SuccessMessage { get; private set; }

    protected void Page_Load()
    {
      if (!IsPostBack)
      {
        // Determine the sections to render
        const bool hasLocalPassword = true;
        changePassword.Visible = hasLocalPassword;

        // Render success message
        string message = Request.QueryString["m"];
        if (message != null)
        {
          // Strip the query string from action
          Form.Action = ResolveUrl("~/Account/Manage");

          SuccessMessage =
            message == "ChangePwdSuccess" ? GlobalRes.password_has_been_changed
              : message == "SetPwdSuccess" ? GlobalRes.Manage_Page_Load_Your_password_has_been_set_
                  : message == "RemoveLoginSuccess" ? GlobalRes.Manage_Page_Load_The_external_login_was_removed_
                      : String.Empty;
          successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
        }

        Page.Title = GlobalRes.ManageAccount;
      }
    }
  }
}