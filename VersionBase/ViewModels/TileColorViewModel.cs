using System.Windows.Media;
using VersionBase.Models;
using MyToolkit.Mvvm;

namespace VersionBase.ViewModels
{
    public class TileColorViewModel : ViewModel<TileColorModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Brush ColorBrush { get; set; }

        public TileColorViewModel() { }

        public override void ApplyModel(TileColorModel model)
        {
            Id = model.Id;
            Name = model.Name;
            ColorBrush = new SolidColorBrush(model.GetMediaColor());
        }
    }
}
