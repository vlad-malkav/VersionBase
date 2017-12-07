﻿using VersionBase.Libraries.Tiles;

namespace VersionBase.Libraries.Hexes
{
    public class HexData
    {
        public string Text { get; set; }
        public TileData TileData { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }

        public HexData(){}

        public HexData(int column, int row, string text, TileData tileData)
        {
            Column = column;
            Row = row;
            Text = text;
            TileData = tileData;
        }
    }
}
