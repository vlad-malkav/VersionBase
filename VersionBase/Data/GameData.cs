using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Controls.Library.Models;
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
        public List<TileImageType> ListTileImageType;
        public HexMapData HexMapData;

        public GameData()
        {
            RowCount = 10;
            ColCount = 10;
            ListTileColor = TileColors.GetAllTileColors();
            ListTileImageType = TileImageTypes.GetAllTileImageTypes();
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
            if (Enum.TryParse(hexModel.TileImageTypeModel.Id, out tileImageType))
            {
                hexData.TileData.TileImageType = tileImageType;
            }
            hexData.DegreExploration = hexModel.DegreExploration;
            hexData.Description = hexModel.Description;
        }
    }
}