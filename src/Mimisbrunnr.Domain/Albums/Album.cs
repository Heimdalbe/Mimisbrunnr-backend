namespace Mimisbrunnr.Domain.Albums;

public class Album : Entity
{
    #region Fields
    private string _name;
    private DateOnly _date;
    private Image? _coverImage;
    private ICollection<Image> _images;
    private string _description;
    private bool _published;
    #endregion
    
    #region Properties
    public string Name
    {
        get { return _name; }
        set { _name = Guard.Against.NullOrEmpty(value); }
    }
    
    public DateOnly Date
    {
        get { return _date; }
        set { _date = Guard.Against.NullOrInvalidInput(value, nameof(Date), date => date.Year >= 2018); }
    }

    public string Description
    {
        get { return _description; }
        set { _description = Guard.Against.Null(value); }
    }

    public Image? CoverImage
    {
        get { return _coverImage ?? _images.FirstOrDefault(); }
        set { _coverImage = value; }
    }

    public ICollection<Image> Images
    {
        get { return _images; }
        set { _images = Guard.Against.Null(value); }
    }

    public bool Published
    {
        get { return _published; }
        set { _published = value && _images.Count > 0; }
    }
    #endregion
    
    #region Methods
    public void AddImage(Image image)
    {
        if(!Images.Contains(image))
            _images.Add(image);
    }
    
    public void AddImages(List<Image> images)
    {
        images.ForEach(AddImage);
    }

    public void RemoveImage(Image image)
    {
        _images.Remove(image);
    }

    public void RemoveImages(List<Image> images)
    {
        images.ForEach(RemoveImage);
    }
    #endregion
    
    #region Constructors
    public Album(string name, DateOnly date, string description, bool published)
    {
        Name = name;
        Date =  date;
        Description = description;
        Images = new List<Image>();
        Published = published;
    }
    public Album(string name, DateOnly date, string description, bool published, Image coverImage) : this(name, date, description, published)
    {
        CoverImage = coverImage;
    }
    #endregion
}