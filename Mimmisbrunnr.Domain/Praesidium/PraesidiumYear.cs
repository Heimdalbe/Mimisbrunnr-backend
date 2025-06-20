using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.Praesidium
{
    internal class PraesidiumYear
    {
        #region Fields
        private int _year;
        #endregion

        #region Properties
        public int Year { get => _year; set => _year = Guard.Against.InvalidInput(value, "praesidiumYear", (year) => year >= 2018 && year < 9999); } //Needs code change when the year 9999 is reached
        #endregion

        #region Constructors
        public PraesidiumYear(int year)
        {
            Year = year;
        }
        public PraesidiumYear() : this(DateTime.Now.Year)
        {
        }
        #endregion
    }
}
