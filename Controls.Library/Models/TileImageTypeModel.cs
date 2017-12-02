using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileImageTypeModel
    {
        public TileImageType TileImageType { get; set; }
        public string Name { get; set; }
        public string BitmapUri { get; set; }

        public TileImageTypeModel() { }

        public TileImageTypeModel(TileImageType tileImageType)
        {
            TileImageType = tileImageType;
            BitmapUri = TileImageTypes.GetBitmapImagePath(TileImageType);
            Name = TileImageType.ToString().ToUpper();
        }
    }
}
