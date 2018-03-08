using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using VersionBase.Events;
using VersionBase.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;
using VersionBase.Forms;
using VersionBase.Libraries.Drawing;

namespace VersionBase.ViewModels
{
    public class HexMapViewModel : AbstractViewModel<HexMapModel>
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public double HexMapCenterX { get; set; }
        public double HexMapCenterY { get; set; }
        public double CellRadius { get; set; }
        public List<HexViewModel> ListHexViewModel { get; set; }
        public List<CommunityViewModel> ListCommunityViewModel { get; set; }
        public ObservableCollection<UIElement> ListUIElement { get; set; }

        #region base functions

        public HexMapViewModel()
        {
            UnregisterMessages();
            ListHexViewModel = new List<HexViewModel>();
            ListUIElement = new ObservableCollection<UIElement>();
            ListCommunityViewModel = new List<CommunityViewModel>();
            RegisterMessages();
        }

        public override async void ApplyModel(HexMapModel hexMapModel)
        {
            GetHexMapCanvasDimensionsRequestMessage msg = new GetHexMapCanvasDimensionsRequestMessage();
            var result = await Messenger.Default.SendAsync(msg);
            double hexMapCanvasWidth = result.Result.Item1;
            double hexMapCanvasHeight = result.Result.Item2;

            double cellRadius = HexMapDrawingHelper.GetCellRadius(hexMapCanvasHeight, hexMapCanvasWidth, hexMapModel.Columns, hexMapModel.Rows);
            CellRadius = cellRadius;
            Columns = hexMapModel.Columns;
            Rows = hexMapModel.Rows;
            foreach (var hexViewModel in ListHexViewModel)
            {
                hexViewModel.UnsubscribePolygonEvents();
            }
            ListHexViewModel.Clear();
            ListUIElement.Clear();
            ListCommunityViewModel.Clear();
            foreach (var hexModel in hexMapModel.ListHexModel)
            {
                var hexViewModel = new HexViewModel();
                hexViewModel.ApplyModel(hexModel);
                hexViewModel.InitializeCellRadius(CellRadius);
                ListHexViewModel.Add(hexViewModel);
                foreach (UIElement uiElement in hexViewModel.GetAllUIElements())
                {
                    ListUIElement.Add(uiElement);
                }
            }

            HexMapCenterX = HexMapDrawingHelper.GetRedrawnHexMapXCenter(CellRadius, Columns);
            HexMapCenterY = HexMapDrawingHelper.GetRedrawnHexMapYCenter(CellRadius, Columns, Rows);

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
                    hexModel.TileImageModel.ImageName);
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

        public void CenterHexMap()
        {
            Task<Point> newCenterHexMapPoint = GetNewCenterHexMapPoint();
            
            double xCenterMod = newCenterHexMapPoint.Result.X - HexMapCenterX;
            double yCenterMod = newCenterHexMapPoint.Result.Y - HexMapCenterY;

            MoveCanvas(xCenterMod, yCenterMod, true);
            HexMapCenterX = newCenterHexMapPoint.Result.X;
            HexMapCenterY = newCenterHexMapPoint.Result.Y;
        }

        public async Task<Point> GetNewCenterHexMapPoint()
        {
            GetHexMapCanvasDimensionsRequestMessage msg = new GetHexMapCanvasDimensionsRequestMessage();
            var result = await Messenger.Default.SendAsync(msg);
            double hexMapCanvasWidth = result.Result.Item1;
            double hexMapCanvasHeight = result.Result.Item2;

            double xCenterNew = (hexMapCanvasWidth / 2);
            double yCenterNew = (hexMapCanvasHeight / 2);

            return new Point(xCenterNew, yCenterNew);
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

            double oldCenterXMove = oldCenterX - oldHexMapCanvasX;
            double oldCenterYMove = oldCenterY - oldHexMapCanvasY;

            CellRadius = CellRadius * zoomMultiplicator;

            foreach (var hexViewModel in ListHexViewModel)
            {
                hexViewModel.UpdateCellRadius(CellRadius);
            }

            HexMapCenterX = HexMapDrawingHelper.GetRedrawnHexMapXCenter(CellRadius, Columns);
            HexMapCenterY = HexMapDrawingHelper.GetRedrawnHexMapYCenter(CellRadius, Columns, Rows);

            Task<Point> newCenterHexMapPoint = GetNewCenterHexMapPoint();

            MoveCanvas(
                newCenterHexMapPoint.Result.X - HexMapCenterX + oldCenterXMove * zoomMultiplicator,
                newCenterHexMapPoint.Result.Y - HexMapCenterY + oldCenterYMove * zoomMultiplicator,
                false
                );

            foreach (var communityViewModel in ListCommunityViewModel)
            {
                communityViewModel.Zoom(zoomMultiplicator);
            }
        }

