using System.Drawing;
using System.Windows.Media.Imaging;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileImageModel : Model<TileImage>
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

        public override void ImportData(TileImage data)
        {
            _id = data.Id;
            _nameLower = data.NameLower;
            _name = data.Name;
            _bitmap = data.GetBitmap();
            _bitmapImage = data.GetBitmapImage();
        }
    }
}
