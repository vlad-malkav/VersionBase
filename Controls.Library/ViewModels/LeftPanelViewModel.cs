using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.Library.Models;
using VersionBase.Libraries.Hexes;

namespace Controls.Library.ViewModels
{
    public class LeftPanelViewModel
    {
        public TileEditorViewModel TileEditorViewModel { get; set; }

        public LeftPanelViewModel()
        {
            TileEditorViewModel = new TileEditorViewModel();
        }

        public void ApplyModel(LeftPanelModel leftPanelModel)
        {
            TileEditorViewModel.ApplyModel(leftPanelModel.TileEditorModel);
        }
    }
}
