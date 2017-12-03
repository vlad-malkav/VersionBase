using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VersionBase.Libraries.Tiles;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace VersionBase.Libraries.Hexes
{
    public static class HexMapDrawing
    {
        public static Polygon GenerateHex(HexDrawingData hexDrawingData, TileData tileData)
        {
            var hex = new Polygon();
            hex.Points.Add(new Point(hexDrawingData.CellX - hexDrawingData.CellSize, hexDrawingData.CellY));
            hex.Points.Add(new Point(hexDrawingData.CellX - hexDrawingData.CellSize / 2, hexDrawingData.CellY + hexDrawingData.CellHeight / 2));
            hex.Points.Add(new Point(hexDrawingData.CellX + hexDrawingData.CellSize / 2, hexDrawingData.CellY + hexDrawingData.CellHeight / 2));
            hex.Points.Add(new Point(hexDrawingData.CellX + hexDrawingData.CellSize, hexDrawingData.CellY));
            hex.Points.Add(new Point(hexDrawingData.CellX + hexDrawingData.CellSize / 2, hexDrawingData.CellY - hexDrawingData.CellHeight / 2));
            hex.Points.Add(new Point(hexDrawingData.CellX - hexDrawingData.CellSize / 2, hexDrawingData.CellY - hexDrawingData.CellHeight / 2));
            
            hex.Fill = new ImageBrush(GenerateTileBitmapImage(tileData));
            hex.Stroke = new SolidColorBrush(Colors.Black);
            hex.StrokeThickness = hexDrawingData.CellSize / 10;
            return hex;
        }

        public static void UpdateHex(Polygon hex, HexDrawingData hexDrawingData, TileData tileData)
        {
            hex.Points.Clear();
            hex.Points.Add(new Point(hexDrawingData.CellX - hexDrawingData.CellSize, hexDrawingData.CellY));
            hex.Points.Add(new Point(hexDrawingData.CellX - hexDrawingData.CellSize / 2, hexDrawingData.CellY + hexDrawingData.CellHeight / 2));
            hex.Points.Add(new Point(hexDrawingData.CellX + hexDrawingData.CellSize / 2, hexDrawingData.CellY + hexDrawingData.CellHeight / 2));
            hex.Points.Add(new Point(hexDrawingData.CellX + hexDrawingData.CellSize, hexDrawingData.CellY));
            hex.Points.Add(new Point(hexDrawingData.CellX + hexDrawingData.CellSize / 2, hexDrawingData.CellY - hexDrawingData.CellHeight / 2));
            hex.Points.Add(new Point(hexDrawingData.CellX - hexDrawingData.CellSize / 2, hexDrawingData.CellY - hexDrawingData.CellHeight / 2));

            hex.Fill = new ImageBrush(GenerateTileBitmapImage(tileData));
            hex.Stroke = new SolidColorBrush(Colors.Black);
            hex.StrokeThickness = hexDrawingData.CellSize / 10;
        }

        public static void GetCombSize(double actualHeight, double actualWidth, int columns, int rows, out double cellSize, out double combWidth, out double combHeight)
        {
            double columnFactor = (3 * columns + 1) / 1.5;
            double rowFactor = (Math.Sqrt(3) * (2 * rows + 1)) / 1.5;
            double cellFromWidth = actualWidth / columnFactor;
            double cellFromHeight = actualHeight / rowFactor;
            cellSize = Math.Min(cellFromWidth, cellFromHeight);
            combWidth = cellSize * columnFactor;
            combHeight = cellSize * rowFactor;
        }

        #region Bitmap Functions

        public static BitmapImage GenerateTileBitmapImage(TileData tileData)
        {
            return GenerateTileBitmapImage(
                tileData.TileColor.GetDrawingColor(),
                tileData.TileImageType != null ? TileImageTypes.GetBitmapTile(tileData.TileImageType) : null);
        }

        public static BitmapImage GenerateTileBitmapImage(Color color, Bitmap bitmapTile)
        {
            float scaleHeight = (float)2.5;
            float scaleWidth = (float)2.5;
            float scale = Math.Min(scaleHeight, scaleWidth);

            BitmapImage tileBitmapImage;

            if (bitmapTile != null)
            {
                Bitmap bTileResized = new Bitmap(bitmapTile,
                    (int)(bitmapTile.Width * scale), (int)(bitmapTile.Height * scale));
                tileBitmapImage = Convert(SuperimposeB(GenerateTile(bTileResized, color), bitmapTile));
            }
            else
            {
                Bitmap bTileResized = new Bitmap(bitmapTile,
                    (int)(250 * scale), (int)(250 * scale));
                tileBitmapImage = Convert(GenerateTile(bTileResized, color));
            }

            return tileBitmapImage;
        }

        public static BitmapImage Convert(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Bmp);
            ms.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();

            return bi;
        }

        public static Bitmap SuperimposeB(Bitmap largeBmp, Bitmap smallBmp)
        {
            Graphics g = Graphics.FromImage(largeBmp);
            g.CompositingMode = CompositingMode.SourceOver;
            smallBmp.MakeTransparent();
            int margin = 5;
            int x = ((largeBmp.Width - smallBmp.Width) / 3) - 20;
            int y = ((largeBmp.Height - smallBmp.Height) / 3) - 20;
            g.DrawImage(smallBmp, new PointF(x, y));
            return largeBmp;
        }

        public static Bitmap GenerateTile(Bitmap baseBitmap, System.Drawing.Color color)
        {
            Bitmap bmp = new Bitmap(baseBitmap.Width, baseBitmap.Height);
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (SolidBrush brush = new SolidBrush(color))
            {
                gfx.FillRectangle(brush, 0, 0, baseBitmap.Width, baseBitmap.Height);
            }
            return bmp;
        }

        #endregion
    }
}
