using System;
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

        public double CellCenterX
        {
            get { return _cellCenterX; }
        }

        public double CellCenterY
        {
            get { return _cellCenterY; }
        }

        public double CellHeight
        {
            get { return _cellHeight; }
        }

        public Point CenterPoint
        {
            get { return new Point(_cellCenterX, _cellCenterY); }
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
            _listOuterSummitPoints.Add(new Point(CellCenterX - CellRadius, CellCenterY));
            _listOuterSummitPoints.Add(new Point(CellCenterX - CellRadius / 2, CellCenterY + CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellCenterX + CellRadius / 2, CellCenterY + CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellCenterX + CellRadius, CellCenterY));
            _listOuterSummitPoints.Add(new Point(CellCenterX + CellRadius / 2, CellCenterY - CellHeight / 2));
            _listOuterSummitPoints.Add(new Point(CellCenterX - CellRadius / 2, CellCenterY - CellHeight / 2));

            _listInnerSummitPoints.Clear();
            _listInnerSummitPoints.Add(new Point(CellCenterX - CellRadius / 2, CellCenterY));
            _listInnerSummitPoints.Add(new Point(CellCenterX - CellRadius / 4, CellCenterY + CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellCenterX + CellRadius / 4, CellCenterY + CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellCenterX + CellRadius / 2, CellCenterY));
            _listInnerSummitPoints.Add(new Point(CellCenterX + CellRadius / 4, CellCenterY - CellHeight / 4));
            _listInnerSummitPoints.Add(new Point(CellCenterX - CellRadius / 4, CellCenterY - CellHeight / 4));

            _listOuterMiddlePoints.Clear();
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[0], _listOuterSummitPoints[1]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[1], _listOuterSummitPoints[2]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[2], _listOuterSummitPoints[3]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[3], _listOuterSummitPoints[4]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[4], _listOuterSummitPoints[5]));
            _listOuterMiddlePoints.Add(DrawingFunctions.Midpoint(_listOuterSummitPoints[5], _listOuterSummitPoints[0]));
        }

        public void Move(double moveX, double moveY)
        {
            _cellCenterX += moveX;
            _cellCenterY += moveY;
            RegeneratePoints();
        }

        public Point GetCloserPointToPoint(Point point)
        {
            Point closerPoint = CenterPoint;
            double closerDistance = PointToPointDistance(point, closerPoint);

            foreach (Point pointTmp in _listOuterSummitPoints)
            {
                double distanceTmp = PointToPointDistance(point, pointTmp);
                if (distanceTmp < closerDistance)
                {
                    closerPoint = pointTmp;
                    closerDistance = distanceTmp;
                }
            }

            foreach (Point pointTmp in _listInnerSummitPoints)
            {
                double distanceTmp = PointToPointDistance(point, pointTmp);
                if (distanceTmp < closerDistance)
                {
                    closerPoint = pointTmp;
                    closerDistance = distanceTmp;
                }
            }

            foreach (Point pointTmp in _listOuterMiddlePoints)
            {
                double distanceTmp = PointToPointDistance(point, pointTmp);
                if (distanceTmp < closerDistance)
                {
                    closerPoint = pointTmp;
                    closerDistance = distanceTmp;
                }
            }

            return closerPoint;
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

        public static double PointToPointDistance(Point p1, Point p2)
        {
            return (Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        #endregion Static functions
    }
}