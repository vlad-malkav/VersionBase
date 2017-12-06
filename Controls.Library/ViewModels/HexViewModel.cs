using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Controls.Library.Models;
using VersionBase.Libraries.Hexes;

namespace Controls.Library.ViewModels
{
    public class HexViewModel
    {
        public string Text { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public bool Selected { get; set; }
        public double CellSize { get; set; }
        public Color Color { get; set; }
        public Bitmap Bitmap { get; set; }
        public Polygon Polygon { get; set; }

        public HexViewModel() { }

        public HexViewModel(HexModel hexModel, double cellSize)
        {
            Text = hexModel.Text;
            Column = hexModel.Column;
            Row = hexModel.Row;
            Selected = false;
            CellSize = cellSize;
            Color = hexModel.TileColorModel.GetDrawingColor();
            Bitmap = hexModel.TileImageTypeModel.GetBitmap();
            Polygon = HexMapDrawing.GenerateAndFillHexPolygon(Column, Row, CellSize, Color, Bitmap);
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
        }
    }
}
