using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Domain.Sponsors;

namespace Mimisbrunnr.Domain.Events
{
    public class Event : Entity
    {
        #region Fields
        private Category _category;

        private Accessibility _accessibility;

        private string _name;

        private string? _location;

        private DateTime? _start;

        private DateTime? _end;

        private string? _description;

        private string? _iCal;

        private Image? _banner;

        private ICollection<Sponsor> _sponsors = new List<Sponsor>();

        private string? _entryFee;

        private bool _published;
        #endregion

        #region Properties
        public Category Category {get => _category; set => _category = Guard.Against.Null(value); }
        
        public Accessibility Accessibility {get => _accessibility; set => _accessibility = Guard.Against.Null(value); }
        
        public string Name { get => _name; set => _name = Guard.Against.NullOrEmpty(value); }

        public string? Location { get => _location; set => _location = Guard.Against.NullOrEmpty(value); }

        public DateTime? Start { get => _start; set => _start = Guard.Against.Null(value); }

        public DateTime? End { get => _end; set => _end = Guard.Against.Null(value); }

        public string? Description { get => _description; set => _description = Guard.Against.NullOrEmpty(value); }

        public string? ICal { get => _iCal; set => _iCal = Guard.Against.Null(value); }

        public Image? Banner { get => _banner; set => _banner = Guard.Against.Null(value); }

        public ICollection<Sponsor> Sponsors { get => _sponsors; set => _sponsors = Guard.Against.Null(value); }

        public string? EntryFee { get => _entryFee; set => _entryFee = Guard.Against.Null(value); }
        
        public bool Published { get => _published; set => _published = value && CheckValues() ; }

        #endregion

        #region Constructors
        public Event(Category category, Accessibility accessibility, string name, bool published = true)
        {
            Category = category;
            Accessibility = accessibility;
            Name = name;
            Published = published;
        }
        #endregion

        #region Methods
        public void AddSponsor(Sponsor sponsor)
        {
            if(!_sponsors.Contains(sponsor))
                _sponsors.Add(sponsor);
        }

        public void RemoveSponsor(Sponsor sponsor)
        {
            _sponsors.Remove(sponsor);
        }
        
        public void AddSponsors(List<Sponsor> sponsors)
        {
            sponsors.ForEach(AddSponsor);
        }
        
        public void RemoveSponsors(List<Sponsor> sponsors)
        {
            sponsors.ForEach(RemoveSponsor);
        }
        
        private bool CheckValues()
        {
            return Location is not null && Start.HasValue && End.HasValue && Description is  not null && Banner is not null;
        }
        #endregion

    }
}
