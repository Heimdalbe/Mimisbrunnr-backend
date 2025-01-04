using Mimmisbrunnr.Domain.Common;

namespace Mimmisbrunnr.Domain.Event
{
    public class Event
    {
        #region Fields
        private Category _category;

        private Accessibility _accessibility;
        #endregion

        #region Properties
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private string _description;
        public string Description { get => _description; set => _description = value; }

        private DateTime _start;
        public DateTime Start { get => _start; set => _start = value; }

        private DateTime _end;
        public DateTime End { get => _end; set => _end = value; }

        private Image _banner;
        public Image Banner { get => _banner; set => _banner = value; }
        #endregion

    }
}
