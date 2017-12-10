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
            EventLogic = new EventLogic();
            EventLogic.SubscribeToEvents();
        }

        #region Game functions

        public static async Task<Tuple<string, string>> GetSelectedTileColorTileImageTypeIds()
        {
            GetSelectedColorImageIdsRequestMessage msgGetSelectedColorImageNamesRequestMessage = new GetSelectedColorImageIdsRequestMessage();
            var resultGetSelectedColorImageNamesRequestMessage = await Messenger.Default.SendAsync(msgGetSelectedColorImageNamesRequestMessage);

            return new Tuple<string, string>(
                resultGetSelectedColorImageNamesRequestMessage.Result.Item1,
                resultGetSelectedColorImageNamesRequestMessage.Result.Item2);
        }

        public static async Task<Tuple<TileColorModel, TileImageTypeModel>> GetSelectedTileColorTileImageTypeModels()
        {
            Tuple<string, string> tupleSelectedTileColorTileImageTypeIds = GetSelectedTileColorTileImageTypeIds().Result;
            string tileColorModelId = tupleSelectedTileColorTileImageTypeIds.Item1;
            string tileImageTypeModelId = tupleSelectedTileColorTileImageTypeIds.Item2;

            GetTileColorTileImageTypeModelsFromIdRequestMessage msgGetTileColorTileImageTypeModelsFromIdRequestMessage
                = new GetTileColorTileImageTypeModelsFromIdRequestMessage
                {
                    TileColorModelId = tileColorModelId,
                    TileImageTypeModelId = tileImageTypeModelId
                };
            var resultGetTileColorTileImageTypeModelsFromIdRequestMessage = await Messenger.Default.SendAsync(msgGetTileColorTileImageTypeModelsFromIdRequestMessage);

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

        public static async void UpdateHexModelWithSelectedColorImage(int column, int row)
        {
            Tuple<string, string> tupleColorImageIds = await GetSelectedTileColorTileImageTypeIds();
            UpdateColorImageModelsFromIdsMessage msgUpdateColorImageModelsFromIdsMessage = new UpdateColorImageModelsFromIdsMessage
            {
                Column = column,
                Row = row,
                TileColorModelId = tupleColorImageIds.Item1,
                TileImageTypeModelId = tupleColorImageIds.Item2
            };
            Messenger.Default.Send(msgUpdateColorImageModelsFromIdsMessage);
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

        #endregion
    }
}
