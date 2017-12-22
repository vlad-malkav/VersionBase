using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VersionBase.Libraries.Drawing
{
    public static class DrawingFunctions
    {
        public static Point Midpoint(Point a, Point b)
        {
            return new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2);
        }

        #region Move Functions

        public static void MovePolygon(Polygon polygon, double moveX, double moveY)
        {
            PointCollection newPoints = new PointCollection();
            foreach (var point in polygon.Points)
            {
                newPoints.Add(new Point(point.X + moveX, point.Y + moveY));
            }
            polygon.Points = newPoints;
        }

        public static void MoveGrid(Grid grid, double moveX, double moveY)
        {
            grid.SetValue(Canvas.LeftProperty, (double)grid.GetValue(Canvas.LeftProperty) + moveX);
            grid.SetValue(Canvas.TopProperty, (double)grid.GetValue(Canvas.TopProperty) + moveY);
        }

        public static void MoveLine(Line line, double moveX, double moveY)
        {
            line.X1 += moveX;
            line.Y1 += moveY;
            line.X2 += moveX;
            line.Y2 += moveY;
        }

        #endregion Move Functions
    }
}
