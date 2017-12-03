using System.Collections.Generic;
using System.Linq;
using Controls.Library.Models;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.ViewModels
{
    public class TileColorViewModel
    {
        public List<TileColorModel> ListTileColorModel { get; set; }

        private TileColorModel _selectedTileColor;

        public TileColorModel SelectedTileColor
        {
            get
            {
                return _selectedTileColor;
            }

            set
            {
                _selectedTileColor = value;
            }
        }

        public TileColorViewModel()
        {
            LoadTileColors();
        }

        public void LoadTileColors()
        {
            List<TileColor> listTileColor = TileColors.GetAllWindowsMediaColors();
            ListTileColorModel = listTileColor.Select(x => new TileColorModel(x)).ToList();
            SelectedTileColor = ListTileColorModel.First();
        }
    }
}
