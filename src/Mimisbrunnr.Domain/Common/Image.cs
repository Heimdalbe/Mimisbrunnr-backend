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
        private string? _description;
        #endregion

        #region Properties
        public string Description { 
            get => _description ?? ""; 
            set => _description = Guard.Against.Null(value, nameof(Description)); 
        }
        
        public string Url
        {
            get => _url;
        }
        #endregion

        #region Constructors
        public Image(string url, string description) : this(url)
        {
            Description = description;
        }

        public Image(string url)
        {
            Guard.Against.NullOrWhiteSpace(url, nameof(url));
            _url = Guard.Against.Url(url, nameof(url));
        }
        #endregion
    }
}
