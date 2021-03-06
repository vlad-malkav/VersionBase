﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace VersionBase.Libraries.Drawing
{
    public class HexDrawingInformations
    {
        private int _column;
        private int _row;
        //private double _xCenterMod;
        //private double _yCenterMod;
        private double _cellRadius;
        private double _cellCenterX;
        private double _cellCenterY;
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

        public double CellRadius
        {
            get { return _cellRadius; }
        }

        public double CellX
        {
            get { return _cellCenterX; }
        }

        public double CellY
        {
            get { return _cellCenterY; }
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


        public HexDrawingInformations()
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

        public void UpdateDrawing(double cellRadius)
        {
            _cellRadius = cellRadius;
            _cellHeight = GetCellHeight(CellRadius);
            _cellCenterX = GetCellX(CellRadius, Column);
            _cellCenterY = GetCellY(CellRadius, Column, Row);
            RegeneratePoints();
        }

        private void RegeneratePoints()
        {
            _listOuterSummitPoints.Clear();
            _listOuterSummitPoints.Add(new Point(CellX - CellRadius, CellY));
            _listOuterSummitPoints.Add(new Point(CellX - CellRadius / 2, CellY + CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellX + CellRadius / 2, CellY + CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellX + CellRadius, CellY));
            _listOuterSummitPoints.Add(new Point(CellX + CellRadius / 2, CellY - CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellX - CellRadius / 2, CellY - CellHeight / 2));

            _listInnerSummitPoints.Clear();
            _listInnerSummitPoints.Add(new Point(CellX - CellRadius / 2, CellY));
            _listInnerSummitPoints.Add(new Point(CellX - CellRadius / 4, CellY + CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellX + CellRadius / 4, CellY + CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellX + CellRadius / 2, CellY));
            _listInnerSummitPoints.Add(new Point(CellX + CellRadius / 4, CellY - CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellX - CellRadius / 4, CellY - CellHeight / 4));

            _listOuterMiddlePoints.Clear();
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[0], _listOuterSummitPoints[1]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[1], _listOuterSummitPoints[2]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[2], _listOuterSummitPoints[3]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[3], _listOuterSummitPoints[4]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[4], _listOuterSummitPoints[5]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[5], _listOuterSummitPoints[0]));
        }

        #region Static functions

        public static double GetCellWidth(double cellRadius)
        {
            return cellRadius * 2;
        }

        public static double GetCellHeight(double cellRadius)
        {
            return cellRadius * Math.Sqrt(3);
        }

        public static double GetCellX(double cellRadius, int column)
        {
            return GetCellWidth(cellRadius) * (0.5 + 0.75 * column);
        }

        public static double GetCellY(double cellRadius, int column, int row)
        {
            return GetCellHeight(cellRadius) * (
                ((column & 1) == 1 ? 1 : 0.5)
                + row);
        }

        #endregion Static functions
    }
}
