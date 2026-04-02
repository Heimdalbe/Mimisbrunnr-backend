namespace Mimisbrunnr.Domain.Praesidium
{
    public class MemberDetails : Entity
    {
        #region Fields
        private string _firstName;

        private string _lastName;

        private string _quote;

        private string _trivia;

        private ICollection<Social> _socials;
        #endregion

        #region Properties
        public string FirstName { get => _firstName; set => _firstName = Guard.Against.NullOrEmpty(value); }

        public string LastName { get => _lastName; set => _lastName = Guard.Against.NullOrEmpty(value); }

        public string Quote { get => _quote; set => _quote = Guard.Against.Null(value); }

        public string Trivia { get => _trivia; set => _trivia = Guard.Against.Null(value); }

        public ICollection<Social> Socials { get => _socials; private set => _socials = Guard.Against.Null(value); }
        #endregion

        #region Constructors
        public MemberDetails(string firstName, string lastName, string quote, string trivia)
        {
            FirstName = firstName;
            LastName = lastName;
            Quote = quote;
            Trivia = trivia;
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