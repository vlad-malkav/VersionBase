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

        private bool MessageRegistered { get; set; }

        public HexMapModel()
        {
            UnregisterMessages();
            _listHexModel = new List<HexModel>();
            RegisterMessages();
        }

        public void ImportData(HexMapData hexMapData)
        {
            _columns = hexMapData.Columns;
            _rows = hexMapData.Rows;
            _listHexModel.Clear();
            foreach (var hexData in hexMapData.ListHexData)
            {
                _listHexModel.Add(new HexModel(hexData));
            }
        }

        private void UnregisterMessages()
        {
            if (MessageRegistered)
            {
                Messenger.Default.Deregister<SelectHexMessage>(this, SelectHexMessageFunction);
                Messenger.Default.Deregister<GetHexModelFromPositionRequestMessage>(this, GetHexModelFromPositionRequestMessageFunction);
                Messenger.Default.Deregister<UpdateHexColorImageModelsMessage>(this, UpdateHexColorImageModelsFunction);
                Messenger.Default.Deregister<UpdateHexDescriptionDegreExplorationMessage>(this, UpdateHexDescriptionDegreExplorationMessageFunction);
                MessageRegistered = false;
            }
        }

        private void RegisterMessages()
        {
            if (!MessageRegistered)
            {
                Messenger.Default.Register<GetHexModelFromPositionRequestMessage>(this, GetHexModelFromPositionRequestMessageFunction);
                Messenger.Default.Register<UpdateHexColorImageModelsMessage>(this, UpdateHexColorImageModelsFunction);
                Messenger.Default.Register<SelectHexMessage>(this, SelectHexMessageFunction);
                Messenger.Default.Register<UpdateHexDescriptionDegreExplorationMessage>(this, UpdateHexDescriptionDegreExplorationMessageFunction);
                MessageRegistered = true;
            }
        }

        public HexModel GetHexModel(int column, int row)
        {
            return ListHexModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }

        public void UpdateHexModel(int column, int row, TileColorModel tileColorModel, TileImageModel tileImageModel)
        {
            HexModel hexModel = GetHexModel(column, row);
            hexModel.UpdateColorImageModels(tileColorModel, tileImageModel);
        }

        private void GetHexModelFromPositionRequestMessageFunction(GetHexModelFromPositionRequestMessage msg)
        {
            msg.CallSuccessCallback(GetHexModel(msg.Column, msg.Row));
        }

        private void SelectHexMessageFunction(SelectHexMessage msg)
        {
            HexModel nextSelectedHexModel = GetHexModel(msg.Column, msg.Row);
            HexModel previousSelectedHexModel = ListHexModel.FirstOrDefault(x => x.Selected);
            if (previousSelectedHexModel != null)
            {
                previousSelectedHexModel.UnselectHex();
                if (previousSelectedHexModel != nextSelectedHexModel)
                    nextSelectedHexModel.SelectHex();
            }
            else
            {
                nextSelectedHexModel.SelectHex();
            }
        }

        public void UpdateHexColorImageModelsFunction(UpdateHexColorImageModelsMessage msg)
        {
            UpdateColorImageModelsFromIds(
                msg.Column,
                msg.Row,
                msg.TileColorModel,
                msg.TileImageModel);
        }

        public void UpdateColorImageModelsFromIds(int column, int row, TileColorModel tileColorModel, TileImageModel tileImageModel)
        {
            GetHexModel(column, row).UpdateColorImageModels(
                tileColorModel,
                tileImageModel);
        }

        public void UpdateHexDescriptionDegreExplorationMessageFunction(
            UpdateHexDescriptionDegreExplorationMessage msg)
        {
            UpdateHexDescriptionDegreExploration(
                msg.Column,
                msg.Row,
                msg.Description,
                msg.DegreExploration);
        }

        public void UpdateHexDescriptionDegreExploration(int column, int row, string description, int degreExploration)
        {
            GetHexModel(column, row).UpdateDescriptionDegreExploration(
                description,
                degreExploration);
        }
    }
}
