using System;
using System.Windows.Media;
using Controls.Library.Events;
using MyToolkit.Messaging;
using MyToolkit.Model;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class HexModel
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

        public HexModel(HexData hexData)
        {
            _description = hexData.Description;
            _degreExploration = hexData.DegreExploration;
            _column = hexData.Column;
            _row = hexData.Row;
            _tileColorModel = new TileColorModel(hexData.TileData.TileColor);
            _tileImageModel = new TileImageModel(hexData.TileData.TileImage);
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
