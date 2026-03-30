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
        
        private LanSponsorRank _lanSponsorRank = LanSponsorRank.KiloByte; //overwritten in constructor, prevents guard from triggering on construction if SR is NONE
        
        private int _order;
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = Guard.Against.NullOrEmpty(value); }
        
        public Image Logo { get => _logo; set => _logo = Guard.Against.Null(value); }

        public string Website { get => _website; set => _website = Guard.Against.Url(value); }

        public string Benefits { get => _benefits; set => _benefits = Guard.Against.Null(value); }

        public SponsorRank SponsorRank { get => _sponsorRank; set => _sponsorRank = Guard.Against.NullOrInvalidInput(value, nameof(SponsorRank), sr => sr != SponsorRank.None || LanSponsorRank != LanSponsorRank.None); }

        public LanSponsorRank LanSponsorRank { get => _lanSponsorRank; set => _lanSponsorRank = Guard.Against.NullOrInvalidInput(value, nameof(SponsorRank), lsr => lsr != LanSponsorRank.None || SponsorRank != SponsorRank.None); }
        
        public int Order { get => _order; set => _order = Guard.Against.NegativeOrZero(value); }
        #endregion

        #region Constructors

        private Sponsor () { }
        public Sponsor(string name, Image logo, string website, string benefits, SponsorRank sponsorRank, LanSponsorRank lanSponsorRank, int order)
        {
            Name = name;
            Logo = logo;
            Website = website;
            Benefits = benefits;
            SponsorRank = sponsorRank;
            LanSponsorRank = lanSponsorRank;
            Order = order;
        }
        #endregion
    }
}
