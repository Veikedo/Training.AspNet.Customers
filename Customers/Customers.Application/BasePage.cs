using System.Globalization;
using System.Threading;
using System.Web.UI;
using Customers.Application.Helpers;
using Customers.Db.Repository;
using Ninject;
using NLog;

namespace Customers.Application
{
  public abstract class BasePage : Page
  {
    public enum ApplicationCulture
    {
      Russian,
      English
    }

    protected BasePage()
    {
      Logger = LogManager.GetCurrentClassLogger();
    }

    public ApplicationCulture CurrentCulture
    {
      get { return (string) Session["culture"] == "ru-RU" ? ApplicationCulture.Russian : ApplicationCulture.English; }
    }

    [Inject]
    public IRepository Repository { get; set; }

    public Logger Logger { get; set; }

    protected override void InitializeCulture()
    {
      var culture = Session["culture"] as string;

      if (string.IsNullOrEmpty(culture) || !CultureHelper.CustomCultureExists(culture))
      {
        Session["culture"] = culture = "ru-RU";
      }

      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
      Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

      base.InitializeCulture();
    }
  }
}