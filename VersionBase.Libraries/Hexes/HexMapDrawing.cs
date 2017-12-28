using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VersionBase.Libraries.Tiles;
using Color = System.Drawing.Color;
using FontFamily = System.Windows.Media.FontFamily;
using Point = System.Windows.Point;

namespace VersionBase.Libraries.Hexes
{
    public static class HexMapDrawing
    {
        public static void DrawInsidePolygon(HexDrawingData hexDrawingData, Polygon insidePolygon, Color color, Bitmap bitmap)
        {
            insidePolygon.Points.Clear();
            foreach (var outerSummitPoint in hexDrawingData.ListOuterSummitPoints)
            {
                insidePolygon.Points.Add(outerSummitPoint);
            }
            insidePolygon.Tag = "InsidePolygon";
            Canvas.SetZIndex(insidePolygon, 0);
            UpdateInsidePolygonFill(insidePolygon, color, bitmap);
        }

        public static void UpdateInsidePolygon(HexDrawingData hexDrawingData, Polygon insidePolygon)
        {
            insidePolygon.Points.Clear();
            foreach (var outerSummitPoint in hexDrawingData.ListOuterSummitPoints)
            {
                insidePolygon.Points.Add(outerSummitPoint);
            }
            insidePolygon.Tag = "InsidePolygon";
            Canvas.SetZIndex(insidePolygon, 0);
        }

        public static void UpdateInsidePolygonFill(Polygon insidePolygon, Color color, Bitmap bitmap)
        {
            insidePolygon.Fill = new ImageBrush(GenerateTileImageSource(color, bitmap));
        }

        public static void DrawBorderPolygon(HexDrawingData hexDrawingData, Polygon borderPolygon)
        {
            borderPolygon.Points.Clear();
            foreach (var outerSummitPoint in hexDrawingData.ListOuterSummitPoints)
            {
                borderPolygon.Points.Add(outerSummitPoint);
            }

            borderPolygon.Tag = "BorderPolygon";
            UpdateBorderPolygonSelected(hexDrawingData, borderPolygon, false);
        }

        public static void UpdateBorderPolygonSelected(HexDrawingData hexDrawingData, Polygon borderPolygon, bool selected)
        {
            borderPolygon.Stroke = new SolidColorBrush(selected ? Colors.DarkOrange : Colors.Black);
            borderPolygon.StrokeThickness = hexDrawingData.CellSize / (selected ? 5 : 10);
            Canvas.SetZIndex(borderPolygon, selected ? 100 : 10);
        }

        public static void DrawHexLabel(HexDrawingData hexDrawingData, Grid gridLabel, string label)
        {
            gridLabel.Width = gridLabel.Height = (2 * hexDrawingData.CellSize) * 0.8;
            gridLabel.SetValue(Canvas.LeftProperty, hexDrawingData.CellX - hexDrawingData.CellSize * 0.8);
            gridLabel.SetValue(Canvas.TopProperty, hexDrawingData.CellY - hexDrawingData.CellSize * 0.8);
            gridLabel.IsHitTestVisible = false;
            gridLabel.Tag = "Label";

            UpdateHexLabelLabel(hexDrawingData, gridLabel, label);
        }

        public static void UpdateHexLabel(HexDrawingData hexDrawingData, Grid gridLabel)
        {
            gridLabel.Width = gridLabel.Height = (2 * hexDrawingData.CellSize) * 0.8;
            gridLabel.SetValue(Canvas.LeftProperty, hexDrawingData.CellX - hexDrawingData.CellSize * 0.8);
            gridLabel.SetValue(Canvas.TopProperty, hexDrawingData.CellY - hexDrawingData.CellSize * 0.8);
            gridLabel.IsHitTestVisible = false;
        }

        public static void UpdateHexLabelLabel(HexDrawingData hexDrawingData, Grid gridLabel, string label)
        {
            gridLabel.Children.Clear();
            var labelTextBlock = new TextBlock
            {
                Text = label,
                FontFamily = new FontFamily("Segoe"),
                FontSize = hexDrawingData.CellSize / 3.5,
                Background = new SolidColorBrush(Colors.Azure),
            };
            labelTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            labelTextBlock.VerticalAlignment = VerticalAlignment.Bottom;
            labelTextBlock.IsHitTestVisible = false;
            labelTextBlock.FontWeight = FontWeights.Bold;
            gridLabel.Children.Add(labelTextBlock);
        }

        public static void DrawHexLineExploration(HexDrawingData hexDrawingData, List<Line> listLineExploration, int degreExploration)
        {
            listLineExploration.Clear();

            for (int i = 0; i < 6; i++)
            {
                Line lineExploration = new Line();
                lineExploration.X1 = hexDrawingData.ListOuterSummitPoints[i].X;
                lineExploration.Y1 = hexDrawingData.ListOuterSummitPoints[i].Y;
                lineExploration.X2 = hexDrawingData.ListInnerSummitPoints[i].X;
                lineExploration.Y2 = hexDrawingData.ListInnerSummitPoints[i].Y;
                lineExploration.Tag = "Line";
                lineExploration.Stroke = new SolidColorBrush(Colors.Gold);
                lineExploration.StrokeThickness = hexDrawingData.CellSize / 8;
                Canvas.SetZIndex(lineExploration, 2);
                UpdateLineExplorationVisibility(lineExploration, i, degreExploration);
                listLineExploration.Add(lineExploration);
            }
        }

