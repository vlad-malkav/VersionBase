using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VersionBase.Libraries.Hexes
{
    public class HexDrawingData
    {
        private int _column;
        private int _row;
        private double _xCenterMod;
        private double _yCenterMod;
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

        public double XCenterMod
        {
            get { return _xCenterMod; }
        }

        public double YCenterMod
        {
            get { return _yCenterMod; }
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

        public HexDrawingData(int column, int row, double xCenterMod, double yCenterMod, double cellSize)
            :this()
        {
            _column = column;
            _row = row;

            UpdateDrawing(xCenterMod,yCenterMod,cellSize);
        }

        public void UpdateDrawing(double xCenterMod, double yCenterMod, double cellSize)
        {
            _xCenterMod = xCenterMod;
            _yCenterMod = yCenterMod;
            _cellSize = cellSize;
            _cellHeight = GetCellHeight(CellSize);
            _rowHeight = GetRowHeight(CellSize, Row);
            //DESBONAL : fullscreen _rowHeight = (Math.Sqrt(3)) * CellSize * _row;
            _cellX = GetCellX(CellSize, Column, XCenterMod);
            _cellY = GetCellY(CellSize, Column, Row, YCenterMod);
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

        #region Static functions

        public static Point Midpoint(Point a, Point b) {
            return new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2);
        }

        public static double GetCellHeight(double cellSize)
        {
            return cellSize * Math.Sqrt(3);
        }

        public static double GetRowHeight(double cellSize, int row)
        {
            return (cellSize * Math.Sqrt(3) / 2) + (cellSize * Math.Sqrt(3)) * (row + 1);
        }

        public static double GetCellX(double cellSize, int column, double xCenterMod)
        {
            return cellSize + (3 * cellSize / 2) * column + xCenterMod;
        }

        public static double GetCellY(double cellSize, int column, int row, double yCenterMod)
        {
            return GetRowHeight(cellSize, row) + ((column & 1) == 1 ? GetCellHeight(cellSize) / 2 : 0);
        }

        public static void Move(Polygon polygon, double moveX, double moveY)
        {
            PointCollection newPoints = new PointCollection();
            foreach (var point in polygon.Points)
            {
                newPoints.Add(new Point(point.X + moveX, point.Y + moveY));
            }
            polygon.Points = newPoints;
        }

        #endregion Static functions
    }
}
