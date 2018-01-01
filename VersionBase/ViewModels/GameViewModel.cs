using Controls.Library.ViewModels;
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
            TopMenuViewModel.ApplyModel();
        }

        public void ApplyModel(GameModel gameModel)
        {
            LeftPanelViewModel.ApplyModel(gameModel.LeftPanelModel);
            RightPanelViewModel.ApplyModel(gameModel.RightPanelModel);
            TopPanelViewModel.ApplyModel(gameModel.TopPanelModel);
            BottomPanelViewModel.ApplyModel(gameModel.BottomPanelModel);
            HexMapViewModel.ApplyModel(gameModel.HexMapModel);
        }
    }
}
