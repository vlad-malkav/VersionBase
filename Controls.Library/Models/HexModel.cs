using Controls.Library.Events;
using MyToolkit.Messaging;
using VersionBase.Libraries.Hexes;

namespace Controls.Library.Models
{
    public class HexModel : Model<HexData>
    {
        private int _column;
        private int _row;
        private bool _selected;
        private TileColorModel _tileColorModel;
        private TileImageModel _tileImageModel;
        private string _description;
        private int _degreExploration;
        
        public int Column
        {
            get { return _column; }
        }

        public int Row
        {
            get { return _row; }
        }

        public bool Selected
        {
            get { return _selected; }
        }

        public TileColorModel TileColorModel
        {
            get { return _tileColorModel; }
        }

        public TileImageModel TileImageModel
        {
            get { return _tileImageModel; }
        }

        public string Description
        {
            get { return _description; }
        }

        public int DegreExploration
        {
            get { return _degreExploration; }
        }

        public HexModel() { }

        public override void ImportData(HexData data)
        {
            _description = data.Description;
            _degreExploration = data.DegreExploration;
            _column = data.Column;
            _row = data.Row;
            _tileColorModel = new TileColorModel();
            _tileColorModel.ImportData(data.TileData.TileColorData);
            _tileImageModel = new TileImageModel();
            _tileImageModel.ImportData(data.TileData.TileImageData);
        }

        public void UpdateColorImageModels(TileColorModel tileColorModel, TileImageModel tileImageModel)
        {
            _tileColorModel = tileColorModel;
            _tileImageModel = tileImageModel;

            Messenger.Default.Send(
                new HexTileUpdatedMessage
                {
                    HexModel = this
                });
        }

        public void UpdateDescriptionDegreExploration(string description, int degreExploration)
        {
            _description = description;
            _degreExploration = degreExploration;

            Messenger.Default.Send(
                new HexDegreExplorationUpdatedMessage
                {
                    HexModel = this
                });
        }

        public void SelectHex()
        {
            if (!_selected)
            {
                _selected = true;
                Messenger.Default.Send(
                    new HexModelSelectedMessage
                    {
                        HexModel = this
                    });
            }
        }

        public void UnselectHex()
        {
            if (_selected)
            {
                _selected = false;
                Messenger.Default.Send(
                    new HexModelUnselectedMessage
                    {
                        HexModel = this
                    });
            }
        }

        public string GetLabel()
        {
            return Column + "-" + Row;
        }
    }
}
