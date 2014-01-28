using System.Linq;
using Customers.Application.Annotations;
using Customers.Application.NinjectModules;
using Customers.Db.Models;
using Customers.Db.Repository;
using Ninject;

namespace Customers.Application.DataSources
{
  [UsedImplicitly]
  public class CustomersDataSource
  {
    public CustomersDataSource()
    {
      var kernel = new StandardKernel(new RepositoryModule());
      Repository = kernel.Get<IRepository>();
    }

    public IRepository Repository { get; set; }

    public IQueryable<Customer> GetCustomers()
    {
      return Repository.Customers;
    }
  }
}