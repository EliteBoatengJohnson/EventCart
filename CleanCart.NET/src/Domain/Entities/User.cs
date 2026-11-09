using System;

namespace Domain.Entities;

public class User
{
    private readonly List<UserRole> _roles = new();

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string UserName { get;}
    public string Email { get; }

    public string FullName { get; }
    public IReadOnlyCollection<UserRole> Roles => _roles.AsReadOnly();

    public User(string username, string email, string fullname, IEnumerable<UserRole> roles)
    {
        UserName = username;
        Email = email;
        FullName = fullname;
        _roles.AddRange(roles);
    }


    public void AddRole(UserRole role)
    {
        if(!_roles.Contains(role))
        {
            _roles.Add(role);
        }
    }

    public void RemoveRole(UserRole role)
    {
        _roles.Remove(role);
    }

}
