using Mimmisbrunnr.Domain.Common;

namespace Mimmisbrunnr.Domain.Album;

public class Album : Entity
{
    #region Fields
    private string _name;
    private int _year;
    private Image? _coverImage;
    private ICollection<Image> _images;
    private string _desciption;
    #endregion
    
    #region Properties
    public string Name
    {
        get { return _name; }
        set { _name = Guard.Against.NullOrEmpty(value); }
    }
    
    public int Year
    {
        get { return _year; }
        set { _year = Guard.Against.NegativeOrZero(value); }
    }

    public string Description
    {
        get { return _desciption; }
        set { _desciption = Guard.Against.Null(value); }
    }

    public Image? CoverImage
    {
        get { return _coverImage ?? _images.FirstOrDefault(); }
        set { _coverImage = Guard.Against.Null(value); }
    }

    public ICollection<Image> Images
    {
        get { return _images; }
        private set { _images = Guard.Against.Null(value); }
    }
    #endregion
    
    #region Methods
    public void AddImage(Image image)
    {
        _images.Add(image);
    }

    public void RemoveImage(Image image)
    {
        _images.Remove(image);
    }
    #endregion
    
    #region Constructors
    public Album(string name, int year, string desciption)
    {
        Name = name;
        Year =  year;
        Description = desciption;
        Images = new List<Image>();
    }
    public Album(string name, int year, string desciption, Image coverImage) : this(name, year, desciption)
    {
        CoverImage = coverImage;
    }
    #endregion
}