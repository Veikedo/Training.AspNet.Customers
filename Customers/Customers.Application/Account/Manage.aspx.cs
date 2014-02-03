using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using Customers.Application.App_GlobalResources;
using Customers.Application.Helpers;
using Customers.Db.Models;

namespace Customers.Application.Account
{
  public partial class Manage : BasePage
  {
    private EmployeeCard _authenticatedEmployee;
    protected string SuccessMessage { get; private set; }

    protected void Page_Load()
    {
      Page.Title = GlobalRes.ManageAccount;

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
      }

      if (User.IsInRole("Employee"))
      {
        _authenticatedEmployee = Repository.EmployeeCards.AsNoTracking().First(x => x.User.Name == User.Identity.Name);
        SelectManagerDiv.Visible = true;
      }
    }

    protected void EmployeesGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
      DataKey key = ManagersGridView.DataKeys[ManagersGridView.SelectedIndex];
      if (key != null)
      {
        var selectedManagerId = (int) key.Value;
        var manager = Repository.EmployeeCards.First(x => x.UserId == selectedManagerId);

        if (_authenticatedEmployee.ManagerId != manager.UserId)
        {
          _authenticatedEmployee.ManagerId = manager.UserId;
          Repository.UpdateEmployeeCard(_authenticatedEmployee);
        }
      }
    }

    protected void ManagersGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      var rowItem = e.Row.DataItem as EmployeeCard;
      if (rowItem != null)
      {
        if (rowItem.UserId == _authenticatedEmployee.UserId)
        { 
          e.Row.Visible = false;
        }
        else if(rowItem.UserId == _authenticatedEmployee.ManagerId)
        {
          ManagersGridView.SelectRow(e.Row.RowIndex);
          e.Row.BackColor = ColorTranslator.FromHtml("#E5E5E5");
          //          ManagersGridView.SelectedIndex = e.Row.RowIndex-1;
        }
      }
    }
  }
}