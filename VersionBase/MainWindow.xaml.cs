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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controls.Library.Events;
using Controls.Library.Models;
using Controls.Library.ViewModels;
using VersionBase.Libraries.Events;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;
using Color = System.Drawing.Color;
using FontFamily = System.Windows.Media.FontFamily;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: Honeycombs
//
// summary:	WPF implementation of Rosetta Code Honeycombs task.  Uses Polygon shapes as hexes.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace VersionBase
{
    public partial class MainWindow
    {
        private const int RowCount = 10;
        private const int ColCount = 10;
        private List<HexModel> ListHexModel { get; set; }
        private static int TileTypeCurrent = 0;
        private double CombHeight = 100;
        private double CombWidth = 100;
        private double CellSize = 100;

        public MainWindow()
        {
            ListHexModel = new List<HexModel>();

            // VS Generated code not included
            InitializeComponent();
        }

        private void SetListPolygonActions(UIElementCollection polygons)
        {
            List<Polygon> hexList = polygons.Cast<Polygon>().ToList();

            foreach (Polygon element in hexList)
            {
                SetPolygonActions(element);
            }
        }

        private void SetPolygonActions(Polygon polygon)
        {
            // Mouse down event handler for the hex
            polygon.MouseRightButtonDown += hex_MouseRightButtonDown;
            polygon.MouseLeftButtonDown += hex_MouseLeftButtonDown;

            // Subscribe to Events
            EventSystem.Subscribe<TickerSymbolSelectedMessage>(TestEvent);
        }

        private void hex_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var hex = sender as Shape;
            if (hex == null)
            {
                throw new InvalidCastException("Non-shape in Honeycomb");
            }
        }

        private void TestEvent(TickerSymbolSelectedMessage msg)
        {
            
        }

        private void hex_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            EventSystem.Publish<TickerSymbolSelectedMessage>(
                new TickerSymbolSelectedMessage { StockSymbol = "STOCK0"});

            var hex = sender as Shape;
            if (hex == null)
            {
                throw new InvalidCastException("Non-shape in Honeycomb");
            }

            TileColorViewModel tileColorViewModel = (TileColorViewModel)TileColorViewControl.DataContext;
            TileImageTypeViewModel TileImageTypeViewModel = (TileImageTypeViewModel)TileImageTypeViewControl.DataContext;

            TileColorModel selectedTileColor = tileColorViewModel.SelectedTileColor;
            TileImageTypeModel selectedTileType = TileImageTypeViewModel.SelectedTileType;

            //Get the BaseHex
            HexModel selectedHexModel = ListHexModel.First(x => x.Polygon == hex);

            if (ListHexModel.Count(x => x.HexData.Selected) > 0)
            {
                var previouslySelectedHexModel = ListHexModel.First(x => x.HexData.Selected);
                if (previouslySelectedHexModel != selectedHexModel)
                {
                    previouslySelectedHexModel.HexData.Selected = !previouslySelectedHexModel.HexData.Selected;
                }
            }

            selectedHexModel.HexData.Selected = !selectedHexModel.HexData.Selected;

            selectedHexModel.HexData.TileData.TileColor = selectedTileColor.TileColor;
            selectedHexModel.HexData.TileData.TileImageType = selectedTileType.TileImageType;

            HexMapDrawing.UpdateHex(selectedHexModel.Polygon, selectedHexModel.HexDrawingData, selectedHexModel.HexData.TileData);
        }

        public static List<HexModel> GenerateListHexModel(int columns, int rows, double cellSize)
        {
            List <HexModel> listHexModel = new List<HexModel>();

            List<TileImageType> listTileImageType = TileImageTypes.GetAllTileImageTypes();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    TileData tileData = new TileData(new TileColor(Color.LightGreen), listTileImageType[TileTypeCurrent++ % listTileImageType.Count]);
                    HexData hexDataTmp = new HexData(new HexCoordinates(col, row), "-", tileData, cellSize);
                    listHexModel.Add(new HexModel(hexDataTmp, cellSize));
                }
            }
            return listHexModel;
        }

        private static void AddHexModelToCanvas(Canvas canvas, List<HexModel> listHexModel, double cellSize)
        {
            foreach (HexModel hexModel in listHexModel)
            {
                canvas.Children.Add(hexModel.Polygon);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get sizes that will fit within our window
            HexMapDrawing.GetCombSize(Main.ActualHeight, Main.ActualWidth, ColCount, RowCount, out CellSize, out CombWidth, out CombHeight);

            // Set the canvas size appropriately
            HoneycombCanvas.Width = CombWidth;
            HoneycombCanvas.Height = CombHeight;

            //Generate the hex map
            ListHexModel = GenerateListHexModel(ColCount, RowCount, CellSize);

            // Add the cells to the canvas
            AddHexModelToCanvas(HoneycombCanvas, ListHexModel, CellSize);

            // Set the cells to look like we want them
            SetListPolygonActions(HoneycombCanvas.Children);

            // Subscribe to Events
            EventSystem.Subscribe<HexClickedLeftButtonMessage>(HexClickedLeftButtonMessageFunction);
            EventSystem.Subscribe<HexClickedRightButtonMessage>(HexClickedRightButtonMessageFunction);
        }

        private void HexClickedLeftButtonMessageFunction(HexClickedLeftButtonMessage msg)
        {
            TileColorViewModel tileColorViewModel = (TileColorViewModel)TileColorViewControl.DataContext;
            TileImageTypeViewModel TileImageTypeViewModel = (TileImageTypeViewModel)TileImageTypeViewControl.DataContext;

            TileColorModel selectedTileColor = tileColorViewModel.SelectedTileColor;
            TileImageTypeModel selectedTileType = TileImageTypeViewModel.SelectedTileType;

            msg.HexModel.HexData.TileData.TileColor = selectedTileColor.TileColor;
            msg.HexModel.HexData.TileData.TileImageType = selectedTileType.TileImageType;

            HexMapDrawing.UpdateHex(msg.HexModel.Polygon, msg.HexModel.HexDrawingData, msg.HexModel.HexData.TileData);
        }

        private void HexClickedRightButtonMessageFunction(HexClickedRightButtonMessage msg)
        {

        }
    }
}

// Create the Event Message
public class TickerSymbolSelectedMessage
{
    public string StockSymbol { get; set; }
}