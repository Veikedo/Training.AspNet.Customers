using System;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using Customers.Application.App_GlobalResources;
using Customers.Db.Models;

namespace Customers.Application
{
  public partial class Default : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Page.Title = GlobalRes.Orders;
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
          Logger.Warn("Access to EmployeeInformation using invalid orderId");
        }
      }
    }

    protected void CustomersGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        var rowItem = (CustomerCard) e.Row.DataItem;
        var customer = Repository.CustomerCards.First(x => x.UserId == rowItem.UserId);

        if (customer.Orders.Count > 0)
        {
          e.Row.BorderColor = Color.Goldenrod;
          e.Row.BorderWidth = new Unit(1);
          e.Row.BorderStyle = BorderStyle.Dashed;
        }
      }
    }
  }
}