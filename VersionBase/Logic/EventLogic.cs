using Controls.Library.Events;
using MyToolkit.Messaging;
using VersionBase.Data;
using VersionBase.Libraries.Enums;

namespace VersionBase.Logic
{
    public partial class GameLogic
    {

        public void SubscribeToEvents()
        {
            // Subscribe to Events
            Messenger.Default.Register<HexClickedLeftButtonMessage>(this, HexClickedLeftButtonMessageFunction);
            Messenger.Default.Register<HexClickedRightButtonMessage>(this, HexClickedRightButtonMessageFunction);
            Messenger.Default.Register<UpdateGameModeMessage>(this, UpdateGameModeMessageFunction);
            Messenger.Default.Register<MapTransformationTypeBroadcastMessage>(this, MapTransformationTypeBroadcastMessageFunction);

        }

        #region Message functions

        public void UpdateGameModeMessageFunction(UpdateGameModeMessage msg)
        {
            UpdateGameMode(msg.GameMode);
        }

        public void HexClickedRightButtonMessageFunction(HexClickedRightButtonMessage msg)
        {
            RightClicFunction(msg.HexViewModel);
        }

        public void HexClickedLeftButtonMessageFunction(HexClickedLeftButtonMessage msg)
        {
            LeftClicFunction(msg.HexViewModel);
        }

        public void MapTransformationTypeBroadcastMessageFunction(MapTransformationTypeBroadcastMessage msg)
        {
            MapTransformation(msg.MapTransformationType);
        }

        #endregion
    }
}
