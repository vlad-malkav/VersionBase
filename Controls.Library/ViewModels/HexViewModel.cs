using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;
using VersionBase.Libraries.Drawing;
using VersionBase.Libraries.Hexes;
using Color = System.Drawing.Color;

namespace Controls.Library.ViewModels
{
    public class HexViewModel : ViewModelBase
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public int DegreExploration { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public bool Selected { get; set; }
        public double XCenterMod { get; set; }
        public double YCenterMod { get; set; }
        public double CellSize { get; set; }
        public Color Color { get; set; }
        public Bitmap Bitmap { get; set; }
        public Polygon InsidePolygon { get; private set; }
        public Polygon BorderPolygon { get; private set; }
        public Grid GridLabel { get; set; }
        public List<Line> ListLineExploration { get; set; }
        public HexDrawingData HexDrawingData { get; set; }

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
            HexDrawingData = new HexDrawingData();
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

        public void UpdateFromHexModel(HexModel hexModel)
        {
            Label = hexModel.GetLabel();
            Description = hexModel.Description;
            DegreExploration = hexModel.DegreExploration;
            Column = hexModel.Column;
            Row = hexModel.Row;
            Color = hexModel.TileColorModel.GetDrawingColor();
            Bitmap = hexModel.TileImageTypeModel.GetBitmap();

            HexDrawingData.SetHexCoordinates(Column, Row);
        }

        public void SelectHex()
        {
            if (!Selected)
            {
                Selected = true;
                HexMapDrawing.UpdateBorderPolygon(HexDrawingData, BorderPolygon, Selected);

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
                HexMapDrawing.UpdateBorderPolygon(HexDrawingData, BorderPolygon, Selected);

                Messenger.Default.Send(
                    new HexViewModelUnselectedMessage
                    {
                        HexViewModel = this
                    });
            }
        }

        public void UpdateDrawingDimensions(double xCenterMod, double yCenterMod, double cellSize)
        {
            XCenterMod = 0;
            YCenterMod = 0;
            CellSize = cellSize;

            HexDrawingData.UpdateDrawing(/*XCenterMod, YCenterMod,*/ CellSize);

            GenerateShapes();

            Move(xCenterMod, yCenterMod);
        }

        public void Move(double moveX, double moveY)
        {
            XCenterMod += moveX;
            YCenterMod += moveY;
            DrawingFunctions.MovePolygon(InsidePolygon, moveX, moveY);
            DrawingFunctions.MovePolygon(BorderPolygon, moveX, moveY);
            DrawingFunctions.MoveGrid(GridLabel, moveX, moveY);
            foreach (var line in ListLineExploration)
            {
                DrawingFunctions.MoveLine(line, moveX, moveY);
            }
        }

        public void UpdateTileData(Color color, Bitmap bitmap)
        {
            Color = color;
            Bitmap = bitmap;
            HexMapDrawing.UpdateInsidePolygon(InsidePolygon, Color, Bitmap);
        }

        public void UpdateDegreExploration(int degreExploration)
        {
            DegreExploration = degreExploration;
            for (int i = 0; i < ListLineExploration.Count; i++)
            {
                HexMapDrawing.UpdateLineExploration(ListLineExploration[i], i, DegreExploration);
            }
        }

        public void GenerateShapes() {
            HexMapDrawing.DrawInsidePolygon(HexDrawingData, InsidePolygon, Color, Bitmap);
            HexMapDrawing.DrawBorderPolygon(HexDrawingData, BorderPolygon);
            HexMapDrawing.DrawHexLabel(HexDrawingData, GridLabel, Label);
            HexMapDrawing.DrawHexLineExploration(HexDrawingData, ListLineExploration, DegreExploration);
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
