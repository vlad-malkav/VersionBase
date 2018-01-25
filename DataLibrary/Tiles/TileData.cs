namespace DataLibrary.Tiles
{
    public class TileData
    {
        public TileColorData TileColorData { get; set; }
        public TileImageData TileImageData { get; set; }
        
        public TileData(){}

        public TileData(TileColorData tileColorData, TileImageData tileImageData)
        {
            TileColorData = tileColorData;
            TileImageData = tileImageData;
        }
    }
}
