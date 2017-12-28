using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using VersionBase.Data;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Model
{
    public class GameModel
    {
        private HexMapModel _hexMapModel;
        private LeftPanelModel _leftPanelModel;
        private RightPanelModel _rightPanelModel;
        private TopPanelModel _topPanelModel;
        private BottomPanelModel _bottomPanelModel;

        public HexMapModel HexMapModel
        {
            get { return _hexMapModel; }
        }

        public LeftPanelModel LeftPanelModel
        {
            get { return _leftPanelModel; }
        }

        public RightPanelModel RightPanelModel
        {
            get { return _rightPanelModel; }
        }

        public TopPanelModel TopPanelModel
        {
            get { return _topPanelModel; }
        }

        public BottomPanelModel BottomPanelModel
        {
            get { return _bottomPanelModel; }
        }

        public GameModel()
        {
            _hexMapModel = new HexMapModel();
            _leftPanelModel = new LeftPanelModel();
            _rightPanelModel = new RightPanelModel();
            _topPanelModel = new TopPanelModel();
            _bottomPanelModel = new BottomPanelModel();
        }

        public void ImportGameData(GameData gameData)
        {
            _hexMapModel.ImportData(gameData.HexMapData);
            _leftPanelModel.ImportTileEditorData(gameData.ListTileColor, gameData.ListTileImage);
        }
    }
}
