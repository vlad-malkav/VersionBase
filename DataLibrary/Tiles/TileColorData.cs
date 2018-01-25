namespace DataLibrary.Tiles
{
    public class TileColorData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte Alpha { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public bool FromMedia { get; set; }

        public TileColorData(){}

        public TileColorData(System.Windows.Media.Color windowsMediaColor)
        {
            Name = windowsMediaColor.ToString();
            Alpha = windowsMediaColor.A;
            Red = windowsMediaColor.R;
            Green = windowsMediaColor.G;
            Blue = windowsMediaColor.B;
            Id = "Color-" + Alpha + "." + Red + "." + Green + "." + Blue;
        }

        public TileColorData(System.Drawing.Color drawingColor)
        {
            Id = drawingColor.ToString();
            Name = drawingColor.ToString();
            Alpha = drawingColor.A;
            Red = drawingColor.R;
            Green = drawingColor.G;
            Blue = drawingColor.B;
            Id = "Color-" + Alpha + "." + Red + "." + Green + "." + Blue;
        }
    }
}
