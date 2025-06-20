using Ardalis.GuardClauses;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.User
{
    internal class User
    {
        #region Fields
        private string _username;

        private string _firstName;

        private string _name;

        private MailAddress _email;

        private ICollection<UserRole> _roles;

        private string _passwordHash;
        #endregion

        #region Properties
        public string PasswordHash { set => _passwordHash = Guard.Against.NullOrEmpty(value); }

        public string Username { get => _username; set => _username = Guard.Against.NullOrEmpty(value); }

        public string FirstName { get => _firstName; set => _firstName = Guard.Against.NullOrEmpty(value); }

        public string Name { get => _name; set => _name = Guard.Against.NullOrEmpty(value); }

        public MailAddress Email { get => _email; set => _email = Guard.Against.Null(value); }

        public ICollection<UserRole> Roles { get => _roles; set => _roles = Guard.Against.Null(value); }

        #endregion

        #region Constructors
        public User(string username, string firstName, string name, MailAddress email, string passwordHash)
        {
            Username = username;
            FirstName = firstName;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Roles = new List<UserRole>();
        }
        #endregion

        public void addRole(UserRole role)
        {
            _roles.Add(role);
        }

        public void removeRole(UserRole role)
        {
            _roles.Remove(role);
        }

        public bool hasPermission(UserPermission permission)
        {
            return _roles.Any(role => role.Permissions.Contains(permission));
        }

        public bool checkPassword(string password)
        {
            //TODO: Implement password hashing mechanism
            return _passwordHash == password;
        }
    }
}