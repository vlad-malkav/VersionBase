using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using VersionBase.Libraries.Enums;

namespace VersionBase.Libraries.Tiles
{
    public static class TileImageTypes
    {
        public static List<TileImageType> GetAllTileImageTypes()
        {
            return ((TileImageType[])Enum.GetValues(typeof(TileImageType))).ToList();
        }

        public static Bitmap GetBitmapTile(string tileImageTypeName)
        {
            return (Bitmap)Properties.Tileset_Set_1.ResourceManager.GetObject(tileImageTypeName);
        }

        public static Bitmap GetBitmapTile(TileImageType tileImageType)
        {
            return (Bitmap)Properties.Tileset_Set_1.ResourceManager.GetObject(tileImageType.ToString());
        }

        /*
        private const string path =
            ".\\Resources\\Images\\Set1\\";

        public static string GetBitmapImagePath(TileImageType tileType)
        {
            //VersionBase.Resources.ResourceManager.
            return path + tileType.ToString() + ".png";
        }

        public static Bitmap GetBitmapTile(TileImageType tileImageType)
        {
            return new Bitmap(TileImageTypes.GetBitmapImagePath(tileImageType));
        }

        public static BitmapImage GetBitmapImageTile(TileImageType tileImageType)
        {
            return new BitmapImage(new Uri(TileImageTypes.GetBitmapImagePath(tileImageType)));
        }

        public static Tile GetTile(TileImageType tileType)
        {
            switch (tileType)
            {
                case TileImageType.badlands:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.cactus:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.cultivatedfarmland:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.deadforest:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.deadforesthills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.deadforestmountain:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.deadforestmountains:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.dunes:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.evergreen:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.evergreenhills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.evergreenmountain:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.evergreenmountains:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.forestedhills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.forestedmountain:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.forestedmountains:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.grassland:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.grassyhills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.heavycactus:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.heavyevergreen:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.heavyforest:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.hills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.jungle:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.junglehills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.lightforest:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.marsh:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.mountain:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.mountains:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.reefs:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.rockydesert:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.sandydesert:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.swamp:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.volcano:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
                case TileImageType.volcanodormant:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png", tileType);
                    break;
            }
            return null;
        }*/
    }
}
