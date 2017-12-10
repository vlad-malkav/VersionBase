using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Libraries.Hexes
{
    public class HexMapData
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public List<HexData> ListHexData { get; set; }

        public HexMapData()
            : this(10,10)
        {
            ListHexData = new List<HexData>();
        }

        public HexMapData(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            ListHexData = new List<HexData>();
            TileData emptyTileData = new TileData(new TileColor(Color.Transparent), TileImageType.empty);
            for (int col = 0; col < Columns; col++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    ListHexData.Add(new HexData(col, row, "", emptyTileData));
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

        public static HexMapData GeneratHexMapData(int columns, int rows)
        {
            List<HexData> listHexData = new List<HexData>();

            List<TileImageType> listTileImageType = TileImageTypes.GetAllTileImageTypes();

            int tileTypeCurrent = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    TileData tileData = new TileData(new TileColor(Color.LightGreen),
                        listTileImageType[tileTypeCurrent++ % listTileImageType.Count]);
                    HexData hexDataTmp = new HexData(col, row, "2", tileData);
                    listHexData.Add(hexDataTmp);
                }
            }
            return new HexMapData(columns, rows, listHexData);
        }
    }
}
