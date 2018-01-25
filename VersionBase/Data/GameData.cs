using DataLibrary.General;
using DataLibrary.Hexes;
using DataLibrary.Tiles;
using VersionBase.Models;
using VersionBase.Libraries;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Data
{
    public class GameData
    {
        public UIData UIData;
        public HexMapData HexMapData;

        public GameData() { }

        public GameData(int colCount, int rowCount)
        {
            UIData = DataGeneration.GenerateUIData();
            HexMapData = DataGeneration.GenerateHexMapData(colCount, rowCount);
        }

        public void SaveGameModel(GameModel gameModel, GameData gameData)
        {
            SaveHexMapModel(gameModel.HexMapModel, gameData.HexMapData);
        }

        public void SaveHexMapModel(HexMapModel hexMapModel, HexMapData hexMapData)
        {
            foreach (var hexModel in hexMapModel.ListHexModel)
            {
                HexData hexData = hexMapData.GetHexData(hexModel.Column, hexModel.Row);
                SaveHexModel(hexModel, hexData);
            }
        }

        public void SaveHexModel(HexModel hexModel, HexData hexData)
        {
            hexData.TileData.TileColorData = new TileColorData(hexModel.TileColorModel.GetDrawingColor());
            hexData.TileData.TileImageData = new TileImageData(hexModel.TileImageModel.Id);
            hexData.DegreExploration = hexModel.DegreExploration;
            hexData.Description = hexModel.Description;
        }
    }
}