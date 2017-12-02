using System.Collections.Generic;
using System.Windows.Shapes;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Libraries.Hexes
{
    public class HexData
    {
        public string Text { get; set; }
        public TileImageType TileType { get; set; }
        public bool Selected { get; set; }
        public HexCoordinates HexCoordinates { get; set; }
        private HexDrawingData _HexDrawingData { get; set; }

        public HexDrawingData HexDrawingData
        {
            get
            {
                if (_HexDrawingData == null)
                {
                    _HexDrawingData = new HexDrawingData(HexCoordinates, CellSize);
                }
                return _HexDrawingData;
            }
        }

        public double CellSize { get; set; }

        public HexData(HexCoordinates hexCoordinates, string text, TileImageType tileType, double cellSize)
            : this(hexCoordinates, text, tileType)
        {
            CellSize = cellSize;
        }

        public HexData(HexCoordinates hexCoordinates, string text, TileImageType tileType)
        {
            HexCoordinates = hexCoordinates;
            Text = text;
            TileType = tileType;
            Selected = false;
            CellSize = 100;
        }

        public Polygon GenerateHex()
        {
            return HexMapDrawing.GenerateHex(this);
        }

        public Polygon GenerateHex(double cellSize)
        {
            CellSize = cellSize;
            return HexMapDrawing.GenerateHex(this);
        }
    }
}
