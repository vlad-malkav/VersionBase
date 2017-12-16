using System;
using System.Collections.Generic;
using System.Windows;

namespace VersionBase.Libraries.Hexes
{
    public class HexDrawingData
    {
        private int _column;
        private int _row;
        private double _cellSize;
        private double _cellX;
        private double _cellY;
        private double _cellHeight;
        private double _rowHeight;
        private List<Point> _listOuterSummitPoints;
        private List<Point> _listOuterMiddlePoints;
        private List<Point> _listInnerSummitPoints;

        public int Column
        {
            get { return _column; }
        }

        public int Row
        {
            get { return _row; }
        }

        public double CellSize
        {
            get { return _cellSize; }
        }

        public double CellX
        {
            get { return _cellX; }
        }

        public double CellY
        {
            get { return _cellY; }
        }

        public double CellHeight
        {
            get { return _cellHeight; }
        }

        public double RowHeight
        {
            get { return _rowHeight; }
        }

        public List<Point> ListOuterSummitPoints
        {
            get { return _listOuterSummitPoints; }
        }

        public List<Point> ListOuterMiddlePoints
        {
            get { return _listOuterMiddlePoints; }
        }

        public List<Point> ListInnerSummitPoints
        {
            get { return _listInnerSummitPoints; }
        }


        public HexDrawingData()
        {
            _listInnerSummitPoints = new List<Point>();
            _listOuterMiddlePoints = new List<Point>();
            _listOuterSummitPoints = new List<Point>();
        }

        public HexDrawingData(int column, int row, double cellSize)
            :this()
        {
            _column = column;
            _row = row;
            UpdateCellSize(cellSize);
        }

        public void UpdateCellSize(double cellSize)
        {
            _cellSize = cellSize;
            _cellHeight = CellSize * Math.Sqrt(3);
            _rowHeight = (CellSize * Math.Sqrt(3) / 2) + (CellSize * Math.Sqrt(3)) * (_row + 1);
            _cellX = CellSize + (3 * CellSize / 2) * _column;
            _cellY = RowHeight + ((_column & 1) == 1 ? CellHeight / 2 : 0);
            GeneratePoints();
        }

        private void GeneratePoints()
        {
            _listOuterSummitPoints.Add(new Point(CellX - CellSize, CellY));
            _listOuterSummitPoints.Add(new Point(CellX - CellSize / 2, CellY + CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellX + CellSize / 2, CellY + CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellX + CellSize, CellY));
            _listOuterSummitPoints.Add(new Point(CellX + CellSize / 2, CellY - CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellX - CellSize / 2, CellY - CellHeight / 2));

            _listInnerSummitPoints.Add(new Point(CellX - CellSize / 2, CellY));
            _listInnerSummitPoints.Add(new Point(CellX - CellSize / 4, CellY + CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellX + CellSize / 4, CellY + CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellX + CellSize / 2, CellY));
            _listInnerSummitPoints.Add(new Point(CellX + CellSize / 4, CellY - CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellX - CellSize / 4, CellY - CellHeight / 4));

            _listOuterMiddlePoints.Add(Midpoint(_listOuterSummitPoints[0], _listOuterSummitPoints[1]));
            _listOuterMiddlePoints.Add(Midpoint(_listOuterSummitPoints[1], _listOuterSummitPoints[2]));
            _listOuterMiddlePoints.Add(Midpoint(_listOuterSummitPoints[2], _listOuterSummitPoints[3]));
            _listOuterMiddlePoints.Add(Midpoint(_listOuterSummitPoints[3], _listOuterSummitPoints[4]));
            _listOuterMiddlePoints.Add(Midpoint(_listOuterSummitPoints[4], _listOuterSummitPoints[5]));
            _listOuterMiddlePoints.Add(Midpoint(_listOuterSummitPoints[5], _listOuterSummitPoints[0]));
        }

        private Point Midpoint(Point a, Point b) {
            return new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2);
        }
}
}
