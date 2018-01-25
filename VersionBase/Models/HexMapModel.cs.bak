using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows;
using Controls.Library.ViewModels;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class HexMapModel
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public double CellSize { get; set; }
        public List<HexModel> ListHexModel { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public HexMapModel()
        {
            Width = 300;
            Height = 300;
            Columns = 10;
            Rows = 10;
            CellSize = 25;
            ListHexModel = GenerateListHexModel(Columns, Rows, CellSize);
        }

        public HexMapModel(List<HexModel> listHexModel, double width, double height, double cellSize, int rows, int colums)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
            Columns = colums;
            Rows = rows;
            ListHexModel = listHexModel;
        }

        public HexModel GetHexModel(int column, int row)
        {
            return ListHexModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }

        public static List<HexModel> GenerateListHexModel(int columns, int rows, double cellSize)
        {
            List<HexModel> listHexModel = new List<HexModel>();

            List<TileImageType> listTileImageType = TileImageTypes.GetAllTileImageTypes();

            int tileTypeCurrent = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    TileData tileData = new TileData(new TileColor(Color.LightGreen),
                        listTileImageType[tileTypeCurrent++ % listTileImageType.Count]);
                    HexData hexDataTmp = new HexData(col, row, "-", tileData, cellSize);
                    listHexModel.Add(new HexModel(hexDataTmp));
                }
            }
            return listHexModel;
        }
    }
}
