using System.Drawing;
using System.Windows.Input;
using System.Windows.Shapes;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;
using VersionBase.Libraries.Hexes;

namespace Controls.Library.ViewModels
{
    public class HexViewModel : ViewModelBase
    {
        public string Text { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public bool Selected { get; set; }
        public double CellSize { get; set; }
        public Color Color { get; set; }
        public Bitmap Bitmap { get; set; }
        public Polygon Polygon { get; set; }

        public HexViewModel()
        {
            Selected = false;
            Polygon = new Polygon();
            Polygon.MouseLeftButtonDown += MouseLeftButtonDown;
            Polygon.MouseRightButtonDown += MouseRightButtonDown;
        }

        public HexViewModel(HexModel hexModel, double cellSize)
            :this()
        {
            CellSize = cellSize;
            UpdateFromHexModel(hexModel);
        }

        public void UnsubscribePolygonEvents()
        {
            Polygon.MouseLeftButtonDown -= MouseLeftButtonDown;
            Polygon.MouseRightButtonDown -= MouseRightButtonDown;
        }

        public void UpdateFromHexModel(HexModel hexModel)
        {
            Text = hexModel.Text;
            Column = hexModel.Column;
            Row = hexModel.Row;
            Color = hexModel.TileColorModel.GetDrawingColor();
            Bitmap = hexModel.TileImageTypeModel.GetBitmap();
            RegeneratePolygon();
        }

        public void UpdateCellSize(double cellSize)
        {
            RegeneratePolygon();
        }

        public void UpdateTileData(Color color, Bitmap bitmap)
        {
            Color = color;
            Bitmap = bitmap;
            RegeneratePolygon();
        }

        public void RegeneratePolygon()
        {
            HexMapDrawing.UpdateAndFillHexPolygon(Polygon, Column, Row, CellSize, Color, Bitmap);
            Polygon.Tag = Text;
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            object tag = ((Polygon) sender).Tag;
            // Broadcast Events
            Messenger.Default.Send(
                new HexClickedLeftButtonMessage
                {
                    Column = Column,
                    Row = Row
                });
        }

        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(
                new HexClickedRightButtonMessage
                {
                    Column = Column,
                    Row = Row
                });
        }
    }
}
