using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controls.Library.Forms;
using Controls.Library.Models;
using VersionBase.Libraries.Enums;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;
using VersionBase.Model;

namespace VersionBase.Data
{
    public class GameData
    {
        private int RowCount { get; set; }
        private int ColCount { get; set; }
        public List<TileColor> ListTileColor;
        public List<TileImage> ListTileImage;
        public HexMapData HexMapData;

        public GameData() { }

        public GameData(int colCount, int rowCount)
        {
            ColCount = colCount;
            RowCount = rowCount;
            ListTileColor = TileColors.GetAllTileColors();
            ListTileImage = TileImages.GetAllTileImages();
            HexMapData = HexMapData.GeneratHexMapData(ColCount, RowCount);
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
            hexData.TileData.TileColor = new TileColor(hexModel.TileColorModel.GetDrawingColor());
            TileImageType tileImageType;
            if (Enum.TryParse(hexModel.TileImageModel.Id, out tileImageType))
            {
                hexData.TileData.TileImage = new TileImage(tileImageType);
            }
            hexData.DegreExploration = hexModel.DegreExploration;
            hexData.Description = hexModel.Description;
        }
    }
}