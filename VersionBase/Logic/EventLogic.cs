using Controls.Library.Events;
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

        #region Message functions

        public static void MenuItemClickedMessageFunction(MenuItemClickedMessage msgMenuItemClickedMessage)
        {
            switch (msgMenuItemClickedMessage.Name)
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
                case "GoLeft":
                    Messenger.Default.Send(new GeneralMapTransformationMessage
                    {
                        XMovement = -100
                    });
                    break;
                case "GoRight":
                    Messenger.Default.Send(new GeneralMapTransformationMessage
                    {
                        XMovement = 100
                    });
                    break;
                case "GoUp":
                    Messenger.Default.Send(new GeneralMapTransformationMessage
                    {
                        YMovement = -100
                    });
                    break;
                case "GoDown":
                    Messenger.Default.Send(new GeneralMapTransformationMessage
                    {
                        YMovement = 100
                    });
                    break;
                case "ZoomIn":
                    Messenger.Default.Send(new GeneralMapTransformationMessage
                    {
                        ZoomMultiplicator = 1.25
                    });
                    break;
                case "ZoomOut":
                    Messenger.Default.Send(new GeneralMapTransformationMessage
                    {
                        ZoomMultiplicator = 0.8
                    });
                    break;
            }
        }

        public static void HexClickedRightButtonMessageFunction(HexClickedRightButtonMessage msg)
        {
            GameLogic.SelectHex(msg.HexViewModel.Column, msg.HexViewModel.Row);
            GameLogic.SetSelectedColorImageFromHexPosition(msg.HexViewModel.Column, msg.HexViewModel.Row);
        }

        public static void HexClickedLeftButtonMessageFunction(HexClickedLeftButtonMessage msg)
        {
            GameLogic.UpdateHexModelWithSelectedColorImage(msg.HexViewModel.Column, msg.HexViewModel.Row);
        }

        #endregion
    }
}
