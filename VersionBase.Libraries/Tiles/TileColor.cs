namespace VersionBase.Libraries.Tiles
{
    public class TileColor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte Alpha { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public TileColor(){}

        public TileColor(System.Windows.Media.Color windowsMediaColor)
        {
            Id = windowsMediaColor.ToString();
            Name = windowsMediaColor.ToString();
            Alpha = windowsMediaColor.A;
            Red = windowsMediaColor.R;
            Green = windowsMediaColor.G;
            Blue = windowsMediaColor.B;
        }

        public TileColor(System.Drawing.Color drawingColor)
        {
            Id = drawingColor.ToString();
            Name = drawingColor.ToString();
            Alpha = drawingColor.A;
            Red = drawingColor.R;
            Green = drawingColor.G;
            Blue = drawingColor.B;
        }

        public System.Windows.Media.Color GetWindowsMediaColor()
        {
            return System.Windows.Media.Color.FromArgb(Alpha, Red, Green, Blue);
        }

        public System.Drawing.Color GetDrawingColor()
        {
            return System.Drawing.Color.FromArgb(Alpha, Red, Green, Blue);
        }
    }
}
