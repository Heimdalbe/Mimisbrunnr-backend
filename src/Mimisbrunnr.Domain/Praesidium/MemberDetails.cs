using System.Globalization;

namespace Mimisbrunnr.Domain.Praesidium
{
    public class MemberDetails : Entity
    {
        #region Fields
        private string _firstName;

        private string _lastName;

        private string _quote;

        private string _trivia;
        
        private DateOnly? _birthDate;
        
        private string _studieRichting;

        private string _favoriteGame;
        
        private string _favoriteHeimdal;

        private ICollection<Social> _socials;
        #endregion

        #region Properties
        public string FirstName { get => _firstName; set => _firstName = Guard.Against.NullOrEmpty(value); }

        public string LastName { get => _lastName; set => _lastName = Guard.Against.NullOrEmpty(value); }

        public string Quote { get => _quote; set => _quote = Guard.Against.Null(value); }

        public string Trivia { get => _trivia; set => _trivia = Guard.Against.Null(value); }
        
        public DateOnly? BirthDate { get => _birthDate; set => _birthDate = value; }

        public string StudieRichting { get => _studieRichting; set => _studieRichting = Guard.Against.Null(value); }

        public string FavoriteGame { get => _favoriteGame; set => _favoriteGame = Guard.Against.Null(value); }

        public string FavoriteHeimdal { get => _favoriteHeimdal; set => _favoriteHeimdal = Guard.Against.Null(value); }

        public ICollection<Social> Socials { get => _socials; private set => _socials = Guard.Against.Null(value); }
        #endregion

        #region Constructors
        public MemberDetails(string firstName, string lastName, string quote, string trivia, DateOnly? birthDate, string studieRichting, string favoriteGame, string favoriteHeimdal)
        {
            FirstName = firstName;
            LastName = lastName;
            Quote = quote;
            Trivia = trivia;
            BirthDate = birthDate;
            StudieRichting = studieRichting;
            FavoriteGame = favoriteGame;
            FavoriteHeimdal = favoriteHeimdal;
            Socials = new List<Social>();
        }
        #endregion
        
        #region Methods

        public void AddSocial(Social social)
        {
            Socials.Add(social);
        }

        public void RemoveSocial(Social social)
        {
            Socials.Remove(social);
        }
        #endregion
    }
}