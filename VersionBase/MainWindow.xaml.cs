using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using Controls.Library.Events;
using Controls.Library.Models;
using Controls.Library.ViewModels;
using VersionBase.Libraries.Events;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

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
        //Data
        public HexMapData HexMapData;
        public List<TileColor> ListTileColor;
        public List<TileImageType> ListTileImageType;

        public MainWindow()
        {
            // VS Generated code not included
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get sizes that will fit within our window
            HexMapDrawing.GetCombSize(Main.ActualHeight, Main.ActualWidth, ColCount, RowCount, out CellSize, out CombWidth, out CombHeight);
            
            ListTileColor = TileColors.GetAllTileColors();
            ListTileImageType = TileImageTypes.GetAllTileImageTypes();
            TileEditorModel = new TileEditorModel(ListTileColor, ListTileImageType);
            TileEditorViewModel = new TileEditorViewModel(TileEditorModel);
            TileEditorViewControl.DataContext = TileEditorViewModel;

            //Generate the hex map
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(HexMapData));
                using (var sr = new StreamReader(@"c:\temp\garage.xml"))
                {
                    HexMapData = (HexMapData) xs.Deserialize(sr);
                }
            }
            catch (Exception)
            {
                HexMapData = HexMapData.GeneratHexMapData(ColCount, RowCount);
            }
            HexMapModel = new HexMapModel(HexMapData, CombWidth, CombHeight, CellSize);
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

            var selectedHexData = HexMapData.GetHexData(msg.Column, msg.Row);
            selectedHexData.TileData.TileColor = ListTileColor.FirstOrDefault(x => x.Name == selectedTileColorModel.Name);
            selectedHexData.TileData.TileImageType = ListTileImageType.FirstOrDefault(x => x.ToString() == selectedTileTypeModel.NameLower);
        }

        private void HexClickedRightButtonMessageFunction(HexClickedRightButtonMessage msg)
        {
            var selectedHexViewModel = HexMapViewModel.GetHexViewModel(msg.Column, msg.Row);

            var selectedHexModel = HexMapModel.GetHexModel(selectedHexViewModel.Column, selectedHexViewModel.Row);

            TileEditorViewModel.SelectedTileColorViewModel =
                TileEditorViewModel.GetTileColorViewModel(selectedHexModel.TileColorModel.Name);
            TileEditorViewModel.SelectedTileImageTypeViewModel =
                TileEditorViewModel.GetTileImageTypeViewModel(selectedHexModel.TileImageTypeModel.Name);

            XmlSerializer xs = new XmlSerializer(typeof(HexMapData));
            TextWriter tw = new StreamWriter(@"c:\temp\garage.xml");
            xs.Serialize(tw, HexMapData);
        }
    }
}

// Create the Event Message
public class TickerSymbolSelectedMessage
{
    public string StockSymbol { get; set; }
}