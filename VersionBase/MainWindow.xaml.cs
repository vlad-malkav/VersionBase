using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controls.Library.Events;
using Controls.Library.Models;
using Controls.Library.ViewModels;
using Controls.Library.Views;
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
        private static int TileTypeCurrent = 0;
        private double CombHeight = 100;
        private double CombWidth = 100;
        private double CellSize = 100;
        private HexModel SelectedHex;
        //ViewModels
        public TileEditorViewModel TileEditorViewModel;
        public HexMapViewModel HexMapViewModel;
        //Models
        public TileEditorModel TileEditorModel;
        public HexMapModel HexMapModel;

        public MainWindow()
        {
            // VS Generated code not included
            InitializeComponent();
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
                    HexData hexDataTmp = new HexData(col, row, "-", tileData, cellSize);
                    listHexModel.Add(new HexModel(hexDataTmp));
                }
            }
            return listHexModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get sizes that will fit within our window
            HexMapDrawing.GetCombSize(Main.ActualHeight, Main.ActualWidth, ColCount, RowCount, out CellSize, out CombWidth, out CombHeight);
            
            List<TileColor> listTileColor = TileColors.GetAllTileColors();
            List<TileImageType> listTileImageType = TileImageTypes.GetAllTileImageTypes();
            TileEditorModel = new TileEditorModel(listTileColor, listTileImageType);
            TileEditorViewModel = new TileEditorViewModel(TileEditorModel);
            TileEditorViewControl.DataContext = TileEditorViewModel;

            //Generate the hex map
            var listHexModel = HexMapViewModel.GenerateListHexModel(RowCount, ColCount, CellSize);
            HexMapModel = new HexMapModel(listHexModel, CombWidth, CombHeight, CellSize, RowCount, ColCount);
            HexMapViewModel = new HexMapViewModel(HexMapModel);
            HexMapViewControl.DataContext = HexMapViewModel;

            // Subscribe to Events
            EventSystem.Subscribe<HexClickedLeftButtonMessage>(HexClickedLeftButtonMessageFunction);
            EventSystem.Subscribe<HexClickedRightButtonMessage>(HexClickedRightButtonMessageFunction);

            foreach (HexModel hexModel in HexMapModel.ListHexModel)
            {
                hexModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HexModel_PropertyChanged);
            }
        }

        void HexModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            HexModel hexModel = (HexModel) sender;
            if (e.PropertyName == "TileColorModel" || e.PropertyName == "TileImageTypeModel")
            {
                var selectedHexViewModel = HexMapViewModel.GetHexViewModel(hexModel.Column, hexModel.Row);
                selectedHexViewModel.UpdateTileData(hexModel.TileColorModel.GetDrawingColor(), hexModel.TileImageTypeModel.GetBitmap());
            }
        }

        private void HexClickedLeftButtonMessageFunction(HexClickedLeftButtonMessage msg)
        {
            var selectedTileColorModel = TileEditorModel.GetTileColorModel(TileEditorViewModel.SelectedTileColorViewModel.Name);
            var selectedTileTypeModel = TileEditorModel.GetTileImageTypeModel(TileEditorViewModel.SelectedTileImageTypeViewModel.Name);

            var selectedHexViewModel = HexMapViewModel.GetHexViewModel(msg.Column, msg.Row);

            var selectedHexModel = HexMapModel.GetHexModel(selectedHexViewModel.Column, selectedHexViewModel.Row);

            selectedHexModel.TileColorModel = selectedTileColorModel;
            selectedHexModel.TileImageTypeModel = selectedTileTypeModel;
        }

        private void HexClickedRightButtonMessageFunction(HexClickedRightButtonMessage msg)
        {
            var selectedHexViewModel = HexMapViewModel.GetHexViewModel(msg.Column, msg.Row);

            var selectedHexModel = HexMapModel.GetHexModel(selectedHexViewModel.Column, selectedHexViewModel.Row);

            TileEditorViewModel.SelectedTileColorViewModel =
                TileEditorViewModel.GetTileColorViewModel(selectedHexModel.TileColorModel.Name);
            TileEditorViewModel.SelectedTileImageTypeViewModel =
                TileEditorViewModel.GetTileImageTypeViewModel(selectedHexModel.TileImageTypeModel.Name);
        }
    }
}

// Create the Event Message
public class TickerSymbolSelectedMessage
{
    public string StockSymbol { get; set; }
}