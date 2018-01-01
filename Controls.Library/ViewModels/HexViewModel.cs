﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;
using VersionBase.Libraries.Drawing;
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
        private double CellSize { get; set; }
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
            Bitmap = hexModel.TileImageModel.Bitmap;

            HexDrawingData.SetHexCoordinates(Column, Row);
        }

        public void SelectHex()
        {
            if (!Selected)
            {
                Selected = true;
                HexMapDrawing.BorderPolygon_UpdateSelected(HexDrawingData, BorderPolygon, Selected);

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
                HexMapDrawing.BorderPolygon_UpdateSelected(HexDrawingData, BorderPolygon, Selected);

                Messenger.Default.Send(
                    new HexViewModelUnselectedMessage
                    {
                        HexViewModel = this
                    });
            }
        }

        public void SetCellSize(double cellSize)
        {
            CellSize = cellSize;

            HexDrawingData.UpdateDrawing(CellSize);

            GenerateShapes();
        }

        public void UpdateCellSize(double cellSize)
        {
            CellSize = cellSize;

            HexDrawingData.UpdateDrawing(CellSize);

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

        public void UpdateTileData(Color color, Bitmap bitmap)
        {
            Color = color;
            Bitmap = bitmap;
            HexMapDrawing.InsidePolygon_UpdateFill(InsidePolygon, Color, Bitmap);
        }

        public void UpdateDegreExploration(int degreExploration)
        {
            DegreExploration = degreExploration;
            for (int i = 0; i < ListLineExploration.Count; i++)
            {
                HexMapDrawing.LineExploration_UpdateVisibility(ListLineExploration[i], i, DegreExploration);
            }
        }

        public void GenerateShapes()
        {
            HexMapDrawing.InsidePolygon_Draw(HexDrawingData, InsidePolygon, Color, Bitmap);
            HexMapDrawing.BorderPolygon_Draw(HexDrawingData, BorderPolygon);
            HexMapDrawing.HexLabel_Draw(HexDrawingData, GridLabel, Label);
            HexMapDrawing.HexLineExploration_Draw(HexDrawingData, ListLineExploration, DegreExploration);
        }

        public void UpdateShapes()
        {
            HexMapDrawing.InsidePolygon_Update(HexDrawingData, InsidePolygon);
            HexMapDrawing.BorderPolygon_Draw(HexDrawingData, BorderPolygon);
            HexMapDrawing.HexLabel_Draw(HexDrawingData, GridLabel, Label);
            HexMapDrawing.HexLineExploration_Update(HexDrawingData, ListLineExploration);
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
