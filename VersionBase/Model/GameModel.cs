using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.Library.Models;
using VersionBase.Data;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Model
{
    public class GameModel
    {
        public TileEditorModel TileEditorModel;
        public HexMapModel HexMapModel;

        public GameModel()
        {
            TileEditorModel = new TileEditorModel();
            HexMapModel = new HexMapModel();
        }

        public GameModel(GameData gameData)
            : this()
        {
            TileEditorModel.ImportListTileColor(gameData.ListTileColor);
            TileEditorModel.ImportListTileImageType(gameData.ListTileImageType);
            HexMapModel.ImportData(gameData.HexMapData);
        }
    }
}
