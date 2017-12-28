using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class HexMapViewModel : ViewModelBase
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public double XCenterMod { get; set; }
        public double YCenterMod { get; set; }
        public double CellSize { get; set; }
        public List<HexViewModel> ListHexViewModel { get; set; }
        public ObservableCollection<UIElement> ListUIElement { get; set; }

        #region base functions

        public HexMapViewModel()
        {
            UnregisterMessages();
            ListHexViewModel = new List<HexViewModel>();
            ListUIElement = new ObservableCollection<UIElement>();
            RegisterMessages();
        }

        public void ApplyModel(HexMapModel hexMapModel, double xCenterMod, double yCenterMod, double cellSize)
        {
            XCenterMod = xCenterMod;
            YCenterMod = yCenterMod;
            CellSize = cellSize;
            Columns = hexMapModel.Columns;
            Rows = hexMapModel.Rows;
            foreach (var hexViewModel in ListHexViewModel)
            {
                hexViewModel.UnsubscribePolygonEvents();
            }
            ListHexViewModel.Clear();
            ListUIElement.Clear();
            foreach (var hexModel in hexMapModel.ListHexModel)
            {
                var hexViewModel = new HexViewModel();
                hexViewModel.UpdateFromHexModel(hexModel);
                hexViewModel.UpdateDrawingDimensions(0, 0, CellSize);
                ListHexViewModel.Add(hexViewModel);
                foreach (UIElement uiElement in hexViewModel.GetAllUIElements())
                {
                    ListUIElement.Add(uiElement);
                }
            }
            MoveCanvas(XCenterMod, YCenterMod);
        }

        #endregion base functions

        #region Utility Functions

        public HexViewModel GetHexViewModel(int column, int row)
        {
            return ListHexViewModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }

        #endregion Utility Functions

        public void UpdateHexViewModelFromModel_TileData(HexModel hexModel)
        {
            var hexViewModel = GetHexViewModel(hexModel.Column, hexModel.Row);
            if (hexViewModel != null)
                hexViewModel.UpdateTileData(
                    hexModel.TileColorModel.GetDrawingColor(),
                    hexModel.TileImageModel.Bitmap);
        }

        public void UpdateHexViewModelFromModel_DegreExploration(HexModel hexModel)
        {
            var hexViewModel = GetHexViewModel(hexModel.Column, hexModel.Row);
            if (hexViewModel != null)
                hexViewModel.UpdateDegreExploration(hexModel.DegreExploration);
        }

        public void UpdateHexViewModelFromModel_SelectHex(HexModel hexModel)
        {
            var hexViewModel = GetHexViewModel(hexModel.Column, hexModel.Row);
            if (hexViewModel != null)
                hexViewModel.SelectHex();
        }

        public void UpdateHexViewModelFromModel_UnselectHex(HexModel hexModel)
        {
            var hexViewModel = GetHexViewModel(hexModel.Column, hexModel.Row);
            if (hexViewModel != null)
                hexViewModel.UnselectHex();
        }

        public void ZoomCanvas(double zoomMultiplicator)
        {
            XCenterMod *= zoomMultiplicator;
            YCenterMod *= zoomMultiplicator;
            foreach (var hexViewModel in ListHexViewModel)
            {
                hexViewModel.Zoom(zoomMultiplicator);
            }
            MoveCanvas(XCenterMod, YCenterMod);
        }

        public void MoveCanvas(double xMovement, double yMovement)
        {
            XCenterMod += xMovement;
            YCenterMod += yMovement;
            foreach (var hexViewModel in ListHexViewModel)
            {
                hexViewModel.Move(xMovement, yMovement);
            }
        }

        #region Event Functions

        private void UnregisterMessages()
        {
            Messenger.Default.Deregister<HexTileUpdatedMessage>(this, HexTileUpdatedMessageFunction);
            Messenger.Default.Deregister<HexDegreExplorationUpdatedMessage>(this, HexDegreExplorationUpdatedMessageFunction);
            Messenger.Default.Deregister<HexModelSelectedMessage>(this, HexSelectedMessageFunction);
            Messenger.Default.Deregister<HexModelUnselectedMessage>(this, HexUnselectedMessageFunction);
            Messenger.Default.Deregister<MoveCanvasRequestMessage>(this, MoveCanvasRequestMessageFunction);
            Messenger.Default.Deregister<ZoomCanvasRequestMessage>(this, ZoomCanvasRequestMessageFunction);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<HexTileUpdatedMessage>(this, HexTileUpdatedMessageFunction);
            Messenger.Default.Register<HexDegreExplorationUpdatedMessage>(this, HexDegreExplorationUpdatedMessageFunction);
            Messenger.Default.Register<HexModelSelectedMessage>(this, HexSelectedMessageFunction);
            Messenger.Default.Register<HexModelUnselectedMessage>(this, HexUnselectedMessageFunction);
            Messenger.Default.Register<MoveCanvasRequestMessage>(this, MoveCanvasRequestMessageFunction);
            Messenger.Default.Register<ZoomCanvasRequestMessage>(this, ZoomCanvasRequestMessageFunction);
        }

        private void HexTileUpdatedMessageFunction(HexTileUpdatedMessage msg)
        {
            UpdateHexViewModelFromModel_TileData(msg.HexModel);
        }

        private void HexDegreExplorationUpdatedMessageFunction(HexDegreExplorationUpdatedMessage msg)
        {
            UpdateHexViewModelFromModel_DegreExploration(msg.HexModel);
        }

        private void HexSelectedMessageFunction(HexModelSelectedMessage msg)
        {
            UpdateHexViewModelFromModel_SelectHex(msg.HexModel);
        }

        private void HexUnselectedMessageFunction(HexModelUnselectedMessage msg)
        {
            UpdateHexViewModelFromModel_UnselectHex(msg.HexModel);
        }

        private void MoveCanvasRequestMessageFunction(MoveCanvasRequestMessage msg)
        {
            MoveCanvas(msg.XMovement, msg.YMovement);
        }

        private void ZoomCanvasRequestMessageFunction(ZoomCanvasRequestMessage msg)
        {
            ZoomCanvas(msg.ZoomMultiplicator);
        }

        #endregion Event Functions
    }
}