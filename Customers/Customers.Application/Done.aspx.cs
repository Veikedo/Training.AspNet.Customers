using System;
using System.Web.UI;
using Customers.Application.App_GlobalResources;

namespace Customers.Application
{
  public partial class Done : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string mes = Request.QueryString["mes"];
      if (!string.IsNullOrEmpty(mes))
      {
        MessageLiteral.Text = mes;
      }

      Page.Title = GlobalRes.Done;
    }
  }
}