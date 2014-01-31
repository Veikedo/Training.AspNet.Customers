using System;
using System.Globalization;
using System.Linq;

namespace Customers.Application.Helpers
{
  public static class CultureHelper
  {
    public static bool CustomCultureExists(string name)
    {
      CultureInfo[] userCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
      return userCultures.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
  }
}