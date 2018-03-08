using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.PointsAndLines
{
    public class CommunityData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Inhabitants { get; set; }
        public string Description { get; set; }
        public double CoordinatesCellRadiusFromCenterX { get; set; }
        public double CoordinatesCellRadiusFromCenterY { get; set; }

        public CommunityData() { }

        public CommunityData(string name, string type, string size, string inhabitants, 
            string description, double coordinatesCellRadiusFromCenterX, double coordinatesCellRadiusFromCenterY)
        {
            Name = name;
            Type = type;
            Size = size;
            Inhabitants = inhabitants;
            Description = description;
            CoordinatesCellRadiusFromCenterX = coordinatesCellRadiusFromCenterX;
            CoordinatesCellRadiusFromCenterY = coordinatesCellRadiusFromCenterY;
        }
    }
}
