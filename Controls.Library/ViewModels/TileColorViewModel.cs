using System.Windows.Media;
using Controls.Library.Models;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
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
