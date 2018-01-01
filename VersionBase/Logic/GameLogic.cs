using System;
using System.Threading.Tasks;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;

namespace VersionBase.Logic
{
    public class GameLogic
    {
        public EventLogic EventLogic { get; set; }

        public GameLogic()
        {
            EventLogic = new EventLogic(this);
            EventLogic.SubscribeToEvents();
        }

        #region Game functions

        public static async Task<Tuple<string, string>> GetSelectedTileColorTileImageIds()
        {
            GetSelectedColorImageIdsRequestMessage msgGetSelectedColorImageNamesRequestMessage = new GetSelectedColorImageIdsRequestMessage();
            var resultGetSelectedColorImageNamesRequestMessage = await Messenger.Default.SendAsync(msgGetSelectedColorImageNamesRequestMessage);

            return new Tuple<string, string>(
                resultGetSelectedColorImageNamesRequestMessage.Result.Item1,
                resultGetSelectedColorImageNamesRequestMessage.Result.Item2);
        }

        public static async Task<Tuple<TileColorModel, TileImageModel>> GetSelectedTileColorTileImageModels()
        {
            Tuple<string, string> tupleSelectedTileColorTileImageIds = GetSelectedTileColorTileImageIds().Result;
            string tileColorModelId = tupleSelectedTileColorTileImageIds.Item1;
            string tileImageTypeModelId = tupleSelectedTileColorTileImageIds.Item2;

            GetTileColorTileImageModelsFromIdRequestMessage msg
                = new GetTileColorTileImageModelsFromIdRequestMessage
                {
                    TileColorModelId = tileColorModelId,
                    TileImageModelId = tileImageTypeModelId
                };
            var resultGetTileColorTileImageModelsFromIdRequestMessage = await Messenger.Default.SendAsync(msg);

            return new Tuple<TileColorModel, TileImageModel>(
                resultGetTileColorTileImageModelsFromIdRequestMessage.Result.Item1,
                resultGetTileColorTileImageModelsFromIdRequestMessage.Result.Item2);
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

        public static async void UpdateHexModelWithSelectedColorImage(int column, int row)
        {
            Tuple<TileColorModel, TileImageModel> tupleColorImageIds = await GetSelectedTileColorTileImageModels();
            Messenger.Default.Send(new UpdateHexColorImageModelsMessage
            {
                Column = column,
                Row = row,
                TileColorModel = tupleColorImageIds.Item1,
                TileImageModel = tupleColorImageIds.Item2
            });
        }

        public static void SelectHex(int column, int row)
        {
            HexModel hexModel = GetHexModelFromPosition(column, row).Result;
            Messenger.Default.Send(new SelectHexMessage
            {
                Column = column,
                Row = row
            });
        }

        public static void SetSelectedColorImageFromHexPosition(int column, int row)
        {
            HexModel hexModel = GetHexModelFromPosition(column, row).Result;
            Messenger.Default.Send(new SetSelectedColorImageIdsRequestMessage
            {
                TileColorModelId = hexModel.TileColorModel.Id,
                TileImageModelId = hexModel.TileImageModel.Id
            });
        }

        #endregion
    }
}
