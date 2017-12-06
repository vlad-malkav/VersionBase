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
            get { return _selectedTileImageTypeModel; }
            set { _selectedTileImageTypeModel = value; }
        }

        public List<TileColorModel> ListTileColorModel { get; set; }
        private TileColorModel _selectedTileColorModel;
        public TileColorModel SelectedTileColorModel
        {
            get { return _selectedTileColorModel; }
            set { _selectedTileColorModel = value; }
        }

        public TileEditorViewModel(TileEditorModel tileEditorModel)
        {
            ListTileColorModel = tileEditorModel.ListTileColor.Select(x => new TileColorModel(x)).ToList();
            SelectedTileColorModel = ListTileColorModel.First();
            ListTileImageTypeModel = tileEditorModel.ListTileImageType.Select(x => new TileImageTypeModel(x)).ToList();
            SelectedTileImageTypeModel = ListTileImageTypeModel.First();
        }
    }
}
