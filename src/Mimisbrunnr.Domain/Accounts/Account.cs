using System.Net.Mail;

namespace Mimisbrunnr.Domain.Accounts;

public class Account : Entity
{
    #region Fields
    
    private string _name;
    private MailAddress _email;
    private string _userId;
    #endregion

    #region Properties
    public string Name
    {
        get { return _name; }
        set { _name = Guard.Against.NullOrEmpty(value); }
    }

    public MailAddress Email
    {
        get { return _email; }
        set { _email = Guard.Against.Null(value); }
    }
    
    public string UserId
    {
        get { return _userId; }
        private set { _userId = Guard.Against.NullOrEmpty(value); }
    }
    #endregion
    
    #region Constructors
    public Account(string name, MailAddress email, string userId)
    {
        Name = name;
        Email = email;
        UserId = userId;
    }

    public Account(string name, string email, string userId) : this(name, new MailAddress(email), userId)
    {
        
    }
    #endregion
}