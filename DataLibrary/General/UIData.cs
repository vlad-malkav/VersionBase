using System.Collections.Generic;
using DataLibrary.Tiles;

namespace DataLibrary.General
{
    public class UIData
    {
        public List<TileColorData> ListTileColor;
        public List<TileImageData> ListTileImage;

        public UIData() { }

        public UIData(List<TileColorData> listTileColor, List<TileImageData> listTileImage)
        {
            ListTileColor = listTileColor;
            ListTileImage = listTileImage;
        }
    }
}
