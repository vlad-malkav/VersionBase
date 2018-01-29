using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DataLibrary.Hexes;
using DataLibrary.Tiles;

namespace DataLibrary.General
{
    public class HexMapData
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public List<HexData> ListHexData { get; set; }

        public HexMapData()
            : this(0,0)
        {
        }

        public HexMapData(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            ListHexData = new List<HexData>();
            TileData emptyTileData = new TileData(new TileColorData(Color.Transparent), new TileImageData("empty"));
            for (int col = 0; col < Columns; col++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    ListHexData.Add(new HexData(col, row, "", 0, emptyTileData));
                }
            }
        }

        public HexMapData(int columns, int rows, List<HexData> listHexData)
        {
            Columns = columns;
            Rows = rows;
            ListHexData = listHexData ?? new List<HexData>();
        }

        public HexData GetHexData(int column, int row)
        {
            return ListHexData.FirstOrDefault(x => x.Column == column && x.Row == row);
        }
    }
}
