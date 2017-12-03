using System.Collections.Generic;
using System.Linq;
using Controls.Library.Models;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.ViewModels
{
    public class TileImageTypeViewModel
    {
        public List<TileImageTypeModel> ListTileImageTypeModel { get; set; }

        private TileImageTypeModel _selectedTileType;

        public TileImageTypeModel SelectedTileType
        {
            get
            {
                return _selectedTileType;
            }

            set
            {
                _selectedTileType = value;
            }
        }

        public TileImageTypeViewModel()
        {
            LoadTileTypes();
        }

        public void LoadTileTypes()
        {
            List<TileImageType> listTile = TileImageTypes.GetAllTileImageTypes();
            ListTileImageTypeModel = listTile.Select(x => new TileImageTypeModel(x)).ToList();
            SelectedTileType = ListTileImageTypeModel.First();
        }
    }
}
