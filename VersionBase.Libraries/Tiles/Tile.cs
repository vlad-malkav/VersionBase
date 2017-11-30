using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace VersionBase.Libraries.Tiles
{
    public class Tile
    {
        public Color BaseColor { get; set; }
        public string BitmapUri { get; set; }

        public Tile(Color baseColor, string bitmapUri)
        {
            BaseColor = baseColor;
            BitmapUri = bitmapUri;
        }

        public Bitmap GetBitmapTile()
        {
            return new Bitmap(BitmapUri);
        }
    }
}
