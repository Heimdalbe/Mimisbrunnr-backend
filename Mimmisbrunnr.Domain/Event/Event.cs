using Ardalis.GuardClauses;
using Mimmisbrunnr.Domain.Common;

namespace Mimmisbrunnr.Domain.Event
{
    public class Event
    {
        #region Fields
        private Guid _id;
        private Category _category;
        private Accessibility _accessibility;
        #endregion

        #region Properties
        private string _name;
        public string Name { 
            get => _name; 
            set => _name = Guard.Against.NullOrWhiteSpace(value, nameof(Name)); 
        }

        private string _description;
        public string Description { 
            get => _description; 
            set => _description = Guard.Against.Null(value, nameof(Description)); 
        }

        private DateTime _start;
        public DateTime Start { 
            get => _start;
            set {
                if (_end.CompareTo(new DateTime()) != 0)
                    Guard.Against.OutOfRange(value, nameof(Start), DateTime.Now, _end, "Start date has to be set earlier than the end date!");
                _start = value;
            }
        }

        private DateTime _end;
        public DateTime End { 
            get => _end; 
            set {
                if (_start.CompareTo(new DateTime()) != 0)
                    if (value < _start) throw new ArgumentOutOfRangeException("End date has to be set later than the start date!");
                _end = value;
            }
        }

        private Image _banner;
        public Image Banner { 
            get => _banner; 
            set => _banner = Guard.Against.Null(value, nameof(Banner)); 
        }

        private Location _location;
        public Location Location { 
            get => _location; 
            set => _location = Guard.Against.Null(value, nameof(Location)); 
        }
        #endregion

        #region Constructors
        public Event(string name, 
            string description, 
            DateTime start, 
            DateTime end, 
            Image? banner, 
            Location? location,
            Category category,
            Accessibility accessibility)
        {
            Name = name;
            Description = description;
            Start = start;
            End = end;
            Banner = banner;
            Location = location;
            _category = Guard.Against.EnumOutOfRange(category, nameof(category));
            _accessibility = Guard.Against.EnumOutOfRange(accessibility, nameof(accessibility));
        }

        #endregion
    }
}
