using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mimisbrunnr.Domain.Common;

namespace Mimisbrunnr.Domain.Sponsors
{
    public class Sponsor : Entity
    {
        #region Fields
        private string _name;

        private Image _logo;

        private string _website;

        private string _benefits;

        private SponsorRank _sponsorRank;
        
        private LanSponsorRank _lanSponsorRank;
        
        private int _order;

        private bool _onHomePage;
        
        private bool _onSponsorPage;
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = Guard.Against.NullOrEmpty(value); }
        
        public Image Logo { get => _logo; set => _logo = Guard.Against.Null(value); }

        public string Website { get => _website; set => _website = Guard.Against.Url(value); }

        public string Benefits { get => _benefits; set => _benefits = Guard.Against.Null(value); }

        public SponsorRank SponsorRank { get => _sponsorRank; set => _sponsorRank = Guard.Against.Null(value); }

        public LanSponsorRank LanSponsorRank { get => _lanSponsorRank; set => _lanSponsorRank = Guard.Against.Null(value); }
        
        public int Order { get => _order; set => _order = Guard.Against.NegativeOrZero(value); }
        
        public bool OnHomePage { get => _onHomePage; set => _onHomePage = value; }
        
        public bool OnSponsorPage { get => _onSponsorPage; set => _onSponsorPage = value; }
        #endregion

        #region Constructors

        private Sponsor () { }
        public Sponsor(string name, Image logo, string website, string benefits, SponsorRank sponsorRank, LanSponsorRank lanSponsorRank, int order, bool onHomePage, bool onSponsorPage)
        {
            Name = name;
            Logo = logo;
            Website = website;
            Benefits = benefits;
            SponsorRank = sponsorRank;
            LanSponsorRank = lanSponsorRank;
            Order = order;
            OnHomePage = onHomePage;
            OnSponsorPage = onSponsorPage;
        }
        #endregion
    }
}
