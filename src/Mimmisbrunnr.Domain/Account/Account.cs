using System.Net.Mail;
using Mimmisbrunnr.Domain.Common;

namespace Mimmisbrunnr.Domain.Account;

public class Account : Entity
{
    #region Fields
    private string _name;
    private MailAddress _email;
    private int _accountId;
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
    
    public int AccountId
    {
        get { return _accountId; }
        private set { _accountId = Guard.Against.NegativeOrZero(value); }
    }
    #endregion
    
    #region Constructors
    public Account(string name, MailAddress email, int accountId)
    {
        Name = name;
        Email = email;
        AccountId = accountId;
    }

    public Account(string name, string email, int accountId) : this(name, new MailAddress(email), accountId)
    {
        
    }
    #endregion
}