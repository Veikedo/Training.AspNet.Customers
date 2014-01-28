using Ninject;

namespace Customers.Db.Repository
{
  public partial class EntityRepository : IRepository
  {
    [Inject]
    public ProjectsDbContext Db { get; set; }
  }
}