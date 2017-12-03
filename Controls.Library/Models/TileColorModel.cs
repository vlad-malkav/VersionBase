using System.Windows.Media;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileColorModel
    {
        public string Name { get; set; }
        public TileColor TileColor { get; set; }
        public Brush ColorBrush { get; set; }

        public TileColorModel() { }

        public TileColorModel(TileColor tileColor)
        {
            TileColor = tileColor;
            Name = tileColor.Name;
            ColorBrush = new SolidColorBrush(tileColor.GetWindowsMediaColor());
        }
    }
}
