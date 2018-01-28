using System;
using System.Collections.Generic;
using DataLibrary.Tiles;
using VersionBase.Libraries.Enums;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Models
{
    public class UILeftPanelModel
    {
        private UITileEditorModel _tileEditorModel;
        private List<GameModeModel> _listGameModeModel;

        public UITileEditorModel UITileEditorModel
        {
            get { return _tileEditorModel; }
        }
        public List<GameModeModel> ListGameModeModel
        {
            get { return _listGameModeModel; }
            set { _listGameModeModel = value; }
        }

        public UILeftPanelModel()
        {
            _tileEditorModel = new UITileEditorModel();
            _listGameModeModel = new List<GameModeModel>();
        }

        public void ImportUITileEditorData(List<TileColorData> listTileColor, List<TileImageData> listTileImage)
        {
            _tileEditorModel.ImportListTileColor(listTileColor);
            _tileEditorModel.ImportListTileImage(listTileImage);
        }

        public void ImportGameModeData(List<GameMode> listGameMode)
        {
            _listGameModeModel.Clear();
            foreach (var gameMode in listGameMode)
            {
                GameModeModel gameModeModelTmp = new GameModeModel();
                gameModeModelTmp.ImportGameModeData(gameMode);
                _listGameModeModel.Add(gameModeModelTmp);
            }
        }
    }
}
