using Controls.Library.Events;
using MyToolkit.Messaging;
using MyToolkit.Model;
using VersionBase.Libraries.Hexes;

namespace Controls.Library.Models
{
    public class HexModel : ObservableObject
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
            set { _tileColorModel = value; RaisePropertyChanged("TileColorModel"); }
        }

        public TileImageTypeModel TileImageTypeModel
        {
            get { return _tileImageTypeModel; }
            set { _tileImageTypeModel = value; RaisePropertyChanged("TileImageTypeModel"); }
        }

        public HexModel() { }

        public HexModel(HexData hexData)
        {
            _text = hexData.Text;
            _column = hexData.Column;
            _row = hexData.Row;
            _tileColorModel = new TileColorModel(hexData.TileData.TileColor);
            _tileImageTypeModel = new TileImageTypeModel(hexData.TileData.TileImageType);
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HexModel_PropertyChanged);
        }

        void HexModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var ttt = this;
            // Broadcast Events
            Messenger.Default.Send(
                new HexModelUpdatedMessage
                {
                    HexModel = (HexModel) sender
                });
            /*HexModel hexModel = (HexModel) sender;
            if (e.PropertyName == "TileColorModel" || e.PropertyName == "TileImageTypeModel")
            {
                var selectedHexViewModel = HexMapViewModel.GetHexViewModel(hexModel.Column, hexModel.Row);
                selectedHexViewModel.UpdateTileData(hexModel.TileColorModel.GetDrawingColor(), hexModel.TileImageTypeModel.GetBitmap());
            }*/
        }
    }
}
