using System.Web.UI;
using Customers.Db.Repository;
using Ninject;
using NLog;

namespace Customers.Application
{
  public abstract class BasePage : Page
  {
    [Inject]
    public IRepository Repository { get; set; }
    public Logger Logger { get; set; }

    protected BasePage()
    {
      Logger = LogManager.GetCurrentClassLogger();
    }
  }
}