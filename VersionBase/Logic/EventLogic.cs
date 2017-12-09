using System;
using System.Threading.Tasks;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;

namespace VersionBase.Logic
{
    public class EventLogic
    {
        public EventLogic()
        {
            
        }

        public void SubscribeToEvents()
        {
            // Subscribe to Events
            Messenger.Default.Register<HexClickedLeftButtonMessage>(this, HexClickedLeftButtonMessageFunction);
            Messenger.Default.Register<HexClickedRightButtonMessage>(this, HexClickedRightButtonMessageFunction);
            Messenger.Default.Register<MenuItemClickedMessage>(this, MenuItemClickedMessageFunction);
            
        }

        public static async void MenuItemClickedMessageFunction(MenuItemClickedMessage msgMenuItemClickedMessage)
        {
            switch (msgMenuItemClickedMessage.Name)
            {
                case "New":
                    break;
                case "Load":
                    break;
                case "Save":
                    break;
                case "Quit":
                    break;
            }
        }

        public static async Task<Tuple<TileColorModel, TileImageTypeModel>> GetSelectedTileColorTileImageTypeModels()
        {
            GetSelectedColorImageIdsRequestMessage msgGetSelectedColorImageNamesRequestMessage = new GetSelectedColorImageIdsRequestMessage();
            var resultGetSelectedColorImageNamesRequestMessage = await Messenger.Default.SendAsync(msgGetSelectedColorImageNamesRequestMessage);
            string tileColorModelId = resultGetSelectedColorImageNamesRequestMessage.Result.Item1;
            string tileImageTypeModelId = resultGetSelectedColorImageNamesRequestMessage.Result.Item2;

            GetTileColorTileImageTypeModelsFromIdRequestMessage msgGetTileColorTileImageTypeModelsFromNameRequestMessage = new GetTileColorTileImageTypeModelsFromIdRequestMessage
            {
                TileColorModelId = tileColorModelId,
                TileImageTypeModelId = tileImageTypeModelId
            };
            var resultGetTileColorTileImageTypeModelsFromIdRequestMessage = await Messenger.Default.SendAsync(msgGetTileColorTileImageTypeModelsFromNameRequestMessage);

            return new Tuple<TileColorModel, TileImageTypeModel>(
                resultGetTileColorTileImageTypeModelsFromIdRequestMessage.Result.Item1,
                resultGetTileColorTileImageTypeModelsFromIdRequestMessage.Result.Item2);
        }

        public static async Task<HexModel> GetHexModelFromPosition(int column, int row)
        {
            GetHexModelFromPositionRequestMessage msgGetHexModelFromPositionRequestMessage = new GetHexModelFromPositionRequestMessage
            {
                Column = column,
                Row = row
            };
            var resultGetHexModelFromPositionRequestMessage = await Messenger.Default.SendAsync(msgGetHexModelFromPositionRequestMessage);
            return resultGetHexModelFromPositionRequestMessage.Result;
        }

        public static async void HexClickedLeftButtonMessageFunction(HexClickedLeftButtonMessage msg)
        {
            Tuple<TileColorModel, TileImageTypeModel> tupleColorImage = GetSelectedTileColorTileImageTypeModels().Result;
            HexModel hexModel = GetHexModelFromPosition(msg.Column, msg.Row).Result;

            hexModel.TileColorModel =
                tupleColorImage.Item1;
            hexModel.TileImageTypeModel = tupleColorImage.Item2;

            //TODO : définir le flow de modification de la DATA
            /*var selectedHexData = HexMapData.GetHexData(msgHexClickedLeftButtonMessage.Column, msgHexClickedLeftButtonMessage.Row);
            selectedHexData.TileData.TileColor = ListTileColor.FirstOrDefault(x => x.Id == tileColorModelId);
            selectedHexData.TileData.TileImageType = ListTileImageType.FirstOrDefault(x => x.ToString() == tileImageTypeModelId);*/
        }

        public static void SetSelectedColorImageFromHexPosition(int column, int row)
        {
            HexModel hexModel = GetHexModelFromPosition(column, row).Result;
            SetSelectedColorImageIdsRequestMessage msgSetSelectedColorImageIdsRequestMessage = new SetSelectedColorImageIdsRequestMessage
            {
                TileColorModelId = hexModel.TileColorModel.Id,
                TileImageTypeModelId = hexModel.TileImageTypeModel.Id
            };
            Messenger.Default.Send(msgSetSelectedColorImageIdsRequestMessage);
        }

        //public static void SaveHexMapData

        public static void HexClickedRightButtonMessageFunction(HexClickedRightButtonMessage msg)
        {
            SetSelectedColorImageFromHexPosition(msg.Column, msg.Row);

            /*XmlSerializer xs = new XmlSerializer(typeof(HexMapData));
            TextWriter tw = new StreamWriter(Environment.CurrentDirectory+"\\garage.xml");
            xs.Serialize(tw, HexMapData);*/
        }
    }
}
