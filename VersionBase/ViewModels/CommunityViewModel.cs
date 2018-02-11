using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using VersionBase.Libraries.Drawing;

namespace VersionBase.ViewModels
{
    public class CommunityViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Inhabitants { get; set; }
        public string Description { get; set; }
        public Coordinates Coordinates { get; set; }
        public Ellipse CommunityDot { get; set; }
        public TextBlock CommunityLabel { get; set; }

        public CommunityViewModel()
        {
            Coordinates = new Coordinates(0,0);
            CommunityDot = new Ellipse();
            CommunityLabel = new TextBlock();
        }

        public CommunityViewModel(Coordinates coordinates, string name, string type = "", string size = "", string inhabitants = "", string description = "")
            : this()
        {
            this.Coordinates = coordinates;
            this.Name = name;
            this.Type = type;
            this.Size = size;
            this.Inhabitants = inhabitants;
            this.Description = description;
        }

        public void DrawCommunity()
        {
            CommunityDot.Name = "Ellipse";
            CommunityDot.StrokeThickness = 5;
            CommunityDot.Stroke = Brushes.Blue;
            CommunityDot.Fill = Brushes.DarkBlue;
            CommunityDot.Width = 10;
            CommunityDot.Height = 10;

            Canvas.SetTop(CommunityDot, Coordinates.Y - (CommunityDot.Height / 2));
            Canvas.SetLeft(CommunityDot, Coordinates.X - (CommunityDot.Width / 2));

            CommunityLabel.Text = Name;
            CommunityLabel.FontFamily = new FontFamily("Segoe");
            CommunityLabel.FontSize = 10;
            CommunityLabel.Background = new SolidColorBrush(Colors.Azure);

            Canvas.SetTop(CommunityLabel, Coordinates.Y - (CommunityDot.Height / 2));
            Canvas.SetLeft(CommunityLabel, Coordinates.X + (CommunityDot.Width / 2));
        }
    }
}
