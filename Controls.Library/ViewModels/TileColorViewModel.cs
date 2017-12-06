using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Controls.Library.Models;

namespace Controls.Library.ViewModels
{
    public class TileColorViewModel
    {
        public string Name { get; set; }
        public Brush ColorBrush { get; set; }

        public TileColorViewModel() { }

        public TileColorViewModel(TileColorModel tileColorModel)
        {
            Name = tileColorModel.Name;
            ColorBrush = new SolidColorBrush(tileColorModel.GetMediaColor());
        }
    }
}
