using System.Windows.Media.Imaging;
using VersionBase.Models;
using MyToolkit.Mvvm;

namespace VersionBase.ViewModels
{
    public class UITileImageViewModel : AbstractViewModel<UITileImageModel>
    {
        private string _id;

        public string Id
        {
            get { return _id; }
        }

        public string Name { get; set; }
        public string NameLower { get; set; }
        public BitmapImage Bitmap { get; set; }

        public UITileImageViewModel() { }

        public override void ApplyModel(UITileImageModel model)
        {
            _id = model.Id;
            Name = model.Name;
            NameLower = model.ImageName;
            Bitmap = model.BitmapImage;
        }
    }
}
