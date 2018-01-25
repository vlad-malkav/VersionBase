namespace DataLibrary.Tiles
{
    public class TileImageData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }

        public TileImageData()
            :this("empty")
        {

        }

        public TileImageData(string imageName)
        {
            ImageName = imageName;
            Id = ImageName;
            Name = ImageName.ToUpper();
        }
    }
}
