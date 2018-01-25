using System.Windows.Media;
using DataLibrary.Tiles;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Models
{
    public class TileColorModel : Model<TileColorData>
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

        public override void ImportData(TileColorData data)
        {
            _id = data.Id;
            _name = data.Name;
            _alpha = data.Alpha;
            _red = data.Red;
            _green = data.Green;
            _blue = data.Blue;
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
