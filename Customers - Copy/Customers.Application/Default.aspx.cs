using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Customers.Application
{
  public partial class Default : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void OrdersGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "GetManagerInfoCommand")
      {
        int index = Convert.ToInt32(e.CommandArgument);
        DataKey key = OrdersGridView.DataKeys[index];
        int orderId;

        if (key != null && int.TryParse(key.Value.ToString(), out orderId))
        {
          Response.Redirect("EmployeeInfo.aspx?id=" + orderId, true);
        }
        else
        {
          Logger.Warn("Access to EmployeeInfo using invalid orderId");
        }
      }
    }
  }
}