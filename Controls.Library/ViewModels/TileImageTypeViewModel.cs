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

        public TileImageTypeViewModel(List<TileImageType> listTileImageTypes)
        {
            FillListTileImageTypeModel(listTileImageTypes);
        }

        public void LoadTileTypes()
        {
            List<TileImageType> listTileImageType = TileImageTypes.GetAllTileImageTypes();
            FillListTileImageTypeModel(listTileImageType);
        }

        private void FillListTileImageTypeModel(List<TileImageType> listTileImageType)
        {
            ListTileImageTypeModel = listTileImageType.Select(x => new TileImageTypeModel(x)).ToList();
            SelectedTileType = ListTileImageTypeModel.First();
        }
    }
}
