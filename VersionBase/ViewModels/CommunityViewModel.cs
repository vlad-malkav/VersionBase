using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using VersionBase.Libraries.Drawing;
using VersionBase.Models;

namespace VersionBase.ViewModels
{
    public class CommunityViewModel : AbstractViewModel<CommunityModel>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Inhabitants { get; set; }
        public string Description { get; set; }
        public Coordinates CoordinatesCellRadiusFromCenter { get; set; }
        public double CellRadius { get; set; }
        public Coordinates Coordinates { get; set; }
        public Coordinates CoordinatesFromCenter { get; set; }
        public Ellipse CommunityDot { get; set; }
        public TextBlock CommunityLabel { get; set; }

        public CommunityViewModel()
        {
            Coordinates = new Coordinates(0, 0);
            CoordinatesFromCenter = new Coordinates(0, 0);
            CommunityDot = new Ellipse();
            CommunityLabel = new TextBlock();
        }

        public CommunityViewModel(Coordinates coordinates, Coordinates coordinatesFromCenter, string name, string type = "", string size = "", string inhabitants = "", string description = "")
            : this()
        {
            this.Coordinates = coordinates;
            this.CoordinatesFromCenter = coordinatesFromCenter;
            this.Name = name;
            this.Type = type;
            this.Size = size;
            this.Inhabitants = inhabitants;
            this.Description = description;
        }

        public override void ApplyModel(CommunityModel model)
        {
            this.CoordinatesCellRadiusFromCenter = model.CoordinatesCellRadiusFromCenter;
            this.Name = model.Name;
            this.Type = model.Type;
            this.Size = model.Size;
            this.Inhabitants = model.Inhabitants;
            this.Description = model.Description;
        }

        public void InitializeRadiusAndCoordinates(double cellRadius, Coordinates centerCoordinates)
        {
            CellRadius = cellRadius;
            CoordinatesFromCenter.X = CoordinatesCellRadiusFromCenter.X * CellRadius;
            CoordinatesFromCenter.Y = CoordinatesCellRadiusFromCenter.Y * CellRadius;
            Coordinates.X = centerCoordinates.X + CoordinatesFromCenter.X;
            Coordinates.Y = centerCoordinates.Y + CoordinatesFromCenter.Y;

            GenerateShapes();
        }

        public void UpdateRadiusAndCoordinates(double cellRadius, Coordinates centerCoordinates)
        {
            CellRadius = cellRadius;
            CoordinatesFromCenter.X = CoordinatesCellRadiusFromCenter.X * CellRadius;
            CoordinatesFromCenter.Y = CoordinatesCellRadiusFromCenter.Y * CellRadius;
            Coordinates.X = centerCoordinates.X - CoordinatesFromCenter.X;
            Coordinates.Y = centerCoordinates.Y - CoordinatesFromCenter.Y;

            UpdateDrawing();
        }

        public void GenerateShapes()
        {
            CommunityDot.Name = "Ellipse";
            CommunityDot.StrokeThickness = 5;
            CommunityDot.Stroke = Brushes.Blue;
            CommunityDot.Fill = Brushes.DarkBlue;
            CommunityDot.Width = 10;
            CommunityDot.Height = 10;

            CommunityLabel.Text = Name;
            CommunityLabel.FontFamily = new FontFamily("Segoe");
            CommunityLabel.FontSize = 10;
            CommunityLabel.Background = new SolidColorBrush(Colors.Azure);

            UpdateDrawing();
        }

        public void UpdateDrawing()
        {
            Canvas.SetTop(CommunityDot, Coordinates.Y - (CommunityDot.Height / 2));
            Canvas.SetLeft(CommunityDot, Coordinates.X - (CommunityDot.Width / 2));
            Canvas.SetTop(CommunityLabel, Coordinates.Y - (CommunityDot.Height / 2));
            Canvas.SetLeft(CommunityLabel, Coordinates.X + (CommunityDot.Width / 2));
        }

        public void Move(double moveX, double moveY)
        {
            CoordinatesFromCenter.X += moveX;
            CoordinatesFromCenter.Y += moveY;
            Coordinates.X += moveX;
            Coordinates.Y += moveY;
            UpdateDrawing();
        }

        public void Zoom(double multiplicator)
        {
            Coordinates.X += CoordinatesFromCenter.X * (multiplicator-1);
            Coordinates.Y += CoordinatesFromCenter.Y * (multiplicator - 1);
            CoordinatesFromCenter.X = CoordinatesFromCenter.X * multiplicator;
            CoordinatesFromCenter.Y = CoordinatesFromCenter.Y * multiplicator;
            UpdateDrawing();
        }

        public List<UIElement> GetAllUIElements()
        {
            List<UIElement> listUiElement = new List<UIElement>();
            listUiElement.Add(this.CommunityDot);
            listUiElement.Add(this.CommunityLabel);

            return listUiElement;
        }
    }
}
