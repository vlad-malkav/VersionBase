using System.Windows.Media;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileColorModel
    {
        private string _id { get; set; }
        private string _name;
        private byte _alpha;
        private byte _blue;
        private byte _green;
        private byte _red;

        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public byte Alpha
        {
            get { return _alpha; }
        }

        public byte Red
        {
            get { return _red; }
        }

        public byte Green
        {
            get { return _green; }
        }

        public byte Blue
        {
            get { return _blue; }
        }

        public TileColorModel() { }

        public TileColorModel(TileColor tileColor)
        {
            _id = tileColor.Id;
            _name = tileColor.Name;
            _alpha = tileColor.Alpha;
            _red = tileColor.Red;
            _green = tileColor.Green;
            _blue = tileColor.Blue;
            //ColorBrush = new SolidColorBrush(tileColor.GetWindowsMediaColor());
        }

        public Color GetMediaColor()
        {
            return Color.FromArgb(Alpha, Red, Green, Blue);
        }

        public System.Drawing.Color GetDrawingColor()
        {
            return System.Drawing.Color.FromArgb(Alpha, Red, Green, Blue);
        }
    }
}
