using System.Windows.Media;
using Controls.Library.Models;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class TileColorViewModel : ViewModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Brush ColorBrush { get; set; }

        public TileColorViewModel() { }

        public TileColorViewModel(TileColorModel tileColorModel)
        {
            Id = tileColorModel.Id;
            Name = tileColorModel.Name;
            ColorBrush = new SolidColorBrush(tileColorModel.GetMediaColor());
        }
    }
}
