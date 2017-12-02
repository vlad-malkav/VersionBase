using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionBase.Libraries.Tiles
{
    public class TileColor
    {
        public string Name { get; set; }
        public System.Windows.Media.Color WindowsMediaColor { get; set; }
        public System.Drawing.Color DrawingColor { get; set; }

        public TileColor(System.Windows.Media.Color windowsMediaColor)
        {
            Name = windowsMediaColor.ToString();
            WindowsMediaColor = windowsMediaColor;
            DrawingColor = System.Drawing.Color.FromArgb(WindowsMediaColor.A, WindowsMediaColor.R, WindowsMediaColor.G, WindowsMediaColor.B);
        }

        public TileColor(System.Drawing.Color drawingColor)
        {
            Name = drawingColor.ToString();
            DrawingColor = drawingColor;
            WindowsMediaColor = System.Windows.Media.Color.FromArgb(DrawingColor.A, DrawingColor.R, DrawingColor.G, DrawingColor.B);
        }
    }
}
