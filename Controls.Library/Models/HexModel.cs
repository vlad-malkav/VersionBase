using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Shapes;
using Controls.Library.Annotations;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class HexModel : INotifyPropertyChanged
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
            set { _tileColorModel = value; OnPropertyChanged("TileColorModel"); }
        }

        public TileImageTypeModel TileImageTypeModel
        {
            get { return _tileImageTypeModel; }
            set { _tileImageTypeModel = value; OnPropertyChanged("TileImageTypeModel"); }
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
