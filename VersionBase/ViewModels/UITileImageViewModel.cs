using System.Windows.Media;
using System.Windows.Media.Imaging;
using MyToolkit.Messaging;
using VersionBase.Models;
using MyToolkit.Mvvm;
using VersionBase.Events;
using VersionBase.Libraries.Drawing;
using Color = System.Drawing.Color;

namespace VersionBase.ViewModels
{
    public class UITileImageViewModel : AbstractViewModel<TileImageModel>
    {
        private string _id;

        public string Id
        {
            get { return _id; }
        }

        public string Name { get; set; }
        public string NameLower { get; set; }
        public ImageSource ImageSource { get; set; }

        public UITileImageViewModel() { }

        public override async void ApplyModel(TileImageModel model)
        {
            _id = model.Id;
            Name = model.Name;
            NameLower = model.ImageName;
            GetBitmapByNameMessage msg = new GetBitmapByNameMessage(model.ImageName);
            var result = await Messenger.Default.SendAsync(msg);
            ImageSource = HexMapDrawingHelper.GenerateTileImageSource(Color.LightGreen, result.Result);
        }
    }
}
