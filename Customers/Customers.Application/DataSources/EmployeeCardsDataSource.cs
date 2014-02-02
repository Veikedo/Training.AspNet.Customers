using System.Collections.Generic;
using Customers.Db.Models;

namespace Customers.Application.DataSources
{
  public class EmployeeCardsDataSource : BaseDataSource
  {
    public IEnumerable<EmployeeCard> GetEmployeeCards()
    {
      return Repository.EmployeeCards;
    }
  }
}