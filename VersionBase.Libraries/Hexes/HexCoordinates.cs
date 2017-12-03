namespace VersionBase.Libraries.Hexes
{
    public class HexCoordinates
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public HexCoordinates(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}
