using System.Collections.ObjectModel;
using System.Windows.Shapes;
using VersionBase.Libraries.Hexes;

namespace Controls.Library.Models
{
    public class HexModel
    {
        public HexData HexData { get; set; }
        public HexDrawingData HexDrawingData { get; set; }
        public Polygon Polygon { get; set; }

        public HexModel() { }

        public HexModel(HexData hexData, double cellSize)
        {
            HexData = hexData;
            UpdateCellSize(cellSize);
        }

        public void UpdateCellSize(double cellSize)
        {
            HexDrawingData = new HexDrawingData(HexData.HexCoordinates, cellSize);
            Polygon = HexMapDrawing.GenerateHex(HexDrawingData, HexData.TileData);
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
