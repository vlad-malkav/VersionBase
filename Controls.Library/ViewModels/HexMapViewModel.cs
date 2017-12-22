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
        //public double Width { get; set; }
        //public double Height { get; set; }

        public HexMapViewModel()
        {
            UnregisterMessages();
            ListHexViewModel = new List<HexViewModel>();
            ListUIElement = new ObservableCollection<UIElement>();
            RegisterMessages();
        }

        public void ApplyModel(HexMapModel hexMapModel, double width, double height, double xCenterMod, double yCenterMod, double cellSize)
        {
            //Width = width;
            //Height = height;
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
                hexViewModel.UpdateDrawingDimensions(XCenterMod, YCenterMod,CellSize);
                ListHexViewModel.Add(hexViewModel);
                foreach (UIElement uiElement in hexViewModel.GetAllUIElements())
                {
                    ListUIElement.Add(uiElement);
                }
            }

        }

        private void UnregisterMessages()
        {
            Messenger.Default.Deregister<HexTileUpdatedMessage>(this, HexTileUpdatedMessageFunction);
            Messenger.Default.Deregister<HexDegreExplorationUpdatedMessage>(this, HexDegreExplorationUpdatedMessageFunction);
            Messenger.Default.Deregister<HexModelSelectedMessage>(this, HexSelectedMessageFunction);
            Messenger.Default.Deregister<HexModelUnselectedMessage>(this, HexUnselectedMessageFunction);
            Messenger.Default.Deregister<MoveCanvasRequestMessage>(this, MoveCanvasRequestMessageFunction);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<HexTileUpdatedMessage>(this, HexTileUpdatedMessageFunction);
            Messenger.Default.Register<HexDegreExplorationUpdatedMessage>(this, HexDegreExplorationUpdatedMessageFunction);
            Messenger.Default.Register<HexModelSelectedMessage>(this, HexSelectedMessageFunction);
            Messenger.Default.Register<HexModelUnselectedMessage>(this, HexUnselectedMessageFunction);
            Messenger.Default.Register<MoveCanvasRequestMessage>(this, MoveCanvasRequestMessageFunction);
        }

        private void HexTileUpdatedMessageFunction(HexTileUpdatedMessage msg)
        {
            var hexViewModel = GetHexViewModel(msg.HexModel.Column, msg.HexModel.Row);
            if (hexViewModel != null)
                hexViewModel.UpdateTileData(
                    msg.HexModel.TileColorModel.GetDrawingColor(),
                    msg.HexModel.TileImageTypeModel.GetBitmap());
        }

        private void HexDegreExplorationUpdatedMessageFunction(HexDegreExplorationUpdatedMessage msg)
        {
            var hexViewModel = GetHexViewModel(msg.HexModel.Column, msg.HexModel.Row);
            if (hexViewModel != null)
                hexViewModel.UpdateDegreExploration(msg.HexModel.DegreExploration);
        }

        private void HexSelectedMessageFunction(HexModelSelectedMessage msg)
        {
            var hexViewModel = GetHexViewModel(msg.HexModel.Column, msg.HexModel.Row);
            if (hexViewModel != null)
                hexViewModel.SelectHex();
        }

        private void HexUnselectedMessageFunction(HexModelUnselectedMessage msg)
        {
            var hexViewModel = GetHexViewModel(msg.HexModel.Column, msg.HexModel.Row);
            if (hexViewModel != null)
                hexViewModel.UnselectHex();
        }

        private void MoveCanvasRequestMessageFunction(MoveCanvasRequestMessage msg)
        {
            foreach (var hexViewModel in ListHexViewModel)
            {
                hexViewModel.Move(msg.XMovement, msg.YMovement);
            }
        }

        public HexViewModel GetHexViewModel(int column, int row)
        {
            return ListHexViewModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }
    }
}