using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimisbrunnr.Domain.Common
{
    public class SocialType : Entity
    {
        #region Fields
        private string _name;

        private Image _icon;
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = Guard.Against.NullOrEmpty(value); }

        public Image Icon { get => _icon; set => _icon = Guard.Against.Null(value); }
        #endregion

        #region Constructors
        
        private SocialType() { }
        public SocialType(string name, Image icon)
        {
            Name = name;
            Icon = icon;
        }
        #endregion
    }
}