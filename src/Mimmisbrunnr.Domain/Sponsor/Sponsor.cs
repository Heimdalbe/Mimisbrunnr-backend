using Ardalis.GuardClauses;
using Mimmisbrunnr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.Sponsor
{
    public class Sponsor : Entity
    {
        #region Fields
        private string _name;

        private Image _logo;

        private string _website;

        private string _benefits;

        private int _order;

        private SponsorRank _rank;
        #endregion

        #region Properties
        public string Name { get => _name; set => _name = Guard.Against.NullOrEmpty(value); }
        
        public Image Logo { get => _logo; set => _logo = Guard.Against.Null(value); }

        public string Website { get => _website; set => _website = Guard.Against.Url(value); }

        public string Benefits { get => _benefits; set => _benefits = Guard.Against.Null(value); }

        public SponsorRank Rank { get => _rank; set => _rank = Guard.Against.Null(value); }

        public int Order { get => _order; set => _order = Guard.Against.NegativeOrZero(value); }
        #endregion

        #region Constructors
        public Sponsor(string name, Image logo, string website, string benefits, SponsorRank rank, int order)
        {
            Name = name;
            Logo = logo;
            Website = website;
            Benefits = benefits;
            Rank = rank;
            Order = order;
        }
        #endregion
    }
}
