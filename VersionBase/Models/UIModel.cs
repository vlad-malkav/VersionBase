using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.General;
using VersionBase.Libraries.Enums;

namespace VersionBase.Models
{
    public class UIModel : AbstractModel<UIData>
    {
        private UILeftPanelModel _uiLeftPanelModel;
        private UIRightPanelModel _uiRightPanelModel;
        private UITopPanelModel _uiTopPanelModel;
        private UIBottomPanelModel _uiBottomPanelModel;

        public UILeftPanelModel UILeftPanelModel
        {
            get { return _uiLeftPanelModel; }
        }

        public UIRightPanelModel UIRightPanelModel
        {
            get { return _uiRightPanelModel; }
        }

        public UITopPanelModel UITopPanelModel
        {
            get { return _uiTopPanelModel; }
        }

        public UIBottomPanelModel UIBottomPanelModel
        {
            get { return _uiBottomPanelModel; }
        }

        public UIModel()
        {
            _uiLeftPanelModel = new UILeftPanelModel();
            _uiRightPanelModel = new UIRightPanelModel();
            _uiTopPanelModel = new UITopPanelModel();
            _uiBottomPanelModel = new UIBottomPanelModel();
        }

        public override void ImportData(UIData data)
        {
            _uiLeftPanelModel.ImportUITileEditorData(data.ListTileColor, data.ListTileImage);

            List<GameMode> listGameMode = new List<GameMode>();
            foreach (GameMode gameMode in Enum.GetValues(typeof(GameMode)))
            {
                listGameMode.Add(gameMode);
            }
            _uiLeftPanelModel.ImportGameModeData(listGameMode);
        }
    }
}
