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
        public LeftPanelViewModel LeftPanelViewModel { get; set; }
        public RightPanelViewModel RightPanelViewModel { get; set; }
        public TopPanelViewModel TopPanelViewModel { get; set; }
        public BottomPanelViewModel BottomPanelViewModel { get; set; }

        public GameViewModel()
        {
            TopMenuViewModel = new TopMenuViewModel();
            HexMapViewModel = new HexMapViewModel();
            LeftPanelViewModel = new LeftPanelViewModel();
            RightPanelViewModel = new RightPanelViewModel();
            TopPanelViewModel = new TopPanelViewModel();
            BottomPanelViewModel = new BottomPanelViewModel();
        }

        public void ApplyModel(GameModel gameModel, double actualHeight, double actualWidth)
        {
            // Get sizes that will fit within our window
            double hexMapWidth, hexMapHeight, width, height, cellSize;
            hexMapWidth = actualWidth;
            hexMapHeight = actualHeight;
            HexMapDrawing.GetCombSize(hexMapHeight, hexMapWidth, gameModel.HexMapModel.Columns, gameModel.HexMapModel.Rows, out cellSize, out width, out height);
            double xCenterOriginal = HexMapDrawing.GetTrueXCenter(cellSize, gameModel.HexMapModel.Columns);
            double yCenterrOriginal = HexMapDrawing.GetTrueYCenter(cellSize, gameModel.HexMapModel.Columns, gameModel.HexMapModel.Rows);
            double xCenterNew = (hexMapWidth / 2);
            double yCenterNew = (hexMapHeight / 2);
            double xCenterMod = xCenterNew - xCenterOriginal;
            double yCenterMod = yCenterNew - yCenterrOriginal;
            HexMapViewModel.ApplyModel(gameModel.HexMapModel, width, height, xCenterMod, yCenterMod, cellSize);
            TopMenuViewModel.ApplyModel();
            LeftPanelViewModel.ApplyModel(gameModel.LeftPanelModel);
            RightPanelViewModel.ApplyModel(gameModel.RightPanelModel);
            TopPanelViewModel.ApplyModel(gameModel.TopPanelModel);
            BottomPanelViewModel.ApplyModel(gameModel.BottomPanelModel);
        }
    }
}
