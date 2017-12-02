using System;
using System.Drawing;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;

namespace VersionBase.Libraries.Tiles
{
    public class Tile
    {
        public TileImageType TileImageType { get; set; }
        public TileColor TileColor { get; set; }

        public Tile(TileColor tileColor, TileImageType tileImageType)
        {
            TileColor = tileColor;
            TileImageType = tileImageType;
        }

        public Bitmap GetBitmapTile()
        {
            return TileImageTypes.GetBitmapTile(TileImageType);
        }

        public BitmapImage GetBitmapImageTile()
        {
            return TileImageTypes.GetBitmapImageTile(TileImageType);
        }
    }
}
