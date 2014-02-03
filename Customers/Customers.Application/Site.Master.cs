using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace Customers.Application
{
  public partial class SiteMaster : MasterPage
  {
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    private string CurrentCulture
    {
      get { return (string) Session["culture"]; }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
      // The code below helps to protect against XSRF attacks
      HttpCookie requestCookie = Request.Cookies[AntiXsrfTokenKey];
      Guid requestCookieGuidValue;
      if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
      {
        // Use the Anti-XSRF token from the cookie
        _antiXsrfTokenValue = requestCookie.Value;
        Page.ViewStateUserKey = _antiXsrfTokenValue;
      }
      else
      {
        // Generate a new Anti-XSRF token and save to the cookie
        _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
        Page.ViewStateUserKey = _antiXsrfTokenValue;

        var responseCookie = new HttpCookie(AntiXsrfTokenKey)
        {
          HttpOnly = true,
          Value = _antiXsrfTokenValue
        };
        if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
        {
          responseCookie.Secure = true;
        }
        Response.Cookies.Set(responseCookie);
      }

      Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        // Set Anti-XSRF token
        ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
        ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
      }
      else
      {
        // Validate the Anti-XSRF token
        if ((string) ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
            || (string) ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
        {
          throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
        }
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      LanguageToggle.Text = CurrentCulture == "ru-RU" ? "English" : "Русский";

      var user = HttpContext.Current.User;
      if (user.Identity.IsAuthenticated)
      {
        if (user.IsInRole("Customer"))
        {
          CreateOrderLink.Visible = true;
        }
      }
    }

    protected void LanguageToggle_Click(object sender, EventArgs e)
    {
      ToggleCulture();
    }

    private void ToggleCulture()
    {
      Session["culture"] = CurrentCulture == "ru-RU" ? "en-US" : "ru-RU";
      Response.Redirect(Request.RawUrl, true);
    }
  }
}