using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.Common
{
    public class Image
    {
        #region Fields
        private Guid _id;
        private string _url;
        #endregion

        #region Properties
        private string? _description;
        public string Description { 
            get => _description ?? ""; 
            set => _description = Guard.Against.Null(value, nameof(Description)); 
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
