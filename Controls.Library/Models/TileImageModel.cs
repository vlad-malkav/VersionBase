using System.Drawing;
using System.Windows.Media.Imaging;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileImageModel
    {
        private string _id;
        private string _name;
        private string _nameLower;
        private Bitmap _bitmap;
        private BitmapImage _bitmapImage;

        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string NameLower
        {
            get { return _nameLower; }
        }

        public Bitmap Bitmap
        {
            get { return _bitmap; }
        }

        public BitmapImage BitmapImage
        {
            get { return _bitmapImage; }
        }

        public TileImageModel() { }

        public TileImageModel(TileImage tileImage)
        {
            _id = tileImage.Id;
            _nameLower = tileImage.NameLower;
            _name = tileImage.Name;
            _bitmap = tileImage.GetBitmap();
            _bitmapImage = tileImage.GetBitmapImage();
        }
    }
}
