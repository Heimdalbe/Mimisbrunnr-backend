using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mimisbrunnr.Domain.Common;

namespace Mimisbrunnr.Domain.Praesidium
{
    public class PraesidiumTerm : Entity
    {
        #region Fields
            private MemberDetails _memberDetails;
            
            private Image _image;

            private PraesidiumRole _role;

            private int _year;
            //private PraesidiumYear _year;
        #endregion

        #region Properties
        public MemberDetails MemberDetails { get => _memberDetails; set => _memberDetails = Guard.Against.Null(value); }
        
        public Image Image { get => _image; set => _image = Guard.Against.Null(value); }

        public PraesidiumRole Role { get => _role; set => _role = Guard.Against.Null(value); }

        public int Year { get => _year; set => _year = Guard.Against.InvalidInput(value, "startYear", (year) => year >= 2018); }
        //public PraesidiumYear Year { get => _year; set => _year = Guard.Against.Null(value); }
        #endregion

        #region Constructors
        public PraesidiumTerm(MemberDetails memberDetails, Image image, PraesidiumRole role,int year/*, PraesidiumYear year*/)
        {
            MemberDetails = memberDetails;
            Image = image;
            Role = role;
            Year = year;
        }
        #endregion
    }
}
