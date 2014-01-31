using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Customers.Application.App_GlobalResources;

namespace Customers.Application
{
  public partial class Error : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Page.Title = GlobalRes.Error;
    }
  }
}