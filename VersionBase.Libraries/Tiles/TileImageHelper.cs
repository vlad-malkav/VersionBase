using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace VersionBase.Libraries.Tiles
{
    public static class TileImageHelper
    {
        public static List<TileImageData> GetAllTileImages()
        {
            List<TileImageData> listTileImageData = new List<TileImageData>();
            ResourceSet rsrcSet = Properties.Tileset_Set_1.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

            foreach (DictionaryEntry entry in rsrcSet)
            {
                string name = (string) entry.Key;
                listTileImageData.Add(new TileImageData(name));
                //Object resource = entry.Value;
            }

            return listTileImageData;//TileImageTypes.GetAllTileImageTypes().Select(x => new TileImageData(x.ToString())).ToList();
        }

        public static Bitmap GetBitmapTile(string tileImageTypeName)
        {
            return (Bitmap)Properties.Tileset_Set_1.ResourceManager.GetObject(tileImageTypeName);
        }
    }
}
