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
        private TileImageTypeModel _tileImageTypeModel;
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

        public TileImageTypeModel TileImageTypeModel
        {
            get { return _tileImageTypeModel; }
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
            _tileImageTypeModel = new TileImageTypeModel(hexData.TileData.TileImageType);
        }

        public void UpdateColorImageTypeModels(TileColorModel tileColorModel, TileImageTypeModel tileImageTypeModel)
        {
            _tileColorModel = tileColorModel;
            _tileImageTypeModel = tileImageTypeModel;

            Messenger.Default.Send(
                new HexModelUpdatedMessage
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
