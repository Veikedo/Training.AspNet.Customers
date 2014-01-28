using Customers.Db.Repository;
using Ninject.Modules;

namespace Customers.Application.NinjectModules
{
  public class RepositoryModule : NinjectModule
  {
    public override void Load()
    {
      Bind<IRepository>().To<EntityRepository>();
    }
  }
}