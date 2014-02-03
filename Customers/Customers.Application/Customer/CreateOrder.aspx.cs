using System;
using System.Linq;
using Customers.Application.App_GlobalResources;
using Customers.Db.Models;

namespace Customers.Application.Customer
{
  public partial class CreateOrder : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!User.Identity.IsAuthenticated || !User.IsInRole("Customer"))
      {
        Response.Redirect("~/Message.aspx?mes=" + GlobalRes.AccessNotAllowed, true);
      }
      
      Page.Title = GlobalRes.CreateOrder;
    }

    protected void Managers_SelectedIndexChanged(object sender, EventArgs e)
    {
      OrderDescriptionDiv.Visible = true;
    }

    protected void CreateOrderButton_Click(object sender, EventArgs e)
    {
      if (ManagersGridView.SelectedDataKey != null)
      {
        var managerId = (int) ManagersGridView.SelectedDataKey["UserId"];
        int customerId = Repository.CustomerCards.First(x => x.User.Name == User.Identity.Name).UserId;

        var order = new Order
        {
          ManagerId = managerId,
          CustomerId = customerId,
          Description = DescriptionTextBox.Text
        };

        Repository.CreateOrder(order);
        Response.Redirect("~/Message.aspx?mes=" + GlobalRes.OrderCreated);
      }
    }
  }
}