using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class LeftPanelModel
    {
        private TileEditorModel _tileEditorModel;

        public TileEditorModel TileEditorModel
        {
            get { return _tileEditorModel; }
        }

        public LeftPanelModel()
        {
            _tileEditorModel = new TileEditorModel();
        }

        public void ImportTileEditorData(List<TileColor> listTileColor, List<TileImageType> listTileImageType)
        {
            _tileEditorModel.ImportListTileColor(listTileColor);
            _tileEditorModel.ImportListTileImageType(listTileImageType);
        }
    }
}
