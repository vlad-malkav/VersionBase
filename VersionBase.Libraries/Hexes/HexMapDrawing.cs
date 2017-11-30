using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace VersionBase.Libraries.Hexes
{
    public class HexMapDrawing
    {
        public static List<Polygon> GenerateHexMap(Dictionary<HexCoordinates, HexData> dictionaryHexData, double cellSize)
        {
            List<Polygon> hexMap = new List<Polygon>();

            foreach (KeyValuePair<HexCoordinates, HexData> kvpHexData in dictionaryHexData)
            {
                Polygon hex = GenerateHex(kvpHexData.Value);
                hexMap.Add(hex);
            }

            return hexMap;
        }

        public static Polygon GenerateHex(HexData hexData)
        {
            var hexDrawingData = hexData.HexDrawingData;
            var hex = new Polygon();
            hex.Points.Add(new Point(hexDrawingData.CellX - hexDrawingData.CellSize, hexDrawingData.CellY));
            hex.Points.Add(new Point(hexDrawingData.CellX - hexDrawingData.CellSize / 2, hexDrawingData.CellY + hexDrawingData.CellHeight / 2));
            hex.Points.Add(new Point(hexDrawingData.CellX + hexDrawingData.CellSize / 2, hexDrawingData.CellY + hexDrawingData.CellHeight / 2));
            hex.Points.Add(new Point(hexDrawingData.CellX + hexDrawingData.CellSize, hexDrawingData.CellY));
            hex.Points.Add(new Point(hexDrawingData.CellX + hexDrawingData.CellSize / 2, hexDrawingData.CellY - hexDrawingData.CellHeight / 2));
            hex.Points.Add(new Point(hexDrawingData.CellX - hexDrawingData.CellSize / 2, hexDrawingData.CellY - hexDrawingData.CellHeight / 2));
            hex.Tag = hexData.HexCoordinates;
            return hex;
        }
    }
}
