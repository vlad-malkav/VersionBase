using System.Windows.Media.Imaging;
using Controls.Library.Models;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class TileImageViewModel : ViewModelBase // from MyToolkit
    {
        private string _id;

        public string Id
        {
            get { return _id; }
        }

        public string Name { get; set; }
        public string NameLower { get; set; }
        public BitmapImage Bitmap { get; set; }

        public TileImageViewModel() { }

        public TileImageViewModel(TileImageModel tileImageModel)
        {
            _id = tileImageModel.Id;
            Name = tileImageModel.Name;
            NameLower = tileImageModel.NameLower;
            Bitmap = tileImageModel.BitmapImage;
        }
    }
}
