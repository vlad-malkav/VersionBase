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
        public static void UpdateAndFillHexShapes(
            Polygon insidePolygon, Polygon borderPolygon,
            Grid gridLabel, List<Line> listLineExploration,
            int column, int row,
            double xCenterMod, double yCenterMod, double cellSize,
            Color color, Bitmap bitmap,
            string label, int degreExploration, bool selected)
        {
            HexDrawingData hexDrawingData = new HexDrawingData(column, row, xCenterMod, yCenterMod, cellSize);
            DrawInsidePolygon(hexDrawingData, insidePolygon);
            FillInsidePolygon(insidePolygon, color, bitmap);
            UpdateBorderPolygon(hexDrawingData, borderPolygon, selected);
            UpdateHexLabel(hexDrawingData, gridLabel, label);
            UpdateAndFillHexLineExploration(hexDrawingData, listLineExploration, degreExploration);
        }

        public static void DrawInsidePolygon(HexDrawingData hexDrawingData, Polygon insidePolygon)
        {
            insidePolygon.Points.Clear();
            foreach (var outerSummitPoint in hexDrawingData.ListOuterSummitPoints)
            {
                insidePolygon.Points.Add(outerSummitPoint);
            }
            insidePolygon.Tag = "InsidePolygon";
            Canvas.SetZIndex(insidePolygon, 0);
        }

        public static void FillInsidePolygon(Polygon insidePolygon, Color color, Bitmap bitmap)
        {
            insidePolygon.Fill = new ImageBrush(GenerateTileBitmapImage(color, bitmap));
        }

        public static void UpdateBorderPolygon(HexDrawingData hexDrawingData, Polygon borderPolygon, bool selected)
        {
            borderPolygon.Points.Clear();
            foreach (var outerSummitPoint in hexDrawingData.ListOuterSummitPoints)
            {
                borderPolygon.Points.Add(outerSummitPoint);
            }
            
            borderPolygon.Stroke = new SolidColorBrush(selected ? Colors.DarkOrange : Colors.Black);
            borderPolygon.StrokeThickness = hexDrawingData.CellSize / (selected ? 5 : 10);
            borderPolygon.Tag = "BorderPolygon";
            Canvas.SetZIndex(borderPolygon, selected ? 100 : 10);
        }

        public static void UpdateHexLabel(HexDrawingData hexDrawingData, Grid gridLabel, string label)
        {
            gridLabel.Width = gridLabel.Height = (2 * hexDrawingData.CellSize) * 0.8;
            gridLabel.SetValue(Canvas.LeftProperty, hexDrawingData.CellX - hexDrawingData.CellSize * 0.8);
            gridLabel.SetValue(Canvas.TopProperty, hexDrawingData.CellY - hexDrawingData.CellSize * 0.8);
            gridLabel.IsHitTestVisible = false;

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
            gridLabel.Tag = "Label";
        }

        public static void UpdateAndFillHexLineExploration(HexDrawingData hexDrawingData, List<Line> listLineExploration, int degreExploration)
        {
            if (listLineExploration.Count != 6) return;

            for (int i = 0; i < 6; i++)
            {
                listLineExploration[i].X1 = hexDrawingData.ListOuterSummitPoints[i].X;
                listLineExploration[i].Y1 = hexDrawingData.ListOuterSummitPoints[i].Y;
                listLineExploration[i].X2 = hexDrawingData.ListInnerSummitPoints[i].X;
                listLineExploration[i].Y2 = hexDrawingData.ListInnerSummitPoints[i].Y;
                listLineExploration[i].Tag = "Line";
                listLineExploration[i].Stroke = new SolidColorBrush(Colors.Gold);
                listLineExploration[i].StrokeThickness = hexDrawingData.CellSize / 8;
                listLineExploration[i].Visibility = i >= degreExploration ? Visibility.Hidden : Visibility.Visible;
                Canvas.SetZIndex(listLineExploration[i], 2);
            }
        }

        public static void GetCombSize(double actualHeight, double actualWidth, int columns, int rows, out double cellSize, out double combWidth, out double combHeight)
        {
            double columnFactor = (3 * columns + 1) / 1.5;
            //DESBONAL : fullscreen
            //columnFactor = (0.5 + 1.5 * columns);
            double rowFactor = (Math.Sqrt(3) * (2 * rows + 1)) / 1.5;
            //DESBONAL : fullscreen
            //rowFactor = (Math.Sqrt(3) * (2 * rows + 1)) / 2;
            double cellFromWidth = actualWidth / columnFactor;
            double cellFromHeight = actualHeight / rowFactor;
            cellSize = Math.Min(cellFromWidth, cellFromHeight);
            combWidth = cellSize * columnFactor;
            combHeight = cellSize * rowFactor;
        }

        public static double GetTrueWidth(double cellSize, int columns)
        {
            return cellSize + Math.Max(0, columns - 1) * 1.5 * cellSize;
        }

        public static double GetTrueHeight(double cellSize, int columns, int rows)
        {
            double cellHeight = HexDrawingData.GetCellHeight(cellSize);
            return rows * cellHeight + columns > 1 ? cellHeight : 0;
        }

        public static double GetTrueXCenter(double cellSize, int columns)
        {
            return HexDrawingData.GetCellX(cellSize, 0, 0) - cellSize + GetTrueWidth(cellSize, columns) / 2;
        }

        public static double GetTrueYCenter(double cellSize, int columns, int rows)
        {
            return HexDrawingData.GetCellY(cellSize, 0, 0, 0) - HexDrawingData.GetCellHeight(cellSize) + GetTrueHeight(cellSize, columns, rows) / 2;
        }

        #region Bitmap Functions

        public static BitmapImage GenerateTileBitmapImage(TileData tileData)
        {
            return GenerateTileBitmapImage(
                tileData.TileColor.GetDrawingColor(),
                tileData.TileImageType != null ? TileImageTypes.GetBitmapTile(tileData.TileImageType.ToString()) : null);
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
