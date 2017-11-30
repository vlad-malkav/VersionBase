using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VersionBase.Libraries;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;
using Color = System.Drawing.Color;
using FontFamily = System.Windows.Media.FontFamily;
using Point = System.Windows.Point;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: Honeycombs
//
// summary:	WPF implementation of Rosetta Code Honeycombs task.  Uses Polygon shapes as hexes.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace VersionBase
{
    public partial class MainWindow
    {
        private const int RowCount = 5;
        private const int ColCount = 5;
        private const int LabelSize = 20;
        private Dictionary<HexCoordinates, HexData> DictionaryHexData;
        private static int TileTypeCurrent = 0;
        private double CombHeight = 100;
        private double CombWidth = 100;
        private double CellSize = 100;

        public MainWindow()
        {
            DictionaryHexData = new Dictionary<HexCoordinates, HexData>();

            // VS Generated code not included
            InitializeComponent();
        }

        private void SetHexProperties(UIElementCollection hexes)
        {
            List<Polygon> hexList = hexes.Cast<Polygon>().ToList();

            foreach (Polygon element in hexList)
            {
                SetHexProperties(element);
            }
        }

        private void SetHexProperties(Polygon hex)
        {
            var tag = (HexCoordinates)hex.Tag;

            //Get the BaseHex
            HexData baseHex = DictionaryHexData[(HexCoordinates)hex.Tag];

            // We place the text in a grid centered on the hex.
            // The grid will then center the text within itself.

            var centeringGrid = new Grid();
            centeringGrid.Width = centeringGrid.Height = 2 * CellSize;
            centeringGrid.SetValue(Canvas.LeftProperty, baseHex.HexDrawingData.CellX - CellSize);
            centeringGrid.SetValue(Canvas.TopProperty, baseHex.HexDrawingData.CellY - CellSize);
            centeringGrid.IsHitTestVisible = false;
            HoneycombCanvas.Children.Add(centeringGrid);

            var label = new TextBlock
            {
                Text = "",//TODO
                FontFamily = new FontFamily("Segoe"),
                FontSize = LabelSize
            };
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.IsHitTestVisible = false;
            centeringGrid.Children.Add(label);

            hex.Fill = new ImageBrush(GenerateTileBitmapImage(TileSet.GetTile((TileType)TileTypeCurrent++)));
            hex.Stroke = new SolidColorBrush(Colors.Black);
            hex.StrokeThickness = CellSize / 10;
            baseHex.Text = "";//TODO

            // Mouse down event handler for the hex
            hex.MouseDown += hex_MouseDown;
        }

        #region Bitmap Functions

        private BitmapImage GenerateTileBitmapImage(Tile tile)
        {
            return GenerateTileBitmapImage(tile.GetBitmapTile(), tile.BaseColor);
        }

        private BitmapImage GenerateTileBitmapImage(Bitmap bitmapTile, Color color)
        {
            float scaleHeight = (float)2.5;
            float scaleWidth = (float)2.5;
            float scale = Math.Min(scaleHeight, scaleWidth);
            Bitmap bTileResized = new Bitmap(bitmapTile,
                (int)(bitmapTile.Width * scale), (int)(bitmapTile.Height * scale));
            BitmapImage tileBitmapImage = Convert(SuperimposeB(GenerateTile(bTileResized, color), bitmapTile));

            return tileBitmapImage;
        }

        private BitmapImage Convert(Bitmap bmp)
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

        public Bitmap SuperimposeB(Bitmap largeBmp, Bitmap smallBmp)
        {
            Graphics g = Graphics.FromImage(largeBmp);
            g.CompositingMode = CompositingMode.SourceOver;
            smallBmp.MakeTransparent();
            int margin = 5;
            int x = ((largeBmp.Width - smallBmp.Width) / 3)-20;
            int y = ((largeBmp.Height - smallBmp.Height) / 3)-20;
            g.DrawImage(smallBmp, new PointF(x, y));
            return largeBmp;
        }

        public Bitmap GenerateTile(Bitmap baseBitmap, System.Drawing.Color color)
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

        private void hex_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var hex = sender as Shape;
            if (hex == null)
            {
                throw new InvalidCastException("Non-shape in Honeycomb");
            }

            //Get the BaseHex
            HexData selectedHex = DictionaryHexData[(HexCoordinates) hex.Tag];

            if (DictionaryHexData.Count(x => x.Value.Selected) > 0)
            {
                var previouslySelectedHex = DictionaryHexData.First(x => x.Value.Selected).Value;
                if (previouslySelectedHex != selectedHex)
                {
                    previouslySelectedHex.Selected = !previouslySelectedHex.Selected;
                }
            }

            selectedHex.Selected = !selectedHex.Selected;

            // Get the text for this hex
            string ch = selectedHex.Text;

            //TODO
            /*if (baseHex.IsSelected())
            {
                // Add it to our Letters TextBlock
                Letters.Text = Letters.Text + ch;
            }
            else
            {
                Letters.Text = Letters.Text.Replace(ch,"");
            }*/

            // Color the hex
            //TODO
            //var color = baseHex.GetCurrentColor();
            //hex.Fill = new SolidColorBrush(color);

            // Remove the mouse down event handler so we won't hit on this hex again
            //hex.MouseDown -= hex_MouseDown;
        }

        private static void GetCombSize(double actualHeight, double actualWidth, int columns, int rows, out double cellSize, out double combWidth, out double combHeight)
        {
            double columnFactor = (3 * columns + 1) / 1.5;
            double rowFactor = (Math.Sqrt(3) * (2 * rows + 1)) / 1.5;
            double cellFromWidth = actualWidth / columnFactor;
            double cellFromHeight = actualHeight / rowFactor;
            cellSize = Math.Min(cellFromWidth, cellFromHeight);
            combWidth = cellSize * columnFactor;
            combHeight = cellSize * rowFactor;
        }

        private static Dictionary<HexCoordinates, HexData> GenerateDictionaryHexData(int columns, int rows, double cellSize)
        {
            Dictionary <HexCoordinates, HexData > dictionaryHexData = new Dictionary<HexCoordinates, HexData>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    HexData hexDataTmp = new HexData(new HexCoordinates(col, row), "-", TileType.badlands, cellSize);
                    dictionaryHexData.Add(hexDataTmp.HexCoordinates, hexDataTmp);
                }
            }
            return dictionaryHexData;
        }

        private static void AddHexToCanvas(Canvas canvas, Dictionary<HexCoordinates, HexData> dictionaryHexData, double cellSize)
        {
            foreach (KeyValuePair<HexCoordinates, HexData> kvpHexData in dictionaryHexData)
            {
                canvas.Children.Add(kvpHexData.Value.GenerateHex(cellSize));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            // Get sizes that will fit within our window
            GetCombSize(Main.ActualHeight, Main.ActualWidth, ColCount, RowCount, out CellSize, out CombWidth, out CombHeight);

            // Set the canvas size appropriately
            HoneycombCanvas.Width = CombWidth;
            HoneycombCanvas.Height = CombHeight;

            //Generate the hex map
            DictionaryHexData = GenerateDictionaryHexData(ColCount, RowCount, CellSize);

            // Add the cells to the canvas
            AddHexToCanvas(HoneycombCanvas, DictionaryHexData, CellSize);

            // Set the cells to look like we want them
            SetHexProperties(HoneycombCanvas.Children);
        }

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            /*VersionBase.ViewModel.StudentViewModel studentViewModelObject =
                new VersionBase.ViewModel.StudentViewModel();
            studentViewModelObject.LoadStudents();

            StudentViewControl.DataContext = studentViewModelObject;*/
        }
    }
}