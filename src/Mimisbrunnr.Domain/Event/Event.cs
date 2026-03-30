using Mimisbrunnr.Domain.Sponsor;
using System.Collections.ObjectModel;
using Ardalis.GuardClauses;
using System.Text.RegularExpressions;
using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Domain.Exceptions;

namespace Mimisbrunnr.Domain.Event
{
    public class Event : Entity
    {
        #region Fields
        private Category _category;

        private Accessibility _accessibility;

        private string _name;

        private string _location;

        private DateTime _start;

        private DateTime _end;

        private string _description;

        private string _iCal;

        private Image _banner;

        private ICollection<Sponsor.Sponsor> _sponsors;

        private string _entryFee;
        #endregion

        #region Properties
        public Category Category {get => _category; set => _category = value; }
        
        public Accessibility Accessibility {get => _accessibility; set => _accessibility = value; }
        
        public string Name { get => _name; set => _name = value; }

        public string Location { get => _location; set => _location = value; }

        public DateTime Start { get => _start; set => _start = value; }

        public DateTime End { get => _end; set => _end = value; }

        public string Description { get => _description; set => _description = value; }

        public string ICal { get => _iCal; set => _iCal = value; }

        public Image Banner { get => _banner; set => _banner = value; }

        public ICollection<Sponsor.Sponsor> Sponsors { get => _sponsors; set => _sponsors = value; }

        public string EntryFee { get => _entryFee; set => _entryFee = value; }
        #endregion

        #region Constructors
        private Event(EventBuilder builder)
        {
            _category = builder._category;
            _accessibility = builder._accessibility;
            Name = builder._name;
            Location = builder._location;
            Start = builder._start;
            End = builder._end;
            Description = builder._description;
            ICal = builder._iCal;
            Banner = builder._banner;
            Sponsors = builder._sponsors;
            EntryFee = builder._entryFee;
        }
        #endregion

        #region Methods
        public static EventBuilder builder()
        {
            return new EventBuilder();
        }
        #endregion

        #region Builder
        public class EventBuilder()
        {
            #region Fields
            private const string DEFAULT_DESCRIPTION = "No description provided.";

            internal Category _category = Category.OTHERS;

            internal Accessibility _accessibility = Accessibility.OPEN;

            internal string _name;

            internal string _location;

            internal DateTime _start;

            internal DateTime _end;

            internal string _description;

            internal string _iCal;

            internal Image _banner;

            internal ICollection<Sponsor.Sponsor> _sponsors;

            internal string _entryFee;
            #endregion

            #region Methods   
            public EventBuilder category(Category category)
            {
                _category = category;
                return this;
            }

            public EventBuilder accessibility(Accessibility accessibility)
            {
                _accessibility = accessibility;
                return this;
            }

            public EventBuilder name(string name)
            {
                _name = name;
                return this;
            }

            public EventBuilder location(string location)
            {
                _location = location;
                return this;
            }

            public EventBuilder start(DateTime start)
            {
                _start = start;
                return this;
            }

            public EventBuilder end(DateTime end)
            {
                _end = Guard.Against.NullOrInvalidInput(end, nameof(end), (e) => e >= _start);
                return this;
            }

            public EventBuilder description(string description)
            {
                _description = description;
                return this;
            }

            public EventBuilder iCal(string iCal)
            {
                _iCal = iCal;
                return this;
            }
            
            public EventBuilder banner(Image banner)
            {
                _banner = banner;
                return this;
            }

            public EventBuilder sponsors(ICollection<Sponsor.Sponsor> sponsors)
            {
                _sponsors = sponsors;
                return this;
            }

            public EventBuilder entryFee(string entryFee)
            {
                _entryFee = entryFee;
                return this;
            }

            public Event build()
            {
                HashSet<EventRequiredElement> requiredElements = new HashSet<EventRequiredElement>();

                if (_name is null || String.IsNullOrEmpty(_name))
                    requiredElements.Add(EventRequiredElement.NAME);

                if (_location is null || String.IsNullOrEmpty(_location))
                    requiredElements.Add(EventRequiredElement.LOCATION);

                if (_start.Equals(default))
                    requiredElements.Add(EventRequiredElement.START);

                if (_end.Equals(default) || _end <= _start)
                    requiredElements.Add(EventRequiredElement.END);

                if (_description is null)
                    _description = DEFAULT_DESCRIPTION;

                if (_iCal is null || !Regex.IsMatch(_entryFee, UrlGuard.PATTERN))
                    _iCal = string.Empty;

                if(_sponsors is null)
                    _sponsors = new List<Sponsor.Sponsor>();

                if(_banner is null)
                    requiredElements.Add(EventRequiredElement.BANNER);

                if(_entryFee is null || !Regex.IsMatch(_entryFee, CurrencyGuard.PATTERN))
                    _entryFee = "€0.00";

                if (requiredElements.Count > 0)
                    throw new InformationRequiredException<EventRequiredElement>(requiredElements);

                return new Event(this);
            }
            #endregion
        }
        #endregion
    }
}
