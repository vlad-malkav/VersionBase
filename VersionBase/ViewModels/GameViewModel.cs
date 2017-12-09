using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.Library.ViewModels;
using VersionBase.Libraries.Hexes;
using VersionBase.Model;

namespace VersionBase.ViewModels
{
    public class GameViewModel
    {
        public TopMenuViewModel TopMenuViewModel { get; set; }
        public HexMapViewModel HexMapViewModel { get; set; }
        public TileEditorViewModel TileEditorViewModel { get; set; }

        public GameViewModel()
        {
            TopMenuViewModel = new TopMenuViewModel();
            HexMapViewModel = new HexMapViewModel();
            TileEditorViewModel = new TileEditorViewModel();
        }

        public void ApplyModel(GameModel gameModel, double actualHeight, double actualWidth)
        {
            // Get sizes that will fit within our window
            double width, height, cellSize;
            HexMapDrawing.GetCombSize(actualHeight, actualWidth, gameModel.HexMapModel.Columns, gameModel.HexMapModel.Rows, out cellSize, out width, out height);
            HexMapViewModel.ApplyModel(gameModel.HexMapModel, width, height, cellSize);
            TileEditorViewModel.ApplyModel(gameModel.TileEditorModel);
            TopMenuViewModel.ApplyModel();
        }
    }
}
