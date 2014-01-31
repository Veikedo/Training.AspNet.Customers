using System;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web.Hosting;
using System.Web.Security;
using Customers.Application.Helpers;
using Customers.Db.Models;
using Customers.Db.Repository;
using Microsoft.Practices.ServiceLocation;

namespace Customers.Application.Providers
{
  public class TinyMembershipProvider : MembershipProvider
  {
    private const string ProviderName = "CustomMembershipProvider";
    private readonly IRepository _repository;

    public TinyMembershipProvider()
    {
      _repository = ServiceLocator.Current.GetInstance<IRepository>();
    }

    public override void Initialize(string name, NameValueCollection config)
    {
      if (string.IsNullOrEmpty(name))
      {
        name = "CustomMembershipProvider";
      }

      ApplicationName = GetConfigValue(config["applicationName"], HostingEnvironment.ApplicationVirtualPath);
      base.Initialize(name, config);
    }

    private string GetConfigValue(string configValue, string defaultValue)
    {
      return string.IsNullOrEmpty(configValue) ? defaultValue : configValue;
    }

    public override MembershipUser CreateUser(string username, string password, string email,
                                              string passwordQuestion, string passwordAnswer,
                                              bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
      var args = new ValidatePasswordEventArgs(username, password, true);
      OnValidatingPassword(args);

      if (args.Cancel)
      {
        status = MembershipCreateStatus.InvalidPassword;
        return null;
      }

      if (RequiresUniqueEmail && GetUserNameByEmail(email) != "")
      {
        status = MembershipCreateStatus.DuplicateEmail;
        return null;
      }

      if (_repository.Users.Any(x => x.Name == username))
      {
        status = MembershipCreateStatus.DuplicateUserName;
        return null;
      }

      var user = new User
      {
        Name = username,
        Email = email,
        Password = CryptoHelper.GetPasswordHash(password),
      };

      _repository.CreateUser(user);

      status = MembershipCreateStatus.Success;
      return GetUser(username, false);
    }

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
                                                         string newPasswordAnswer)
    {
      throw new NotImplementedException();
    }

    public override string GetPassword(string username, string answer)
    {
      return "Lol";
    }

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
      User user = _repository.Users.FirstOrDefault(x => x.Name == username);

      if (user != null && user.Password == CryptoHelper.GetPasswordHash(oldPassword))
      {
        user.Password = CryptoHelper.GetPasswordHash(newPassword);
        _repository.UpdateUser(user);

        return true;
      }

      return false;
    }

    public override string ResetPassword(string username, string answer)
    {
      throw new NotImplementedException();
    }

    public override void UpdateUser(MembershipUser user)
    {
      throw new NotImplementedException();
    }

    public override bool ValidateUser(string username, string password)
    {
      var user = _repository.Users.FirstOrDefault(x => x.Name == username);
      return user != null && user.Password == CryptoHelper.GetPasswordHash(password);
    }

    public override bool UnlockUser(string userName)
    {
      throw new NotImplementedException();
    }

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
      throw new NotImplementedException();
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
      User user = _repository.Users.FirstOrDefault(x => x.Name == username);

      if (user != null)
      {
        var member = new MembershipUser(ProviderName, user.Name, user.Id, user.Email,
                                        string.Empty, string.Empty, true, false, DateTime.Now,
                                        DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);

        return member;
      }

      return null;
    }

    public override string GetUserNameByEmail(string email)
    {
      User user = _repository.Users
                                 .FirstOrDefault(
                                   x => String.Compare(x.Email, email, StringComparison.OrdinalIgnoreCase) == 0);

      return user != null ? user.Email : string.Empty;
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
      throw new NotImplementedException();
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
      throw new NotImplementedException();
    }

    public override int GetNumberOfUsersOnline()
    {
      throw new NotImplementedException();
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
                                                             out int totalRecords)
    {
      throw new NotImplementedException();
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
                                                              out int totalRecords)
    {
      throw new NotImplementedException();
    }

    #region Props

    public override bool EnablePasswordRetrieval
    {
      get { return false; }
    }

    public override bool EnablePasswordReset
    {
      get { return false; }
    }

    public override bool RequiresQuestionAndAnswer
    {
      get { return false; }
    }

    public override string ApplicationName { get; set; }

    public override int MaxInvalidPasswordAttempts
    {
      get { return 10; }
    }

    public override int PasswordAttemptWindow
    {
      get { return 10; }
    }

    public override bool RequiresUniqueEmail
    {
      get { return true; }
    }

    public override MembershipPasswordFormat PasswordFormat
    {
      get { return MembershipPasswordFormat.Hashed; }
    }

    public override int MinRequiredPasswordLength
    {
      get { return 6; }
    }

    public override int MinRequiredNonAlphanumericCharacters
    {
      get { return 0; }
    }

    public override string PasswordStrengthRegularExpression
    {
      get { return ".*"; }
    }

    #endregion
  }
}