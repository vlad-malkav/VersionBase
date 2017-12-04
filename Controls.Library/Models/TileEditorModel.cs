using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileEditorModel
    {
        public List<TileColor> ListTileColor { get; set; }
        public List<TileImageType> ListTileImageType { get; set; }

        public TileEditorModel(List<TileColor> listTileColor, List<TileImageType> listTileImageType)
        {
            ListTileColor = listTileColor;
            ListTileImageType = listTileImageType;
        }
    }
}
