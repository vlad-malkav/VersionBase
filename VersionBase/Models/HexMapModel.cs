using System.Collections.Generic;
using System.Linq;
using DataLibrary.General;
using VersionBase.Events;
using MyToolkit.Messaging;
using VersionBase.Forms;
using VersionBase.Libraries.Drawing;

namespace VersionBase.Models
{
    public class HexMapModel : IModel<HexMapData>
    {
        private int _columns;
        private int _rows;
        private List<HexModel> _listHexModel;
        private List<CommunityModel> _listCommunityModel;

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

        public List<CommunityModel> ListCommunityModel
        {
            get { return _listCommunityModel; }
        }

        private bool MessageRegistered { get; set; }

        public HexMapModel()
        {
            UnregisterMessages();
            _listHexModel = new List<HexModel>();
            _listCommunityModel = new List<CommunityModel>();
            RegisterMessages();
        }

        public void ImportData(HexMapData data)
        {
            _columns = data.Columns;
            _rows = data.Rows;
            _listHexModel.Clear();
            foreach (var hexData in data.ListHexData)
            {
                HexModel hexModelTmp = new HexModel();
                hexModelTmp.ImportData(hexData);
                _listHexModel.Add(hexModelTmp);
            }
            _listCommunityModel.Clear();
            foreach (var communityData in data.ListCommunityData)
            {
                CommunityModel communityModel = new CommunityModel();
                communityModel.ImportData(communityData);
                _listCommunityModel.Add(communityModel);
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
                Messenger.Default.Deregister<AddPointMessage>(this, AddPointMessageFunction);
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
                Messenger.Default.Register<AddPointMessage>(this, AddPointMessageFunction);
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

        public async void AddPointMessageFunction(AddPointMessage msg)
        {
            System.Windows.Point closerPoint = msg.HexViewModel.HexDrawingData.GetCloserPointToPoint(msg.Point);
            //
            GetHexMapCenterPointMessage msgGetHexMapCenterPointMessage = new GetHexMapCenterPointMessage();
            var resultGetHexMapCenterPointMessage = await Messenger.Default.SendAsync(msgGetHexMapCenterPointMessage);

            Coordinates coordinates = new Coordinates(closerPoint.X, closerPoint.Y);
            Coordinates coordinatesFromCenter = new Coordinates(
                closerPoint.X - resultGetHexMapCenterPointMessage.Result.X,
                closerPoint.Y - resultGetHexMapCenterPointMessage.Result.Y);

            CommunityCreationInputDialog dialog = new CommunityCreationInputDialog(coordinates, coordinatesFromCenter, msg.HexViewModel.HexDrawingData.CellRadius);

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CommunityModel communityModel = dialog.Result.Item1;
                ListCommunityModel.Add(communityModel);
                CommunityCreatedMessage communityCreatedMessage = new CommunityCreatedMessage(communityModel);
                Messenger.Default.Send(communityCreatedMessage);
                /*dialog.Result.GenerateShapes();
                ListUIElement.Add(dialog.Result.CommunityDot);
                ListUIElement.Add(dialog.Result.CommunityLabel);
                ListCommunityViewModel.Add(dialog.Result);*/

                /*Ellipse childCtrl1 = new Ellipse();

                childCtrl1.Name = "Ellipse1";
                childCtrl1.StrokeThickness = 5;
                childCtrl1.Stroke = Brushes.Red;
                childCtrl1.Fill = Brushes.DarkRed;
                childCtrl1.Width = 10;
                childCtrl1.Height = 10;

                Canvas.SetTop(childCtrl1, msg.Point.Y - (childCtrl1.Height / 2));
                Canvas.SetLeft(childCtrl1, msg.Point.X - (childCtrl1.Width / 2));

                ListUIElement.Add(childCtrl1);*/
            }
        }
    }
}
