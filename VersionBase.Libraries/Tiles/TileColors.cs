using System;
using System.Collections.Generic;
using System.Drawing;

namespace VersionBase.Libraries.Tiles
{
    public static class TileColors
    {
        public static List<TileColor> GetAllWindowsMediaColors()
        {
            List<TileColor> listTileColor = new List<TileColor>();
            

            foreach (object color in Enum.GetValues(typeof(KnownColor)))
            {
                listTileColor.Add(new TileColor(Color.FromKnownColor((KnownColor) color)));
            }

            return listTileColor;
        }
    }
}
