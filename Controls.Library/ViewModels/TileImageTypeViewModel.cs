using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Controls.Library.Models;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.ViewModels
{
    public class TileImageTypeViewModel
    {
        public string Name { get; set; }
        public string NameLower { get; set; }
        public BitmapImage Bitmap { get; set; }

        public TileImageTypeViewModel() { }

        public TileImageTypeViewModel(TileImageTypeModel tileImageTypeModel)
        {
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
