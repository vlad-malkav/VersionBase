using Controls.Library.Events;
using MyToolkit.Messaging;
using MyToolkit.Model;
using VersionBase.Libraries.Hexes;

namespace Controls.Library.Models
{
    public class HexModel
    {
        private string _text;
        private int _column;
        private int _row;
        private TileColorModel _tileColorModel;
        private TileImageTypeModel _tileImageTypeModel;

        public string Text
        {
            get { return _text; }
        }

        public int Column
        {
            get { return _column; }
        }

        public int Row
        {
            get { return _row; }
        }

        public TileColorModel TileColorModel
        {
            get { return _tileColorModel; }
            set { _tileColorModel = value;
                Messenger.Default.Send(
                new HexModelUpdatedMessage
                {
                    HexModel = this
                });
            }
        }

        public TileImageTypeModel TileImageTypeModel
        {
            get { return _tileImageTypeModel; }
            set { _tileImageTypeModel = value;
                Messenger.Default.Send(
                    new HexModelUpdatedMessage
                    {
                        HexModel = this
                    });
            }
        }

        public HexModel() { }

        public HexModel(HexData hexData)
        {
            _text = hexData.Text;
            _column = hexData.Column;
            _row = hexData.Row;
            _tileColorModel = new TileColorModel(hexData.TileData.TileColor);
            _tileImageTypeModel = new TileImageTypeModel(hexData.TileData.TileImageType);
        }
    }
}
