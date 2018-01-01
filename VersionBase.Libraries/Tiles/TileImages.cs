using System.Collections.Generic;
using System.Linq;

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
