using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using Controls.Library.Events;
using Controls.Library.Models;
using Controls.Library.ViewModels;
using MyToolkit.Messaging;
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
        //Models
        public TileEditorModel TileEditorModel;
        public HexMapModel HexMapModel;
        //Data
        public HexMapData HexMapData;
        public List<TileColor> ListTileColor;
        public List<TileImageType> ListTileImageType;
        //ViewModels
        public HexMapViewModel HexMapViewModel;
        public TileEditorViewModel TileEditorViewModel;

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
            TileEditorViewModel = new TileEditorViewModel();
            TileEditorViewModel.ApplyModel(TileEditorModel);
            TileEditorViewControl.ViewModel = TileEditorViewModel;

            //Generate the hex map
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(HexMapData));
                using (var sr = new StreamReader(Environment.CurrentDirectory + "\\garage.xml"))
                {
                    HexMapData = (HexMapData) xs.Deserialize(sr);
                }
            }
            catch (Exception)
            {
                HexMapData = HexMapData.GeneratHexMapData(ColCount, RowCount);
            }
            //HexMapData = HexMapData.GeneratHexMapData(ColCount, RowCount);
            HexMapModel = new HexMapModel(HexMapData, CombWidth, CombHeight, CellSize);
            HexMapViewModel = new HexMapViewModel();
            HexMapViewModel.ApplyModel(HexMapModel);
            HexMapViewControl.ViewModel = HexMapViewModel;

            // Subscribe to Events
            Messenger.Default.Register<HexClickedLeftButtonMessage>(this, HexClickedLeftButtonMessageFunction);
            Messenger.Default.Register<HexClickedRightButtonMessage>(this, HexClickedRightButtonMessageFunction);

            foreach (HexModel hexModel in HexMapModel.ListHexModel)
            {
                //hexModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HexModel_PropertyChanged);
            }

            TopMenuViewControl.DataContext = new TopMenuViewModel();
        }

        void HexModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            HexModel hexModel = (HexModel) sender;
            if (e.PropertyName == "TileColorModel" || e.PropertyName == "TileImageTypeModel")
            {
                var selectedHexViewModel = HexMapViewModel.GetHexViewModel(hexModel.Column, hexModel.Row);
                //selectedHexViewModel.UpdateTileData(hexModel.TileColorModel.GetDrawingColor(), hexModel.TileImageTypeModel.GetBitmap());
                selectedHexViewModel.UpdateFromHexModel(hexModel);
            }
        }

        private async void HexClickedLeftButtonMessageFunction(HexClickedLeftButtonMessage msgHexClickedLeftButtonMessage)
        {
            GetSelectedColorImageIdsRequestMessage msgGetSelectedColorImageNamesRequestMessage = new GetSelectedColorImageIdsRequestMessage();
            var resultGetSelectedColorImageNamesRequestMessage = await Messenger.Default.SendAsync(msgGetSelectedColorImageNamesRequestMessage);
            string tileColorModelId = resultGetSelectedColorImageNamesRequestMessage.Result.Item1;
            string tileImageTypeModelId = resultGetSelectedColorImageNamesRequestMessage.Result.Item2;

            GetTileColorTileImageTypeModelsFromIdRequestMessage msgGetTileColorTileImageTypeModelsFromNameRequestMessage = new GetTileColorTileImageTypeModelsFromIdRequestMessage
            {
                TileColorModelId = tileColorModelId,
                TileImageTypeModelId = tileImageTypeModelId
            };
            var resultGetTileColorTileImageTypeModelsFromNameRequestMessage = await Messenger.Default.SendAsync(msgGetTileColorTileImageTypeModelsFromNameRequestMessage);

            GetHexModelFromPositionRequestMessage msgGetHexModelFromPositionRequestMessage = new GetHexModelFromPositionRequestMessage
            {
                Column = msgHexClickedLeftButtonMessage.Column,
                Row = msgHexClickedLeftButtonMessage.Row
            };
            var resultGetHexModelFromPositionRequestMessage = await Messenger.Default.SendAsync(msgGetHexModelFromPositionRequestMessage);
            HexModel hexModel = resultGetHexModelFromPositionRequestMessage.Result;

            hexModel.TileColorModel =
                resultGetTileColorTileImageTypeModelsFromNameRequestMessage.Result.Item1;
            hexModel.TileImageTypeModel =
                resultGetTileColorTileImageTypeModelsFromNameRequestMessage.Result.Item2;

            //TODO : définir le flow de modification de la DATA
            var selectedHexData = HexMapData.GetHexData(msgHexClickedLeftButtonMessage.Column, msgHexClickedLeftButtonMessage.Row);
            selectedHexData.TileData.TileColor = ListTileColor.FirstOrDefault(x => x.Id == tileColorModelId);
            selectedHexData.TileData.TileImageType = ListTileImageType.FirstOrDefault(x => x.ToString() == tileImageTypeModelId);
        }

        private async void HexClickedRightButtonMessageFunction(HexClickedRightButtonMessage msgHexClickedRightButtonMessage)
        {
            GetHexModelFromPositionRequestMessage msgGetHexModelFromPositionRequestMessage = new GetHexModelFromPositionRequestMessage
            {
                Column = msgHexClickedRightButtonMessage.Column,
                Row = msgHexClickedRightButtonMessage.Row
            };
            var resultGetHexModelFromPositionRequestMessage = await Messenger.Default.SendAsync(msgGetHexModelFromPositionRequestMessage);
            HexModel hexModel = resultGetHexModelFromPositionRequestMessage.Result;

            SetSelectedColorImageIdsRequestMessage msgSetSelectedColorImageIdsRequestMessage = new SetSelectedColorImageIdsRequestMessage
            {
                TileColorModelId = hexModel.TileColorModel.Id,
                TileImageTypeModelId = hexModel.TileImageTypeModel.Id
            };
            Messenger.Default.Send(msgSetSelectedColorImageIdsRequestMessage);

            XmlSerializer xs = new XmlSerializer(typeof(HexMapData));
            TextWriter tw = new StreamWriter(Environment.CurrentDirectory+"\\garage.xml");
            xs.Serialize(tw, HexMapData);
        }
    }
}

// Create the Event Message
public class TickerSymbolSelectedMessage
{
    public string StockSymbol { get; set; }
}