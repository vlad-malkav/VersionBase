using System;
using System.Threading.Tasks;
using Controls.Library.Annotations;
using Controls.Library.Events;
using Controls.Library.Models;
using Controls.Library.ViewModels;
using MyToolkit.Messaging;
using VersionBase.Data;
using VersionBase.Libraries.Enums;

namespace VersionBase.Logic
{
    public partial class GameLogic
    {
        public GameMode GameMode { get; set; }

        public GameLogic()
        {
            GameMode = GameMode.MapCreation;
            SubscribeToEvents();
        }

        #region General functions

        public void NewMap()
        {
            Messenger.Default.Send(new NewMessage());
        }

        public void LoadMap()
        {
            Messenger.Default.Send(new LoadMessage());
        }

        public void SaveMap()
        {
            Messenger.Default.Send(new SaveMessage());
        }

        public void QuitApplication()
        {
            Messenger.Default.Send(new QuitMessage());
        }

        public void UpdateGameMode(GameMode gameMode)
        {
            GameMode = gameMode;
        }

        #endregion General functions

        #region Clic functions

        public void LeftClicFunction(HexViewModel hexViewModel)
        {
            switch (GameMode)
            {
                case GameMode.MapCreation:
                    UpdateHexModelWithSelectedColorImage(hexViewModel.Column, hexViewModel.Row);
                    break;
                case GameMode.HexEdition:
                    SelectHex(hexViewModel.Column, hexViewModel.Row);
                    break;
                case GameMode.Visualization:
                    SelectHex(hexViewModel.Column, hexViewModel.Row);
                    break;
            }
        }

        public void RightClicFunction(HexViewModel hexViewModel)
        {
            switch (GameMode)
            {
                case GameMode.MapCreation:
                    SetSelectedColorImageFromHexPosition(hexViewModel.Column, hexViewModel.Row);
                    break;
                case GameMode.HexEdition:
                    break;
                case GameMode.Visualization:
                    break;
            }
        }

        #endregion Clic functions

        #region Tile Editor functions

        public async Task<Tuple<string, string>> GetSelectedTileColorTileImageIds()
        {
            GetSelectedColorImageIdsRequestMessage msgGetSelectedColorImageNamesRequestMessage = new GetSelectedColorImageIdsRequestMessage();
            var resultGetSelectedColorImageNamesRequestMessage = await Messenger.Default.SendAsync(msgGetSelectedColorImageNamesRequestMessage);

            return new Tuple<string, string>(
                resultGetSelectedColorImageNamesRequestMessage.Result.Item1,
                resultGetSelectedColorImageNamesRequestMessage.Result.Item2);
        }

        public async Task<Tuple<TileColorModel, TileImageModel>> GetSelectedTileColorTileImageModels()
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

        #endregion Tile Editor functions

        #region Hex Functions

        public async Task<HexModel> GetHexModelFromPosition(int column, int row)
        {
            GetHexModelFromPositionRequestMessage msgGetHexModelFromPositionRequestMessage = new GetHexModelFromPositionRequestMessage
            {
                Column = column,
                Row = row
            };
            var resultGetHexModelFromPositionRequestMessage = await Messenger.Default.SendAsync(msgGetHexModelFromPositionRequestMessage);
            return resultGetHexModelFromPositionRequestMessage.Result;
        }

        public async void UpdateHexModelWithSelectedColorImage(int column, int row)
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

        public void SelectHex(int column, int row)
        {
            Messenger.Default.Send(new SelectHexMessage
            {
                Column = column,
                Row = row
            });
        }

        public void SetSelectedColorImageFromHexPosition(int column, int row)
        {
            HexModel hexModel = GetHexModelFromPosition(column, row).Result;
            Messenger.Default.Send(new SetSelectedColorImageIdsRequestMessage
            {
                TileColorModelId = hexModel.TileColorModel.Id,
                TileImageModelId = hexModel.TileImageModel.Id
            });
        }

        #endregion Hex Functions

        #region General Map Modifications

        public void MapTransformation(MapTransformationType direction)
        {
            switch (direction)
            {
                case MapTransformationType.MoveLeft:
                    Messenger.Default.Send(new MapTransformationRequestMessage
                    {
                        XMovement = -100
                    });
                    break;
                case MapTransformationType.MoveRight:
                    Messenger.Default.Send(new MapTransformationRequestMessage
                    {
                        XMovement = 100
                    });
                    break;
                case MapTransformationType.MoveUp:
                    Messenger.Default.Send(new MapTransformationRequestMessage
                    {
                        YMovement = -100
                    });
                    break;
                case MapTransformationType.MoveDown:
                    Messenger.Default.Send(new MapTransformationRequestMessage
                    {
                        YMovement = 100
                    });
                    break;
                case MapTransformationType.ZoomIn:
                    Messenger.Default.Send(new MapTransformationRequestMessage
                    {
                        ZoomMultiplicator = 1.25
                    });
                    break;
                case MapTransformationType.ZoomOut:
                    Messenger.Default.Send(new MapTransformationRequestMessage
                    {
                        ZoomMultiplicator = 0.8
                    });
                    break;
                case MapTransformationType.Recenter:
                    Messenger.Default.Send(new MapTransformationRequestMessage
                    {
                        DoCenter = true
                    });
                    break;
            }
        }

        #endregion General Map Modifications
    }
}
