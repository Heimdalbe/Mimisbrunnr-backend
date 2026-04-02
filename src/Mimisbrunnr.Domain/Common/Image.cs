using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimisbrunnr.Domain.Common
{
    public class Image : Entity
    {
        #region Fields
        private string _url;
        private string _description;
        #endregion

        #region Properties
        public string Description { 
            get => _description ?? ""; 
            set => _description = Guard.Against.Null(value); 
        }
        
        public string Url
        {
            get => _url;
            private set => _url = Guard.Against.Null(value);
        }
        #endregion

        #region Constructors
        public Image(string url, string description)
        {
            Description = description;
        }

        public Image(string url) : this(url, "")
        {
            Guard.Against.NullOrWhiteSpace(url);
            Url = Guard.Against.Url(url);
        }
        #endregion
    }
}
