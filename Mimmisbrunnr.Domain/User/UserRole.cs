using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.User
{
    internal class UserRole
    {
        #region Fields
        private string _name;

        private ICollection<UserPermission> _permissions = new List<UserPermission>();
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = Guard.Against.NullOrEmpty(value); }

        public ICollection<UserPermission> Permissions { get => _permissions; set => _permissions = Guard.Against.Null(value); }
        #endregion

        #region Constructors
        public UserRole(string name, ICollection<UserPermission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }

        public UserRole(string name) : this(name, new List<UserPermission>())
        {
        }
        #endregion

        public void AddPermission(UserPermission permission)
        {
            Guard.Against.Null(permission, nameof(permission));
            if (!_permissions.Contains(permission))
            {
                _permissions.Add(permission);
            }
        }
        public void RemovePermission(UserPermission permission)
        {
            Guard.Against.Null(permission, nameof(permission));
            if (_permissions.Contains(permission))
            {
                _permissions.Remove(permission);
            }
        }
    }
}
