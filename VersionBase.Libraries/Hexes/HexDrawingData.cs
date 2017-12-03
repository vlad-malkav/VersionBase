using System;

namespace VersionBase.Libraries.Hexes
{
    public class HexDrawingData
    {
        private double _CellSize { get; set; }
        public double CellSize => _CellSize;

        public double _CellX { get; set; }
        public double CellX => _CellX;

        public double _CellY { get; set; }
        public double CellY => _CellY;

        public double _CellHeight { get; set; }
        public double CellHeight => _CellHeight;

        public double _RowHeight { get; set; }
        public double RowHeight => _RowHeight;


        public HexDrawingData() { }

        public HexDrawingData(HexCoordinates hexCoordinates, double cellSize)
        {
            _CellSize = cellSize;
            _CellHeight = CellSize * Math.Sqrt(3);
            _RowHeight = (CellSize * Math.Sqrt(3) / 2) + (CellSize * Math.Sqrt(3)) * (hexCoordinates.Row+1);
            _CellX = CellSize + (3 * CellSize / 2) * hexCoordinates.Column;
            _CellY = RowHeight + ((hexCoordinates.Column & 1) == 1 ? CellHeight / 2 : 0);
        }
    }
}
