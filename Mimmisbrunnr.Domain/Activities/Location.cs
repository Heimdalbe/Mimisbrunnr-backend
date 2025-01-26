using Ardalis.GuardClauses;
using Mimmisbrunnr.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.Activities
{
    public class Location : Entity
    {
        #region Fields
        private string _title;
        #endregion

        #region Properties
        private string _address;
        public string Address { get => _address; set => _address = value; }

        private string _city;
        public string City { get => _city; set => _city = value; }

        public ICollection<Activity> Events { get; set; }
        #endregion

        #region Constructors
        public Location() { }

        public Location(string title, string address, string city) { 
            _title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
            _address = Guard.Against.NullOrWhiteSpace(address, nameof(address));
            _city = Guard.Against.NullOrWhiteSpace(city, nameof(city));
        }
        #endregion
    }
}
