using Ardalis.GuardClauses;
using Mimmisbrunnr.Domain.Base;
using Mimmisbrunnr.Domain.Common;

namespace Mimmisbrunnr.Domain.Activities
{
    public class Activity : Entity
    {
        #region Fields
        public Category Category { get; protected set; }
        public Accessibility Accessibility { get; protected set; }
        #endregion

        #region Properties
        private string _name;
        /// <summary>
        /// The name of the event
        /// </summary>
        /// <example>Karakoe</example>
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

        //TODO: Add price object containing price for heimies and non-heimies
        #region Constructors
        public Activity(string name, 
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
            Category = Guard.Against.EnumOutOfRange(category, nameof(category));
            Accessibility = Guard.Against.EnumOutOfRange(accessibility, nameof(accessibility));
            TimeCreated = DateTime.UtcNow;
            TimeUpdated = DateTime.UtcNow;
        }

        #endregion
    }
}
