using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Mimmisbrunnr.Domain.Common;

namespace Mimmisbrunnr.Domain.Praesidium
{
    public class PraesidiumRole : Entity

    {

    #region Fields

    private string _name;

    private MailAddress _email;

    private int _order;

    #endregion

    #region Properties

    public string Name
    {
        get => _name;
        set => _name = Guard.Against.NullOrEmpty(value);
    }

    public MailAddress Email
    {
        get => _email;
        set => _email = Guard.Against.Null(value);
    }

    public int Order
    {
        get => _order;
        set => _order = Guard.Against.NegativeOrZero(value);
    }

    #endregion

    #region Constructors

    public PraesidiumRole(string name, MailAddress email, int order)
    {
        Name = name;
        Email = email;
        Order = order;
    }

    public PraesidiumRole(string name, string email, int order) : this(name, new MailAddress(email), order)
    {
    }
    
    #endregion

    }
}
