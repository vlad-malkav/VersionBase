using System.Drawing;
using System.Windows.Media.Imaging;
using DataLibrary.Tiles;
using VersionBase.Libraries.Drawing;

namespace VersionBase.Models
{
    public class TileImageModel : IModel<TileImageData>
    {
        private string _id;
        private string _name;
        private string _imageName;

        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string ImageName
        {
            get { return _imageName; }
        }

        public TileImageModel() { }

        public void ImportData(TileImageData data)
        {
            _id = data.Id;
            _imageName = data.ImageName;
            _name = data.Name;
        }
    }
}
