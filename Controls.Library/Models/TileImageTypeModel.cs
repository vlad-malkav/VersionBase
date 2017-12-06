using System.Drawing;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileImageTypeModel
    {
        public string Name { get; set; }
        public string NameLower { get; set; }

        public TileImageTypeModel() { }

        public TileImageTypeModel(TileImageType tileImageType)
        {
            NameLower = tileImageType.ToString();
            Name = tileImageType.ToString().ToUpper();
        }

        public Bitmap GetBitmap()
        {
            return TileImageTypes.GetBitmapTile(NameLower);
        }
    }
}
