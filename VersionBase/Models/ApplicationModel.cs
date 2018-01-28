using System;
using System.Collections.Generic;
using VersionBase.Data;
using VersionBase.Libraries.Enums;

namespace VersionBase.Models
{
    public class ApplicationModel : AbstractModel<ApplicationData>
    {
        private GameModel _gameModel;
        private UIModel _uiModel;

        public GameModel GameModel
        {
            get { return _gameModel; }
        }

        public UIModel UIModel
        {
            get { return _uiModel; }
        }

        public ApplicationModel()
        {
            _gameModel = new GameModel();
            _uiModel = new UIModel();
        }

        public override void ImportData(ApplicationData data)
        {
            _gameModel.ImportData(data.GameData);
            _uiModel.ImportData(data.UIData);
        }
    }
}
