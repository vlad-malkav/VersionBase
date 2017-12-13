using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Controls.Library.Events;
using MyToolkit.Messaging;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class HexMapModel
    {
        private int _columns;
        private int _rows;
        private List<HexModel> _listHexModel;

        public int Columns
        {
            get { return _columns; }
        }

        public int Rows
        {
            get { return _rows; }
        }

        public List<HexModel> ListHexModel
        {
            get { return _listHexModel; }
        }

        public HexMapModel()
        {
            _listHexModel = new List<HexModel>();
        }

        public void ImportData(HexMapData hexMapData)
        {
            Messenger.Default.Deregister<UpdateHexColorImageModels>(this, UpdateHexColorImageModelsFunction);
            Messenger.Default.Deregister<GetHexModelFromPositionRequestMessage>(this, GetHexModelFromPositionRequestMessageFunction);
            _columns = hexMapData.Columns;
            _rows = hexMapData.Rows;
            _listHexModel.Clear();
            foreach (var hexData in hexMapData.ListHexData)
            {
                _listHexModel.Add(new HexModel(hexData));
            }
            Messenger.Default.Register<GetHexModelFromPositionRequestMessage>(this, GetHexModelFromPositionRequestMessageFunction);
            Messenger.Default.Register<UpdateHexColorImageModels>(this, UpdateHexColorImageModelsFunction);
        }

        public HexModel GetHexModel(int column, int row)
        {
            return ListHexModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }

        public void UpdateHexModel(int column, int row, TileColorModel tileColorModel, TileImageTypeModel tileImageTypeModel)
        {
            HexModel hexModel = GetHexModel(column, row);
            hexModel.UpdateColorImageTypeModels(tileColorModel, tileImageTypeModel);
        }

        private void GetHexModelFromPositionRequestMessageFunction(GetHexModelFromPositionRequestMessage msg)
        {
            msg.CallSuccessCallback(GetHexModel(msg.Column, msg.Row));
        }

        public void UpdateHexColorImageModelsFunction(UpdateHexColorImageModels msg)
        {
            UpdateColorImageModelsFromIds(
                msg.Column,
                msg.Row,
                msg.TileColorModel,
                msg.TileImageTypeModel);
        }

        public void UpdateColorImageModelsFromIds(int column, int row, TileColorModel tileColorModel, TileImageTypeModel tileImageTypeModel)
        {
            GetHexModel(column, row).UpdateColorImageTypeModels(
                tileColorModel,
                tileImageTypeModel);
        }
    }
}
