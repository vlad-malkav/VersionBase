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
        public List<TileColorModel> ListTileColorModel { get; set; }
        public List<TileImageTypeModel> ListTileImageTypeModel { get; set; }

        public TileEditorModel(List<TileColor> listTileColor, List<TileImageType> listTileImageType)
        {
            ListTileColorModel = listTileColor.Select(x => new TileColorModel(x)).ToList();
            ListTileImageTypeModel = listTileImageType.Select(x => new TileImageTypeModel(x)).ToList();
        }

        public TileColorModel GetTileColorModel(string name)
        {
            return ListTileColorModel.FirstOrDefault(x => x.Name == name);
        }

        public TileImageTypeModel GetTileImageTypeModel(string name)
        {
            return ListTileImageTypeModel.FirstOrDefault(x => x.Name == name);
        }
    }
}