        public static void UpdateHexLineExploration(HexDrawingData hexDrawingData, List<Line> listLineExploration)
        {
            for (int i = 0; i < 6; i++)
            {
                listLineExploration[i].X1 = hexDrawingData.ListOuterSummitPoints[i].X;
                listLineExploration[i].Y1 = hexDrawingData.ListOuterSummitPoints[i].Y;
                listLineExploration[i].X2 = hexDrawingData.ListInnerSummitPoints[i].X;
                listLineExploration[i].Y2 = hexDrawingData.ListInnerSummitPoints[i].Y;
                listLineExploration[i].Tag = "Line";
                listLineExploration[i].Stroke = new SolidColorBrush(Colors.Gold);
                listLineExploration[i].StrokeThickness = hexDrawingData.CellSize / 8;
            }
        }

        public static void UpdateLineExplorationVisibility(Line lineExploration, int indexLine, int degreExploration)
        {
            lineExploration.Visibility = indexLine >= degreExploration ? Visibility.Hidden : Visibility.Visible;
        }

        #region Map Dimension Functions

        public static double GetTrueWidth(double cellSize, int columns)
        {
            double cellWidth = HexDrawingData.GetCellWidth(cellSize);
            double maxCellX = HexDrawingData.GetCellX(cellSize, columns - 1);
            return maxCellX + (cellWidth / 2);
        }

        public static double GetTrueHeight(double cellSize, int columns, int rows)
        {
            double cellHeight = HexDrawingData.GetCellHeight(cellSize);
            return rows * cellHeight
                + (columns > 1 ? cellHeight / 2 : 0);
        }

        public static double GetOriginalXCenter(double cellSize, int columns)
        {
            //return HexDrawingData.GetCellX(cellSize, 0) - cellSize +*/
            return GetTrueWidth(cellSize, columns) / 2;
        }

        public static double GetOriginalYCenter(double cellSize, int columns, int rows)
        {
            //return HexDrawingData.GetCellY(cellSize, 0, 0) - HexDrawingData.GetCellHeight(cellSize) +
            return GetTrueHeight(cellSize, columns, rows) / 2;
        }

        public static void GetCombSize(double actualHeight, double actualWidth, int columns, int rows, out double cellSize)
        {
            double nbHexWidths = 1 + 0.75 * (columns - 1);
            double nbHexHeights = rows + (columns > 1 ? 0.5 : 0);
            double nbCellSizePerHexWidth = 2;
            double nbCellSizePerHexHeight = Math.Sqrt(3);
            double cellSizeFromWidth = actualWidth / (nbHexWidths * nbCellSizePerHexWidth);
            double cellSizeFromHeight = actualHeight / (nbHexHeights * nbCellSizePerHexHeight);
            cellSize = Math.Min(cellSizeFromWidth, cellSizeFromHeight);

            /*double columnFactor = (3 * columns + 1) / 1.5;
            double rowFactor = (Math.Sqrt(3) * (2 * rows + 1)) / 1.5;
            double cellFromWidth = actualWidth / columnFactor;
            double cellFromHeight = actualHeight / rowFactor;
            cellSize = Math.Min(cellFromWidth, cellFromHeight);
            combWidth = cellSize * columnFactor;
            combHeight = cellSize * rowFactor;*/
        }

        #endregion Map Dimension Functions

        #region Bitmap Functions

        public static BitmapImage GenerateTileBitmapImage(TileData tileData)
        {
            return GenerateTileBitmapImage(
                tileData.TileColor.GetDrawingColor(),
                tileData.TileImage.Bitmap);
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

        public static ImageSource GenerateTileImageSource(Color color, Bitmap bitmapTile)
        {
            float scaleHeight = (float)2.5;
            float scaleWidth = (float)2.5;
            float scale = Math.Min(scaleHeight, scaleWidth);

            ImageSource tileImageSource;

            if (bitmapTile != null)
            {
                Bitmap bTileResized = new Bitmap(bitmapTile,
                    (int)(bitmapTile.Width * scale), (int)(bitmapTile.Height * scale));
                tileImageSource = ConvertToIS(SuperimposeB(GenerateTile(bTileResized, color), bitmapTile));
            }
            else
            {
                Bitmap bTileResized = new Bitmap(bitmapTile,
                    (int)(250 * scale), (int)(250 * scale));
                tileImageSource = ConvertToIS(GenerateTile(bTileResized, color));
            }

            return tileImageSource;
        }

        public static byte[] ImageToByte(Bitmap bmp)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }

        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        public static ImageSource ConvertToIS(Bitmap bmp)
        {
            return ByteToImage(ImageToByte(bmp));
        }

        public static BitmapImage Convert(Bitmap bmp)
        {
            //TODO DESBONAL : tester le passage en array de bytes puis imagesource
            //Le memorystream peut être moisi;
            // Il peut être sage d'implémenter un Dictionary des Tile déjà créées, et de n'en générer de nouvelles qu'au besoin.
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
