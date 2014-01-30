using System.Collections.Specialized;
using System.Linq;
using System.Web.Hosting;
using System.Web.Security;
using Customers.Db.Models;
using Customers.Db.Repository;
using Microsoft.Practices.ServiceLocation;

namespace Customers.Application.Providers
{
  public class TinyRoleProvider : RoleProvider
  {
    private readonly IRepository _repository;

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
      User user = _repository.Users.FirstOrDefault(x => x.Name == username);
      return user != null && user.Roles.Any(x => x.Code == roleName);
    }

    public override string[] GetRolesForUser(string username)
    {
      User user = _repository.Users.FirstOrDefault(x => x.Name == username);
      return user == null ? new string[1] : user.Roles.Select(x => x.Code).ToArray();
    }

    public override void CreateRole(string roleName)
    {
      var instance = new Role {Code = roleName};
      _repository.CreateRole(instance);
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
      Role role = _repository.Roles.FirstOrDefault(x => x.Code == roleName);

      if (role != null)
      {
        _repository.RemoveRole(role.Id);
      }

      return role != null;
    }

    public override bool RoleExists(string roleName)
    {
      return _repository.Roles.Any(x => x.Code == roleName);
    }

    public override void AddUsersToRoles(string[] usernames, string[] roleCodes)
    {
      var users = _repository.Users.Where(x => usernames.Any(y => y == x.Name)).ToList();
      var roles = _repository.Roles.Where(x => roleCodes.Any(y => y == x.Code)).ToList();

      foreach (Role t in roles)
      {
        Role role = t;
        foreach (User user in users.Where(x => role.Users.All(y => y.Id != x.Id)))
        {
          role.Users.Add(user);
        }

        _repository.UpdateRole(role);
      }

/*
      foreach (User t in users)
      {
        User user = t;
        foreach (Role role in roles.Where(x => user.Roles.All(y => y.Id != x.Id)))
        {
          user.Roles.Add(role);
        }

        _repository.UpdateUser(user);
      }
*/
    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
      IQueryable<User> users = _repository.Users.Where(x => usernames.Any(y => y == x.Name));
      IQueryable<Role> roles = _repository.Roles.Where(x => roleNames.Any(y => y == x.Code));

      foreach (User t in users)
      {
        User user = t;
        foreach (Role role in roles.Where(x => user.Roles.Any(y => y.Id == x.Id)))
        {
          user.Roles.Remove(role);
        }

        _repository.UpdateUser(user);
      }
    }

    public override string[] GetUsersInRole(string roleName)
    {
      Role role = _repository.Roles.FirstOrDefault(x => x.Code == roleName);
      return role != null ? role.Users.Select(x => x.Name).ToArray() : new string[1];
    }

    public override string[] GetAllRoles()
    {
      return _repository.Roles.Select(x => x.Code).ToArray();
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
      Role role = _repository.Roles.FirstOrDefault(x => x.Code == roleName);

      if (role == null)
      {
        return new string[1];
      }

      return role.Users.Where(x => x.Name.Contains(usernameToMatch)).Select(x => x.Name).ToArray();
    }
  }
}