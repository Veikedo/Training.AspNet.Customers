using Customers.Db.Repository;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Customers.Application.DataSources
{
  public abstract class BaseDataSource
  {
    protected readonly IRepository Repository;

    protected BaseDataSource()
    {
      Repository = ServiceLocator.Current.GetInstance<IRepository>();
    }
  }
}