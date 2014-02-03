using System;
using System.Collections.Generic;

namespace Customers.Application.Helpers
{
  public static class EnumerableExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="func"></param>
    /// <returns>-1 if element doesn't exists</returns>
    public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> func)
    {
      int idx = 0;
      foreach (T t in source)
      {
        if (func(t))
        {
          return idx;
        }

        idx++;
      }

      return -1;
    }
  }
}