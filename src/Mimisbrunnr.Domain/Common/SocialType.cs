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
        
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = Guard.Against.NullOrEmpty(value); }
        
        #endregion

        #region Constructors
        
        private SocialType() { }
        public SocialType(string name)
        {
            Name = name;
        }
        #endregion
    }
}