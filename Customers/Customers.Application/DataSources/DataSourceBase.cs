using Customers.Application.NinjectModules;
using Customers.Db.Repository;
using Ninject;

namespace Customers.Application.DataSources
{
  public abstract class DataSourceBase
  {
    protected readonly IRepository Repository;

    protected DataSourceBase()
    {
      var kernel = new StandardKernel(new RepositoryModule());
      Repository = kernel.Get<IRepository>();
    }
  }
}