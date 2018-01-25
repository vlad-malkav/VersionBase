using System;
using System.Collections.Generic;
using System.Drawing;
using DataLibrary.Tiles;

namespace VersionBase.Libraries.Tiles
{
    public static class TileColorHelper
    {
        public static List<TileColorData> GetAllTileColors()
        {
            List<TileColorData> listTileColor = new List<TileColorData>();
            

            foreach (object color in Enum.GetValues(typeof(KnownColor)))
            {
                listTileColor.Add(new TileColorData(Color.FromKnownColor((KnownColor) color)));
            }

            return listTileColor;
        }
    }
}
