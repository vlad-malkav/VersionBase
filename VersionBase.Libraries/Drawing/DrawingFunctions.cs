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

        public static System.Windows.Media.Color SystemDrawingColorToWindowsMediaColor(System.Drawing.Color systemDrawingColor)
        {
            return System.Windows.Media.Color.FromArgb(
                systemDrawingColor.A,
                systemDrawingColor.R,
                systemDrawingColor.G,
                systemDrawingColor.B);
        }

        public static System.Drawing.Color WindowsMediaColorToSystemDrawingColor(System.Windows.Media.Color systemWindowsMediaColor)
        {
            return System.Drawing.Color.FromArgb(
                systemWindowsMediaColor.A,
                systemWindowsMediaColor.R,
                systemWindowsMediaColor.G,
                systemWindowsMediaColor.B);
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
