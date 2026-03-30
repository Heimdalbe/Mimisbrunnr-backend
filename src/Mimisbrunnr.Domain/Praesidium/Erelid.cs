using Mimisbrunnr.Domain.Common;

namespace Mimisbrunnr.Domain.Praesidium;

public class Erelid : Entity
{
    #region Fields
    private MemberDetails _memberDetails;
    private Image _image;
    #endregion

    #region Properties

    public MemberDetails MemberDetails
    {
        get { return _memberDetails; }
        set { _memberDetails = Guard.Against.Null(value); }
    }

    public Image Image
    {
        get => _image;
        set => _image = Guard.Against.Null(value);
    }
    #endregion
    
    #region Constructors
    
    private Erelid() { }
    public Erelid(MemberDetails memberDetails, Image image)
    {
        MemberDetails = Guard.Against.Null(memberDetails);
        Image = image;
    }
    #endregion
}