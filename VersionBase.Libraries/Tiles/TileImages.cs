using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Resources;
using System.Globalization; 

namespace VersionBase.Libraries.Tiles
{
    public static class TileImages
    {
        public static List<TileImage> GetAllTileImages()
        {
            return TileImageTypes.GetAllTileImageTypes().Select(x => new TileImage(x)).ToList();
        }
    }
}
