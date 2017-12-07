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
            ListHexModel = new List<HexModel>();
        }

        public HexMapModel(HexMapData hexMapData, double width, double height, double cellSize)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
            Columns = hexMapData.Columns;
            Rows = hexMapData.Rows;
            ListHexModel = hexMapData.ListHexData.Select(x => new HexModel(x)).ToList();
        }

        public HexModel GetHexModel(int column, int row)
        {
            return ListHexModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }
    }
}
