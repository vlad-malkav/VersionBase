using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionBase.Libraries.Tiles
{
    public static class TileSet
    {
        private const string path =
            "G:\\Programmation\\Projets C#\\Mon Projet\\VersionBase\\Ressources\\Images\\multicolored-icons\\";

        public static Tile GetTile(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.badlands:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.cactus:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.cultivatedfarmland:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.deadforest:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.deadforesthills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.deadforestmountain:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.deadforestmountains:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.dunes:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.evergreen:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.evergreenhills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.evergreenmountain:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.evergreenmountains:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.forestedhills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.forestedmountain:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.forestedmountains:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.grassland:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.grassyhills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.heavycactus:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.heavyevergreen:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.heavyforest:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.hills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.jungle:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.junglehills:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.lightforest:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.marsh:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.mountain:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.mountains:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.reefs:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.rockydesert:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.sandydesert:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.swamp:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.volcano:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
                case TileType.volcanodormant:
                    return new Tile(Color.LightGreen, path + tileType.ToString() + ".png");
                    break;
            }
            return null;
        }
    }
}
