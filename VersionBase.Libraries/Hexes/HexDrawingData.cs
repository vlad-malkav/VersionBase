using System;

namespace VersionBase.Libraries.Hexes
{
    public class HexDrawingData
    {
        private int _Column { get; set; }
        private int _Row { get; set; }
        private double _CellSize { get; set; }
        private double _CellX { get; set; }
        private double _CellY { get; set; }
        private double _CellHeight { get; set; }
        private double _RowHeight { get; set; }

        public int Column
        {
            get { return _Column; }
        }

        public int Row
        {
            get { return _Row; }
        }

        public double CellSize
        {
            get { return _CellSize; }
        }

        public double CellX
        {
            get { return _CellX; }
        }

        public double CellY
        {
            get { return _CellY; }
        }

        public double CellHeight
        {
            get { return _CellHeight; }
        }

        public double RowHeight
        {
            get { return _RowHeight; }
        }


        public HexDrawingData() { }

        public HexDrawingData(int column, int row, double cellSize)
        {
            _Column = column;
            _Row = row;
            UpdateCellSize(cellSize);
        }

        public void UpdateCellSize(double cellSize)
        {
            _CellSize = cellSize;
            _CellHeight = CellSize * Math.Sqrt(3);
            _RowHeight = (CellSize * Math.Sqrt(3) / 2) + (CellSize * Math.Sqrt(3)) * (_Row + 1);
            _CellX = CellSize + (3 * CellSize / 2) * _Column;
            _CellY = RowHeight + ((_Column & 1) == 1 ? CellHeight / 2 : 0);
        }
    }
}
