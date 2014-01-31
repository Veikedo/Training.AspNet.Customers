using System.Security.Cryptography;
using System.Text;

namespace Customers.Application.Helpers
{
  public class CryptoHelper
  {
    public static string GetPasswordHash(string password)
    {
      using (SHA1 sha1 = SHA1.Create())
      {
        var bytes = Encoding.UTF8.GetBytes(password);

        byte[] hash = sha1.ComputeHash(bytes);
        var sb = new StringBuilder(hash.Length);

        foreach (byte b in hash)
          sb.Append(b.ToString("X2"));

        return sb.ToString();
      }
    }
  }
}