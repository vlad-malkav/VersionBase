using System.Windows.Media.Imaging;
using Controls.Library.Models;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class TileImageViewModel : ViewModel<TileImageModel>
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

        public override void ApplyModel(TileImageModel model)
        {
            _id = model.Id;
            Name = model.Name;
            NameLower = model.ImageName;
            Bitmap = model.BitmapImage;
        }
    }
}
