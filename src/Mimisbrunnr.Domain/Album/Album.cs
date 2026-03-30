using Mimisbrunnr.Domain.Common;

namespace Mimisbrunnr.Domain.Album;

public class Album : Entity
{
    #region Fields
    private string _name;
    private int _year;
    private Image? _coverImage;
    private ICollection<Image> _images;
    private string _description;
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
        get { return _description; }
        set { _description = Guard.Against.Null(value); }
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
    public Album(string name, int year, string description)
    {
        Name = name;
        Year =  year;
        Description = description;
        Images = new List<Image>();
    }
    public Album(string name, int year, string description, Image coverImage) : this(name, year, description)
    {
        CoverImage = coverImage;
    }
    #endregion
}