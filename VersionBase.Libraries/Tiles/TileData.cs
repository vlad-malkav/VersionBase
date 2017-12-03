using System.Drawing;
using System.Windows.Media.Imaging;

namespace VersionBase.Libraries.Tiles
{
    public class TileData
    {
        public TileColor TileColor { get; set; }
        public TileImageType TileImageType { get; set; }

        public TileData(TileColor tileColor, TileImageType? tileImageType)
        {
            TileColor = tileColor;
            TileImageType = tileImageType ?? TileImageType.empty;
        }
    }
}
