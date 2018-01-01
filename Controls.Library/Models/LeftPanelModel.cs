using System;
using System.Collections.Generic;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class LeftPanelModel
    {
        private TileEditorModel _tileEditorModel;
        private List<GameModeModel> _listGameModeModel;

        public TileEditorModel TileEditorModel
        {
            get { return _tileEditorModel; }
        }
        public List<GameModeModel> ListGameModeModel
        {
            get { return _listGameModeModel; }
            set { _listGameModeModel = value; }
        }

        public LeftPanelModel()
        {
            _tileEditorModel = new TileEditorModel();
            _listGameModeModel = new List<GameModeModel>();
        }

        public void ImportTileEditorData(List<TileColor> listTileColor, List<TileImage> listTileImage)
        {
            _tileEditorModel.ImportListTileColor(listTileColor);
            _tileEditorModel.ImportListTileImage(listTileImage);
        }

        public void ImportGameModeData(List<Tuple<int,string>> listGameModeData)
        {
            _listGameModeModel.Clear();
            foreach (var tupleIdName in listGameModeData)
            {
                GameModeModel gameModeModelTmp = new GameModeModel();
                gameModeModelTmp.ImportGameModeData(tupleIdName.Item1, tupleIdName.Item2);
                _listGameModeModel.Add(gameModeModelTmp);
            }
        }
    }
}
