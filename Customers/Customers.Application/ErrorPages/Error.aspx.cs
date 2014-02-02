using System;
using Customers.Application.App_GlobalResources;

namespace Customers.Application.ErrorPages
{
  public partial class Error : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Page.Title = GlobalRes.Error;
    }
  }
}