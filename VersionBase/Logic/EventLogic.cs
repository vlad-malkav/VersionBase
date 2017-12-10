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

        #region Message functions

        public static void MenuItemClickedMessageFunction(MenuItemClickedMessage msgMenuItemClickedMessage)
        {
            switch (msgMenuItemClickedMessage.Name)
            {
                case "New":
                    break;
                case "Load":
                    LoadMessage msgLoadMessage = new LoadMessage();
                    Messenger.Default.Send(msgLoadMessage);
                    break;
                case "Save":
                    SaveMessage msgSaveMessage = new SaveMessage();
                    Messenger.Default.Send(msgSaveMessage);
                    break;
                case "Quit":
                    QuitMessage msgQuitMessage = new QuitMessage();
                    Messenger.Default.Send(msgQuitMessage);
                    break;
            }
        }

        public static void HexClickedRightButtonMessageFunction(HexClickedRightButtonMessage msg)
        {
            GameLogic.SetSelectedColorImageFromHexPosition(msg.Column, msg.Row);
        }

        public static void HexClickedLeftButtonMessageFunction(HexClickedLeftButtonMessage msg)
        {
            GameLogic.UpdateHexModelWithSelectedColorImage(msg.Column, msg.Row);
        }

        #endregion
    }
}
