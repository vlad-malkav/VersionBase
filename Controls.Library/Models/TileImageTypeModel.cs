using System.Drawing;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileImageTypeModel
    {
        private string _id;
        private string _name;
        private string _nameLower;

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

        public TileImageTypeModel() { }

        public TileImageTypeModel(TileImageType tileImageType)
        {
            _id = tileImageType.ToString();
            _nameLower = tileImageType.ToString();
            _name = tileImageType.ToString().ToUpper();
        }

        public Bitmap GetBitmap()
        {
            return TileImageTypes.GetBitmapTile(NameLower);
        }
    }
}
