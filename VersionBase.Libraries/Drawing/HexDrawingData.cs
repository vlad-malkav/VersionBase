using System;
using System.Collections.Generic;
using System.Windows;

namespace VersionBase.Libraries.Drawing
{
    public class HexDrawingData
    {
        private int _column;
        private int _row;
        //private double _xCenterMod;
        //private double _yCenterMod;
        private double _cellSize;
        private double _cellX;
        private double _cellY;
        private double _cellHeight;
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

        //public double XCenterMod
        //{
        //    get { return _xCenterMod; }
        //}

        //public double YCenterMod
        //{
        //    get { return _yCenterMod; }
        //}

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

        public void SetHexCoordinates(int column, int row)
        {
            _column = column;
            _row = row;
        }

        public void UpdateDrawing(double cellSize)
        {
            _cellSize = cellSize;
            _cellHeight = GetCellHeight(CellSize);
            _cellX = GetCellX(CellSize, Column);
            _cellY = GetCellY(CellSize, Column, Row);
            RegeneratePoints();
        }

        private void RegeneratePoints()
        {
            _listOuterSummitPoints.Clear();
            _listOuterSummitPoints.Add(new Point(CellX - CellSize, CellY));
            _listOuterSummitPoints.Add(new Point(CellX - CellSize / 2, CellY + CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellX + CellSize / 2, CellY + CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellX + CellSize, CellY));
            _listOuterSummitPoints.Add(new Point(CellX + CellSize / 2, CellY - CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellX - CellSize / 2, CellY - CellHeight / 2));

            _listInnerSummitPoints.Clear();
            _listInnerSummitPoints.Add(new Point(CellX - CellSize / 2, CellY));
            _listInnerSummitPoints.Add(new Point(CellX - CellSize / 4, CellY + CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellX + CellSize / 4, CellY + CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellX + CellSize / 2, CellY));
            _listInnerSummitPoints.Add(new Point(CellX + CellSize / 4, CellY - CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellX - CellSize / 4, CellY - CellHeight / 4));

            _listOuterMiddlePoints.Clear();
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[0], _listOuterSummitPoints[1]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[1], _listOuterSummitPoints[2]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[2], _listOuterSummitPoints[3]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[3], _listOuterSummitPoints[4]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[4], _listOuterSummitPoints[5]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[5], _listOuterSummitPoints[0]));
        }

        #region Static functions

        public static double GetCellWidth(double cellSize)
        {
            return cellSize * 2;
        }

        public static double GetCellHeight(double cellSize)
        {
            return cellSize * Math.Sqrt(3);
        }

        public static double GetCellX(double cellSize, int column)
        {
            return GetCellWidth(cellSize) * (0.5 + 0.75 * column);
        }

        public static double GetCellY(double cellSize, int column, int row)
        {
            return GetCellHeight(cellSize) * (
                ((column & 1) == 1 ? 1 : 0.5)
                + row);
        }

        #endregion Static functions
    }
}
