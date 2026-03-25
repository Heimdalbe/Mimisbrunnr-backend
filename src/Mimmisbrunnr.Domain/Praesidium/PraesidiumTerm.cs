using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mimmisbrunnr.Domain.Common;

namespace Mimmisbrunnr.Domain.Praesidium
{
    public class PraesidiumTerm : Entity
    {
        #region Fields
            private PraesidiumMember _member;

            private PraesidiumRole _role;

            private int _year;
            //private PraesidiumYear _year;
        #endregion

        #region Properties
        public PraesidiumMember Member { get => _member; set => _member = Guard.Against.Null(value); }

        public PraesidiumRole Role { get => _role; set => _role = Guard.Against.Null(value); }

        public int Year { get => _year; set => _year = Guard.Against.InvalidInput(value, "startYear", (year) => year >= 2018); }
        //public PraesidiumYear Year { get => _year; set => _year = Guard.Against.Null(value); }
        #endregion

        #region Constructors
        public PraesidiumTerm(PraesidiumMember member, PraesidiumRole role,int year/*, PraesidiumYear year*/)
        {
            Member = member;
            Role = role;
            Year = year;
        }
        #endregion
    }
}
