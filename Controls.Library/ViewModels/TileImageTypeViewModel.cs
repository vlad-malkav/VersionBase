using System.Drawing;
using System.Windows.Media.Imaging;
using Controls.Library.Models;
using MyToolkit.Mvvm;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.ViewModels
{
    public class TileImageTypeViewModel : ViewModelBase // from MyToolkit
    {
        private string _id;

        public string Id
        {
            get { return _id; }
        }

        public string Name { get; set; }
        public string NameLower { get; set; }
        public BitmapImage Bitmap { get; set; }

        public TileImageTypeViewModel() { }

        public TileImageTypeViewModel(TileImageTypeModel tileImageTypeModel)
        {
            _id = tileImageTypeModel.Id;
            Name = tileImageTypeModel.Name;
            NameLower = tileImageTypeModel.NameLower;
            Bitmap = GetBitmapImage();
        }

        public BitmapImage GetBitmapImage()
        {
            return HexMapDrawing.GenerateTileBitmapImage(Color.LightGreen,GetBitmap());
        }

        public Bitmap GetBitmap()
        {
            return TileImageTypes.GetBitmapTile(NameLower);
        }
    }
}
