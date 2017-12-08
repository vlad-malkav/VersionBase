using System.Drawing;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileImageTypeModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameLower { get; set; }

        public TileImageTypeModel() { }

        public TileImageTypeModel(TileImageType tileImageType)
        {
            Id = tileImageType.ToString();
            NameLower = tileImageType.ToString();
            Name = tileImageType.ToString().ToUpper();
        }

        public Bitmap GetBitmap()
        {
            return TileImageTypes.GetBitmapTile(NameLower);
        }
    }
}