        public void MoveCanvas(double xMovement, double yMovement, bool moveCommunities)
        {
            HexMapCenterX += xMovement;
            HexMapCenterY += yMovement;
            foreach (var hexViewModel in ListHexViewModel)
            {
                hexViewModel.Move(xMovement, yMovement);
            }
            if (moveCommunities)
            {
                foreach (var communityViewModel in ListCommunityViewModel)
                {
                    communityViewModel.Move(xMovement, yMovement);
                }
            }
        }

        #region Event Functions

        private void UnregisterMessages()
        {
            Messenger.Default.Deregister<HexTileUpdatedMessage>(this, HexTileUpdatedMessageFunction);
            Messenger.Default.Deregister<HexDegreExplorationUpdatedMessage>(this, HexDegreExplorationUpdatedMessageFunction);
            Messenger.Default.Deregister<HexModelSelectedMessage>(this, HexSelectedMessageFunction);
            Messenger.Default.Deregister<HexModelUnselectedMessage>(this, HexUnselectedMessageFunction);
            Messenger.Default.Deregister<MapTransformationRequestMessage>(this, MapTransformationRequestMessageFunction);
            Messenger.Default.Deregister<AddPointMessage>(this, AddPointMessageFunction);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<HexTileUpdatedMessage>(this, HexTileUpdatedMessageFunction);
            Messenger.Default.Register<HexDegreExplorationUpdatedMessage>(this, HexDegreExplorationUpdatedMessageFunction);
            Messenger.Default.Register<HexModelSelectedMessage>(this, HexSelectedMessageFunction);
            Messenger.Default.Register<HexModelUnselectedMessage>(this, HexUnselectedMessageFunction);
            Messenger.Default.Register<MapTransformationRequestMessage>(this, MapTransformationRequestMessageFunction);
            Messenger.Default.Register<AddPointMessage>(this, AddPointMessageFunction);
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

        private void MapTransformationRequestMessageFunction(MapTransformationRequestMessage msg)
        {
            if (Math.Abs(msg.XMovement) > 0 || Math.Abs(msg.YMovement) > 0)
            {
                MoveCanvas(msg.XMovement, msg.YMovement,true);
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

        public void AddPointMessageFunction(AddPointMessage msg)
        {
            Point closerPoint = msg.HexViewModel.HexDrawingData.GetCloserPointToPoint(msg.Point);

            Coordinates coordinates = new Coordinates(closerPoint.X, closerPoint.Y);
            Coordinates coordinatesFromCenter = new Coordinates(closerPoint.X - HexMapCenterX, closerPoint.Y - HexMapCenterY);

            CommunityCreationInputDialog dialog = new CommunityCreationInputDialog(coordinates, coordinatesFromCenter);

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dialog.Result.GenerateShapes();
                ListUIElement.Add(dialog.Result.CommunityDot);
                ListUIElement.Add(dialog.Result.CommunityLabel);
                ListCommunityViewModel.Add(dialog.Result);

                /*Ellipse childCtrl1 = new Ellipse();

                childCtrl1.Name = "Ellipse1";
                childCtrl1.StrokeThickness = 5;
                childCtrl1.Stroke = Brushes.Red;
                childCtrl1.Fill = Brushes.DarkRed;
                childCtrl1.Width = 10;
                childCtrl1.Height = 10;

                Canvas.SetTop(childCtrl1, msg.Point.Y - (childCtrl1.Height / 2));
                Canvas.SetLeft(childCtrl1, msg.Point.X - (childCtrl1.Width / 2));

                ListUIElement.Add(childCtrl1);*/
            }
        }

        #endregion Event Functions
    }
}