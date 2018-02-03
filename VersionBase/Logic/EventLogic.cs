using VersionBase.Events;
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
            Messenger.Default.Register<MenuItemClickedMessage>(this, MenuItemClickedMessageFunction);
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

        public void MenuItemClickedMessageFunction(MenuItemClickedMessage msg)
        {
            switch (msg.AssociatedActionName)
            {
                case "New":
                    Messenger.Default.Send(new NewMessage());
                    break;
                case "Load":
                    Messenger.Default.Send(new LoadMessage());
                    break;
                case "Save":
                    Messenger.Default.Send(new SaveMessage());
                    break;
                case "Quit":
                    Messenger.Default.Send(new QuitMessage());
                    break;
                case "MoveLeft":
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveLeft));
                    break;
                case "MoveRight":
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveRight));
                    break;
                case "MoveUp":
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveUp));
                    break;
                case "MoveDown":
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveDown));
                    break;
                case "ZoomIn":
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.ZoomIn));
                    break;
                case "ZoomOut":
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.ZoomOut));
                    break;
            }
        }

        #endregion
    }
}
