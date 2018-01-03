using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;
using VersionBase.Libraries.Drawing;

namespace Controls.Library.ViewModels
{
    public class HexMapViewModel : ViewModelBase
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public double HexMapCenterX { get; set; }
        public double HexMapCenterY { get; set; }
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

        public async void ApplyModel(HexMapModel hexMapModel)
        {
            GetHexMapCanvasDimensionsRequestMessage msg = new GetHexMapCanvasDimensionsRequestMessage();
            var result = await Messenger.Default.SendAsync(msg);
            double hexMapCanvasWidth = result.Result.Item1;
            double hexMapCanvasHeight = result.Result.Item2;

            double cellSize = HexMapDrawing.GetCellSize(hexMapCanvasHeight, hexMapCanvasWidth, hexMapModel.Columns, hexMapModel.Rows);
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
                hexViewModel.UpdateFromHexModel(hexModel, CellSize);
                ListHexViewModel.Add(hexViewModel);
                foreach (UIElement uiElement in hexViewModel.GetAllUIElements())
                {
                    ListUIElement.Add(uiElement);
                }
            }

            HexMapCenterX = HexMapDrawing.GetRedrawnHexMapXCenter(CellSize, Columns);
            HexMapCenterY = HexMapDrawing.GetRedrawnHexMapYCenter(CellSize, Columns, Rows);

            CenterHexMap();
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

        public async void CenterHexMap()
        {
            GetHexMapCanvasDimensionsRequestMessage msg = new GetHexMapCanvasDimensionsRequestMessage();
            var result = await Messenger.Default.SendAsync(msg);
            double hexMapCanvasWidth = result.Result.Item1;
            double hexMapCanvasHeight = result.Result.Item2;
            
            double xCenterNew = (hexMapCanvasWidth / 2);
            double yCenterNew = (hexMapCanvasHeight / 2);
            double xCenterMod = xCenterNew - HexMapCenterX;
            double yCenterMod = yCenterNew - HexMapCenterY;

            MoveCanvas(xCenterMod, yCenterMod);
            HexMapCenterX = xCenterNew;
            HexMapCenterY = yCenterNew;
        }

        public async void ZoomCanvas(double zoomMultiplicator)
        {
            double oldCenterX = HexMapCenterX;
            double oldCenterY = HexMapCenterY;

            GetHexMapCanvasDimensionsRequestMessage msg = new GetHexMapCanvasDimensionsRequestMessage();
            var result = await Messenger.Default.SendAsync(msg);
            double oldHexMapCanvasWidth = result.Result.Item1;
            double oldHexMapCanvasHeight = result.Result.Item2;
            double oldHexMapCanvasX = oldHexMapCanvasWidth / 2;
            double oldHexMapCanvasY = oldHexMapCanvasHeight / 2;

            double xMove = oldCenterX - oldHexMapCanvasX;
            double yMove = oldCenterY - oldHexMapCanvasY;

            CellSize = CellSize * zoomMultiplicator;

            foreach (var hexViewModel in ListHexViewModel)
            {
                hexViewModel.UpdateCellSize(CellSize);
            }

            HexMapCenterX = HexMapDrawing.GetRedrawnHexMapXCenter(CellSize, Columns);
            HexMapCenterY = HexMapDrawing.GetRedrawnHexMapYCenter(CellSize, Columns, Rows);

            CenterHexMap();

            MoveCanvas(xMove * zoomMultiplicator, yMove * zoomMultiplicator);
        }

        public void MoveCanvas(double xMovement, double yMovement)
        {
            HexMapCenterX += xMovement;
            HexMapCenterY += yMovement;
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
            Messenger.Default.Deregister<GeneralMapTransformationMessage>(this, GeneralMapTransformationMessageFunction);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<HexTileUpdatedMessage>(this, HexTileUpdatedMessageFunction);
            Messenger.Default.Register<HexDegreExplorationUpdatedMessage>(this, HexDegreExplorationUpdatedMessageFunction);
            Messenger.Default.Register<HexModelSelectedMessage>(this, HexSelectedMessageFunction);
            Messenger.Default.Register<HexModelUnselectedMessage>(this, HexUnselectedMessageFunction);
            Messenger.Default.Register<GeneralMapTransformationMessage>(this, GeneralMapTransformationMessageFunction);
            Messenger.Default.Register<GeneralMapTransformationMessage>(this, GeneralMapTransformationMessageFunction);
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

        private void GeneralMapTransformationMessageFunction(GeneralMapTransformationMessage msg)
        {
            if (Math.Abs(msg.XMovement) > 0 || Math.Abs(msg.YMovement) > 0)
            {
                MoveCanvas(msg.XMovement, msg.YMovement);
            }
            if (Math.Abs(msg.ZoomMultiplicator) > 0)
            {
                ZoomCanvas(msg.ZoomMultiplicator);
            }
            if (msg.DoCenter)
            {
                CenterHexMap();
            }
        }

        #endregion Event Functions
    }
}