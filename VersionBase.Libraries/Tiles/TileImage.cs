using System.Drawing;
using System.Windows.Media.Imaging;
using VersionBase.Libraries.Drawing;
using VersionBase.Libraries.Enums;

namespace VersionBase.Libraries.Tiles
{
    public class TileImage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameLower { get; set; }
        public TileImageType TileImageType { get; set; }
        public Bitmap Bitmap { get; set; }
        public BitmapImage BitmapImage { get; set; }

        public TileImage()
            :this(TileImageType.empty)
        {

        }

        public TileImage(TileImageType tileImageType)
        {
            Id = tileImageType.ToString();
            NameLower = tileImageType.ToString();
            Name = tileImageType.ToString().ToUpper();
            TileImageType = tileImageType;
            Bitmap = TileImageTypes.GetBitmapTile(TileImageType);
            BitmapImage= HexMapDrawing.Convert(TileImageTypes.GetBitmapTile(TileImageType));
        }

        /*public Bitmap GetBitmap()
        {
            return TileImageTypes.GetBitmapTile(TileImageType);
        }*/

        public BitmapImage GetBitmapImage()
        {
            return BitmapImage;//HexMapDrawing.Convert(TileImageTypes.GetBitmapTile(TileImageType));
        }
    }
}
