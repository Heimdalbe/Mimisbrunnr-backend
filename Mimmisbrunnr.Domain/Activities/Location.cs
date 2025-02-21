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
        public string Title { get; protected set; }
        #endregion

        #region Properties
        private string _address;
        public string Address { 
            get => _address;
            set => _address = Guard.Against.NullOrWhiteSpace(value, nameof(Address)); 
        }

        private string _city;
        public string City { 
            get => _city; 
            set => _city = Guard.Against.NullOrWhiteSpace(value, nameof(City)); 
        }

        public ICollection<Activity> Events { get; set; }
        #endregion

        #region Constructors
        public Location() { }

        public Location(string title, string address, string city) { 
            Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
            Address = address;
            City = city;
        }
        #endregion
    }
}
