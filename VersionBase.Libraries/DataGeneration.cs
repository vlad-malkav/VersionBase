﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Libraries
{
    public static class DataGeneration
    {
        public static HexMapData GeneratHexMapData(int columns, int rows)
        {
            List<HexData> listHexData = new List<HexData>();

            List<TileImageData> listTileImage = TileImageHelper.GetAllTileImages();

            int tileTypeCurrent = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    TileData tileData = new TileData(new TileColorData(Color.LightGreen),
                        listTileImage[tileTypeCurrent++ % listTileImage.Count]);
                    HexData hexDataTmp = new HexData(col, row, "Description de l'hex " + col + "-" + row, tileTypeCurrent++ % 7, tileData);
                    listHexData.Add(hexDataTmp);
                }
            }
            return new HexMapData(columns, rows, listHexData);
        }
    }
}
