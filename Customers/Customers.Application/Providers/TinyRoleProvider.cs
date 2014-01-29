using System;
using System.Collections.Specialized;
using System.Web.Hosting;
using System.Web.Security;
using Customers.Db.Repository;
using Microsoft.Practices.ServiceLocation;

namespace Customers.Application.Providers
{
  public class TinyRoleProvider : RoleProvider
  {
    private IRepository _repository;

    public TinyRoleProvider()
    {
      _repository = ServiceLocator.Current.GetInstance<IRepository>();
    }

    public override string ApplicationName { get; set; }

    private string GetConfigValue(string configValue, string defaultValue)
    {
      return string.IsNullOrEmpty(configValue) ? defaultValue : configValue;
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

    public override bool IsUserInRole(string username, string roleName)
    {
      return false;
    }

    public override string[] GetRolesForUser(string username)
    {
      throw new NotImplementedException();
    }

    public override void CreateRole(string roleName)
    {
      throw new NotImplementedException();
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
      throw new NotImplementedException();
    }

    public override bool RoleExists(string roleName)
    {
      throw new NotImplementedException();
    }

    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
      throw new NotImplementedException();
    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
      throw new NotImplementedException();
    }

    public override string[] GetUsersInRole(string roleName)
    {
      throw new NotImplementedException();
    }

    public override string[] GetAllRoles()
    {
      throw new NotImplementedException();
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
      throw new NotImplementedException();
    }
  }
}