using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Customers.Db;
using Customers.Db.Repository;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using NLog;

namespace Customers.Application
{
  public class Global : HttpApplication
  {
    private Logger _logger;

    private void Application_Start(object sender, EventArgs e)
    {
      // Code that runs on application startup
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      AuthConfig.RegisterOpenAuth();
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      RegisterDependencyResolver();
    }

    private void RegisterDependencyResolver()
    {
      var kernel = new StandardKernel();
      kernel.Bind<ProjectsDbContext>().ToMethod(c => new ProjectsDbContext());
      kernel.Bind<Logger>().ToMethod(c => LogManager.GetCurrentClassLogger());
      kernel.Bind<IRepository>().To<EntityRepository>();

      ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
      _logger = ServiceLocator.Current.GetInstance<Logger>();
    }

    private void Application_End(object sender, EventArgs e)
    {
      //  Code that runs on application shutdown
    }

    private void Application_Error(object sender, EventArgs e)
    {
      Exception exc = Server.GetLastError();
      _logger.FatalException("Such cases", exc);
      
      Response.Redirect("~/ErrorPages/Error.aspx");
    }
  }
}