using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Services.Description;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Customers.Db;
using Customers.Db.Repository;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Customers.Application
{
  public class Global : HttpApplication
  {
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
      kernel.Bind<IRepository>().To<EntityRepository>();

      ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
    }

    private void Application_End(object sender, EventArgs e)
    {
      //  Code that runs on application shutdown
    }

    private void Application_Error(object sender, EventArgs e)
    {
      // Code that runs when an unhandled error occurs
      Response.Redirect("~/Error.aspx");
    }
  }
}