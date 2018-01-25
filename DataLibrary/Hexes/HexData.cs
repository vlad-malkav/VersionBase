using DataLibrary.Tiles;

namespace DataLibrary.Hexes
{
    public class HexData
    {
        public string Description { get; set; }
        public int DegreExploration { get; set; }
        public TileData TileData { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }

        public HexData(){}

        public HexData(int column, int row, string description, int degreExploration, TileData tileData)
        {
            Column = column;
            Row = row;
            Description = description;
            DegreExploration = degreExploration;
            TileData = tileData;
        }
    }
}
