using System;

namespace Customers.Application
{
  public partial class Done : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string mes = Request.QueryString["mes"];
      if (!string.IsNullOrEmpty(mes))
      {
        Message.Text = mes;
      }

      Page.Title = mes;
    }
  }
}