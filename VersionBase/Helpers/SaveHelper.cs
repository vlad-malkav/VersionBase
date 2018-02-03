using DataLibrary.General;
using DataLibrary.Hexes;
using DataLibrary.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Models;

namespace VersionBase.Helpers
{
    public static class SaveHelper
    {

        public static GameData SaveGameModel(GameModel gameModel)
        {
            GameData gameData = new GameData(SaveHexMapModel(gameModel.HexMapModel));
            return gameData;
        }

        public static HexMapData SaveHexMapModel(HexMapModel hexMapModel)
        {
            HexMapData hexMapData = new HexMapData
            {
                Columns = hexMapModel.Columns,
                Rows = hexMapModel.Rows,
                ListHexData = hexMapModel.ListHexModel.Select(hexModel => SaveHexModel(hexModel)).ToList()
            };
            return hexMapData;
        }

        public static HexData SaveHexModel(HexModel hexModel)
        {
            HexData hexData = new HexData
            {
                Column = hexModel.Column,
                Row = hexModel.Row,
                TileData = new TileData(
                    new TileColorData(hexModel.TileColorModel.GetDrawingColor()),
                    new TileImageData(hexModel.TileImageModel.Id)),
                DegreExploration = hexModel.DegreExploration,
                Description = hexModel.Description
            };
            return hexData;
        }
    }
}
