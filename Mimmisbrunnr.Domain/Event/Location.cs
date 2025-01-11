using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.Event
{
    public class Location
    {
        #region Fields
        private Guid _id;
        private string _title;
        #endregion

        #region Properties
        private string _address;
        public string Address { get => _address; set => _address = value; }

        private string _city;
        public string City { get => _city; set => _city = value; }

        public ICollection<Event> Events { get; set; }
        #endregion

        public Location(string title, string address, string city) { 
            _title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
            _address = Guard.Against.NullOrWhiteSpace(address, nameof(address));
            _city = Guard.Against.NullOrWhiteSpace(city, nameof(city));
        }
    }
}
