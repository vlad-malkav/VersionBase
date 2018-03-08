using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DataLibrary.Hexes;
using DataLibrary.PointsAndLines;
using DataLibrary.Tiles;

namespace DataLibrary.General
{
    public class HexMapData
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public List<HexData> ListHexData { get; set; }
        public List<CommunityData> ListCommunityData { get; set; }

        public HexMapData()
        {
            ListHexData = new List<HexData>();
            ListCommunityData = new List<CommunityData>();
        }

        public HexMapData(int columns, int rows)
            :this()
        {
            Columns = columns;
            Rows = rows;
            TileData emptyTileData = new TileData(new TileColorData(Color.Transparent), new TileImageData("empty"));
            for (int col = 0; col < Columns; col++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    ListHexData.Add(new HexData(col, row, "", 0, emptyTileData));
                }
            }
        }

        public HexMapData(int columns, int rows, List<HexData> listHexData, List<CommunityData> listCommunityData = null)
        {
            Columns = columns;
            Rows = rows;
            ListHexData = listHexData ?? new List<HexData>();
            ListCommunityData = listCommunityData ?? new List<CommunityData>();
        }

        public HexData GetHexData(int column, int row)
        {
            return ListHexData.FirstOrDefault(x => x.Column == column && x.Row == row);
        }
    }
}
