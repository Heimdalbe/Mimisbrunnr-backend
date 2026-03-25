using Ardalis.GuardClauses;
using Mimmisbrunnr.Domain.Common;
using Mimmisbrunnr.Domain.Event;
using Mimmisbrunnr.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.Praesidium
{
    public class PraesidiumMember : Entity
    {
        #region Fields
        private string _firstName;

        private string _lastName;

        private string _guote;

        private string trivia;

        private ICollection<Social> _socials;

        private Image _image;
        #endregion

        #region Properties
        public string FirstName { get => _firstName; set => _firstName = Guard.Against.NullOrEmpty(value); }

        public string LastName { get => _lastName; set => _lastName = Guard.Against.NullOrEmpty(value); }

        public string Quote { get => _guote; set => _guote = Guard.Against.Null(value); }

        public string Trivia { get => trivia; set => trivia = Guard.Against.Null(value); }

        public ICollection<Social> Socials { get => _socials; set => _socials = Guard.Against.Null(value); }

        public Image Image { get => _image; set => _image = Guard.Against.Null(value); }
        #endregion

        #region Constructors
        private PraesidiumMember(PraesidiumMemberBuilder builder)
        {
            FirstName = builder._firstName;
            LastName = builder._lastName;
            Quote = builder._quote;
            Trivia = builder._trivia;
            Socials = builder._socials;
            Image = builder._image;
        }
        #endregion

        #region Methods
        public static PraesidiumMemberBuilder builder()
        {
            return new PraesidiumMemberBuilder();
        }
        #endregion

        #region Builder
        public class PraesidiumMemberBuilder()
        {
            #region Fields
            private const string DEFAULT_DESCRIPTION = "No description provided.";

            internal string _firstName;

            internal string _lastName;
            
            internal string _quote;
            
            internal string _trivia;
            
            internal ICollection<Social> _socials;
            
            internal Image _image;
            #endregion

            #region Methods   
            public PraesidiumMemberBuilder FirstName(string firstName)
            {
                _firstName = firstName;
                return this;
            }
            
            public PraesidiumMemberBuilder LastName(string lastName)
            {
                _lastName = lastName;
                return this;
            }
           
            public PraesidiumMemberBuilder Quote(string quote)
            {
                _quote = quote;
                return this;
            }
           
            public PraesidiumMemberBuilder Trivia(string trivia)
            {
                _trivia = trivia;
                return this;
            }
           
            public PraesidiumMemberBuilder Socials(ICollection<Social> socials)
            {
                _socials = socials;
                return this;
            }
           
            public PraesidiumMemberBuilder Image(Image image)
            {
                _image = image;
                return this;
            }

            public PraesidiumMember build()
            {
                HashSet<PraesidiumMemberRequiredElement> requiredElements = new HashSet<PraesidiumMemberRequiredElement>();

                if(String.IsNullOrEmpty(_firstName))
                    requiredElements.Add(PraesidiumMemberRequiredElement.FIRSTNAME);
                if (String.IsNullOrEmpty(_lastName))
                    requiredElements.Add(PraesidiumMemberRequiredElement.NAME);
                if(_quote is null)
                    _quote = string.Empty;
                if (_trivia is null)
                    _trivia = string.Empty;
                if (_socials is null)
                    _socials = new List<Social>();
                if (_image is null)
                    requiredElements.Add(PraesidiumMemberRequiredElement.IMAGE);

                if (requiredElements.Count > 0)
                    throw new InformationRequiredException<PraesidiumMemberRequiredElement>(requiredElements);

                return new PraesidiumMember(this);
            }
            #endregion
        }
        #endregion

    }
}