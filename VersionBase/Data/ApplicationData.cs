using DataLibrary.General;
using DataLibrary.Hexes;
using DataLibrary.Tiles;
using VersionBase.Models;
using VersionBase.Libraries;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Data
{
    public class ApplicationData
    {
        public UIData UIData;
        public GameData GameData;

        public ApplicationData()
            :this(10,10)
        {
        }

        public ApplicationData(int colCount, int rowCount)
        {
            UIData = DataGeneration.GenerateUIData();
            GameData = DataGeneration.GenerateGameData(colCount, rowCount);
        }

        public void SaveApplicationModel(ApplicationModel aplicationModel, ApplicationData applicationData)
        {
            SaveGameModel(aplicationModel.GameModel, applicationData.GameData);
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