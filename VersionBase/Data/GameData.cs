using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

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
            HexMapData = null;

            //Generate the hex map
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(HexMapData));
                using (var sr = new StreamReader(Environment.CurrentDirectory + "\\garage.xml"))
                {
                    HexMapData = (HexMapData)xs.Deserialize(sr);
                }
            }
            catch (Exception)
            {
            }

            if (HexMapData == null || HexMapData.Columns != ColCount || HexMapData.Rows != RowCount)
            {
                HexMapData = HexMapData.GeneratHexMapData(ColCount, RowCount);
            }
        }
    }
}