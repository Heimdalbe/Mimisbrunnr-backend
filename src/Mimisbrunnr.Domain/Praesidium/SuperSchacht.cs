using Mimisbrunnr.Domain.Common;

namespace Mimisbrunnr.Domain.Praesidium;

public class SuperSchacht : Entity
{
    #region Fields
    private MemberDetails _memberDetails;
    private Image _image;
    private int _year;
    #endregion

    #region Properties

    public MemberDetails MemberDetails
    {
        get { return _memberDetails; }
        set { _memberDetails = Guard.Against.Null(value); }
    }
    public Image Image { get => _image; set => _image = Guard.Against.Null(value); }
    
    public int Year { get => _year; set => _year = Guard.Against.InvalidInput(value, "startYear", (year) => year >= 2018); } // Ik weet niet uit mijn hoofd wanneer de eerste superschacht er was
    #endregion
    
    #region Constructors
    public SuperSchacht(MemberDetails memberDetails, int year, Image image)
    {
        MemberDetails = memberDetails;
        Image = image;
        Year = year;
    }
    #endregion
}