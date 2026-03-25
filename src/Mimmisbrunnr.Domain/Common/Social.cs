using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.Common
{
    public class Social : Entity
    {
        #region Fields
        private SocialType _type;

        private string _url;
        #endregion
        
        #region Properties
        public SocialType Type { get => _type; set => _type = Guard.Against.Null(value); }

        public string Url { get => _url; set => _url = Guard.Against.Url(value); }
        #endregion

        #region Constructors
        public Social(SocialType type, string url)
        {
            Type = type;
            Url = Guard.Against.NullOrWhiteSpace(url, nameof(url));
        }
        #endregion
    }
}
