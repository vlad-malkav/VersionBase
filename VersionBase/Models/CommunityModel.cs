using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.PointsAndLines;
using VersionBase.Libraries.Drawing;

namespace VersionBase.Models
{
    public class CommunityModel : IModel<CommunityData>
    {
        private string _name;
        private string _type;
        private string _size;
        private string _inhabitants;
        private string _description;
        private Coordinates _coordinatesCellRadiusFromCenter;

        public string Name
        {
            get { return _name; }
        }

        public string Type
        {
            get { return _type; }
        }

        public string Size
        {
            get { return _size; }
        }

        public string Inhabitants
        {
            get { return _inhabitants; }
        }

        public string Description
        {
            get { return _description; }
        }

        public Coordinates CoordinatesCellRadiusFromCenter
        {
            get { return _coordinatesCellRadiusFromCenter; }
        }

        public CommunityModel() { }

        public CommunityModel(Coordinates coordinatesCellRadiusFromCenter, string name, string type = "", string size = "", string inhabitants = "", string description = "")
            : this()
        {
            _coordinatesCellRadiusFromCenter = coordinatesCellRadiusFromCenter;
            _name = name;
            _type = type;
            _size = size;
            _inhabitants = inhabitants;
            _description = description;
        }

        public void ImportData(CommunityData data)
        {
            _name = data.Name;
            _type = data.Type;
            _size = data.Size;
            _inhabitants = data.Inhabitants;
            _description = data.Description;
            _coordinatesCellRadiusFromCenter = new Coordinates(
                data.CoordinatesCellRadiusFromCenterX,
                data.CoordinatesCellRadiusFromCenterY);
        }
    }
}
