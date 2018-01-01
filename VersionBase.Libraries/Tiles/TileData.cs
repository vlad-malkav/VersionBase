namespace VersionBase.Libraries.Tiles
{
    public class TileData
    {
        public TileColor TileColor { get; set; }
        public TileImage TileImage { get; set; }
        
        public TileData(){}

        public TileData(TileColor tileColor, TileImage tileImage)
        {
            TileColor = tileColor;
            TileImage = tileImage;
        }
    }
}
