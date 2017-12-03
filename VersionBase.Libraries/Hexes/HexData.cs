using VersionBase.Libraries.Tiles;

namespace VersionBase.Libraries.Hexes
{
    public class HexData
    {
        public string Text { get; set; }
        public TileData TileData { get; set; }
        public bool Selected { get; set; }
        public HexCoordinates HexCoordinates { get; set; }


        public HexData(HexCoordinates hexCoordinates, string text, TileData tileData, double cellSize)
        {
            HexCoordinates = hexCoordinates;
            Text = text;
            TileData = tileData;
            Selected = false;
        }
    }
}
