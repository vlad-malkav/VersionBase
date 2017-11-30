using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionBase.Libraries.Hexes
{
    public class HexDrawingData
    {
        public double CellSize { get; set; }
        public double CellX { get; set; }
        public double CellY { get; set; }
        public double CellHeight { get; set; }
        public double RowHeight { get; set; }

        public HexDrawingData() { }

        public HexDrawingData(HexCoordinates hexCoordinates, double cellSize)
        {
            CellSize = cellSize;
            CellHeight = cellSize * Math.Sqrt(3);
            RowHeight = (cellSize * Math.Sqrt(3) / 2) + (cellSize * Math.Sqrt(3)) * (hexCoordinates.Row+1);
            CellX = cellSize + (3 * cellSize / 2) * hexCoordinates.Column;
            CellY = RowHeight + ((hexCoordinates.Column & 1) == 1 ? CellHeight / 2 : 0);
        }
    }
}
