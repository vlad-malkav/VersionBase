using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using VersionBase.Events;
using VersionBase.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;
using VersionBase.Libraries.Drawing;
using Color = System.Drawing.Color;

namespace VersionBase.ViewModels
{
    public class HexViewModel : AbstractViewModel<HexModel>
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public int DegreExploration { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public bool Selected { get; set; }
        private double CellRadius { get; set; }
        public Polygon InsidePolygon { get; private set; }
        public Polygon BorderPolygon { get; private set; }
        public Grid GridLabel { get; set; }
        public List<Line> ListLineExploration { get; set; }
        public HexDrawingInformations HexDrawingData { get; set; }

        public HexViewModel()
        {
            Selected = false;
            InsidePolygon = new Polygon();
            BorderPolygon = new Polygon();
            GridLabel = new Grid();
            ListLineExploration = new List<Line>();
            for (int i = 0; i < 6; i++)
            {
                ListLineExploration.Add(new Line());
            }
            InsidePolygon.MouseLeftButtonDown += MouseLeftButtonDown;
            InsidePolygon.MouseRightButtonDown += MouseRightButtonDown;
            HexDrawingData = new HexDrawingInformations();
        }

        public List<UIElement> GetAllUIElements()
        {
            List<UIElement> listUiElement = new List<UIElement>();
            listUiElement.Add(InsidePolygon);
            listUiElement.Add(GridLabel);
            listUiElement.Add(BorderPolygon);
            listUiElement.AddRange(ListLineExploration);

            return listUiElement;
        }

        public void UnsubscribePolygonEvents()
        {
            InsidePolygon.MouseLeftButtonDown -= MouseLeftButtonDown;
            InsidePolygon.MouseRightButtonDown -= MouseRightButtonDown;
        }

        public override void ApplyModel(HexModel model)
        {
            Label = model.GetLabel();
            Description = model.Description;
            DegreExploration = model.DegreExploration;
            Column = model.Column;
            Row = model.Row;

            HexDrawingData.SetHexCoordinates(Column, Row);
            UpdateTileData(model.TileColorModel.GetDrawingColor(), model.TileImageModel.ImageName);
        }

        public void InitializeCellRadius(double cellRadius)
        {
            CellRadius = cellRadius;
            HexDrawingData.UpdateDrawing(CellRadius);
            GenerateShapes();
        }

        public void SelectHex()
        {
            if (!Selected)
            {
                Selected = true;
                HexMapDrawingHelper.BorderPolygon_UpdateSelected(HexDrawingData, BorderPolygon, Selected);

                Messenger.Default.Send(
                    new HexViewModelSelectedMessage
                    {
                        HexViewModel = this
                    });
            }
        }

        public void UnselectHex()
        {
            if (Selected)
            {
                Selected = false;
                HexMapDrawingHelper.BorderPolygon_UpdateSelected(HexDrawingData, BorderPolygon, Selected);

                Messenger.Default.Send(
                    new HexViewModelUnselectedMessage
                    {
                        HexViewModel = this
                    });
            }
        }

        public void UpdateCellRadius(double cellRadius)
        {
            CellRadius = cellRadius;

            HexDrawingData.UpdateDrawing(CellRadius);

            UpdateShapes();
        }

        public void Move(double moveX, double moveY)
        {
            DrawingFunctions.MovePolygon(InsidePolygon, moveX, moveY);
            DrawingFunctions.MovePolygon(BorderPolygon, moveX, moveY);
            DrawingFunctions.MoveGrid(GridLabel, moveX, moveY);
            foreach (var line in ListLineExploration)
            {
                DrawingFunctions.MoveLine(line, moveX, moveY);
            }
        }

        public async void UpdateTileData(Color color, string imageName)
        {
            GetBitmapByNameMessage msg = new GetBitmapByNameMessage(imageName);
            var result = await Messenger.Default.SendAsync(msg);
            HexMapDrawingHelper.InsidePolygon_UpdateFill(InsidePolygon, color, result.Result);
        }

        public void UpdateDegreExploration(int degreExploration)
        {
            DegreExploration = degreExploration;
            for (int i = 0; i < ListLineExploration.Count; i++)
            {
                HexMapDrawingHelper.LineExploration_UpdateVisibility(ListLineExploration[i], i, DegreExploration);
            }
        }

        public void GenerateShapes()
        {
            HexMapDrawingHelper.InsidePolygon_Draw(HexDrawingData, InsidePolygon/*, Color, Bitmap*/);
            HexMapDrawingHelper.BorderPolygon_Draw(HexDrawingData, BorderPolygon);
            HexMapDrawingHelper.HexLabel_Draw(HexDrawingData, GridLabel, Label);
            HexMapDrawingHelper.HexLineExploration_Draw(HexDrawingData, ListLineExploration, DegreExploration);
        }

        public void UpdateShapes()
        {
            HexMapDrawingHelper.InsidePolygon_Update(HexDrawingData, InsidePolygon);
            HexMapDrawingHelper.BorderPolygon_Draw(HexDrawingData, BorderPolygon);
            HexMapDrawingHelper.HexLabel_Draw(HexDrawingData, GridLabel, Label);
            HexMapDrawingHelper.HexLineExploration_Update(HexDrawingData, ListLineExploration);
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(
                new HexClickedLeftButtonMessage
                {
                    HexViewModel = this
                });
        }

        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(
                new HexClickedRightButtonMessage
                {
                    HexViewModel = this
                });
        }
    }
}
