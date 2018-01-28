using System.Windows.Media;
using VersionBase.Models;
using MyToolkit.Mvvm;

namespace VersionBase.ViewModels
{
    public class UITileColorViewModel : AbstractViewModel<UITileColorModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Brush ColorBrush { get; set; }

        public UITileColorViewModel() { }

        public override void ApplyModel(UITileColorModel model)
        {
            Id = model.Id;
            Name = model.Name;
            ColorBrush = new SolidColorBrush(model.GetMediaColor());
        }
    }
}
