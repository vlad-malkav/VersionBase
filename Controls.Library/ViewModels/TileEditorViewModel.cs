using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.Library.Models;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.ViewModels
{
    public class TileEditorViewModel
    {
        public List<TileImageTypeModel> ListTileImageTypeModel { get; set; }
        private TileImageTypeModel _selectedTileImageTypeModel;
        public TileImageTypeModel SelectedTileImageTypeModel
        {
            get => _selectedTileImageTypeModel;
            set => _selectedTileImageTypeModel = value;
        }

        public List<TileColorModel> ListTileColorModel { get; set; }
        private TileColorModel _selectedTileColor;
        public TileColorModel SelectedTileColor
        {
            get => _selectedTileColor;
            set => _selectedTileColor = value;
        }

        public TileEditorViewModel(TileEditorModel tileEditorModel)
        {
            ListTileColorModel = tileEditorModel.ListTileColor.Select(x => new TileColorModel(x)).ToList();
            SelectedTileColor = ListTileColorModel.First();
            ListTileImageTypeModel = tileEditorModel.ListTileImageType.Select(x => new TileImageTypeModel(x)).ToList();
            SelectedTileImageTypeModel = ListTileImageTypeModel.First();
        }
    }
}
