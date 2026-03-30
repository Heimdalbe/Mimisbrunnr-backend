using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mimisbrunnr.Domain.Common;

namespace Mimisbrunnr.Domain.Praesidium
{
    public class PraesidiumYear : Entity
    {
        #region Fields
        private int _startYear;
        private int _endYear;
        #endregion

        #region Properties
        public int StartYear { get => _startYear; set => _startYear = Guard.Against.InvalidInput(value, "startYear", (year) => year >= 2018); }
        public int EndYear { get => _endYear; set => _endYear = Guard.Against.InvalidInput(value, "endYear", (year) => year >= StartYear); }
        #endregion

        #region Constructors
        public PraesidiumYear(int startYear, int endYear)
        {
            StartYear = startYear;
            EndYear = endYear;
        }
        
        public PraesidiumYear() : this(DateTime.Now.Year, DateTime.Now.Year + 1)
        {
        }
        #endregion
    }
}
