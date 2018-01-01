using System.Drawing;
using System.Windows.Media.Imaging;
using VersionBase.Libraries.Drawing;

namespace VersionBase.Libraries.Tiles
{
    public class TileImage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameLower { get; set; }
        public Bitmap Bitmap { get; set; }
        public BitmapImage BitmapImage { get; set; }
        public TileImageType TileImageType { get; set; }

        public TileImage()
        {
            TileImageType = TileImageType.empty;
        }

        public TileImage(TileImageType tileImageType)
        {
            Id = tileImageType.ToString();
            NameLower = tileImageType.ToString();
            Name = tileImageType.ToString().ToUpper();
            Bitmap = TileImageTypes.GetBitmapTile(tileImageType);
            BitmapImage = HexMapDrawing.Convert(TileImageTypes.GetBitmapTile(tileImageType));
            TileImageType = tileImageType;
        }
    }
}
