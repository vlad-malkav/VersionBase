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
            Messenger.Default.Register<MenuItemClickedMessage>(this, MenuItemClickedMessageFunction);
            Messenger.Default.Register<UpdateGameModeMessage>(this, UpdateGameModeMessageFunction);

        }

        #region Message functions

        public void UpdateGameModeMessageFunction(UpdateGameModeMessage msg)
        {
            UpdateGameMode(msg.GameMode);
        }

        public void MenuItemClickedMessageFunction(MenuItemClickedMessage msg)
        {
            switch (msg.Name)
            {
                case "New":
                    NewMap();
                    break;
                case "Load":
                    LoadMap();
                    break;
                case "Save":
                    SaveMap();
                    break;
                case "Quit":
                    QuitApplication();
                    break;
                case "GoLeft":
                    MapTransformation(MapTransformationType.MoveLeft);
                    break;
                case "GoRight":
                    MapTransformation(MapTransformationType.MoveRight);
                    break;
                case "GoUp":
                    MapTransformation(MapTransformationType.MoveUp);
                    break;
                case "GoDown":
                    MapTransformation(MapTransformationType.MoveDown);
                    break;
                case "ZoomIn":
                    MapTransformation(MapTransformationType.ZoomIn);
                    break;
                case "ZoomOut":
                    MapTransformation(MapTransformationType.ZoomOut);
                    break;
            }
        }

        public void HexClickedRightButtonMessageFunction(HexClickedRightButtonMessage msg)
        {
            RightClicFunction(msg.HexViewModel);
        }

        public void HexClickedLeftButtonMessageFunction(HexClickedLeftButtonMessage msg)
        {
            LeftClicFunction(msg.HexViewModel);
        }

        #endregion
    }
}
