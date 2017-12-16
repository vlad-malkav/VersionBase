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
                    Messenger.Default.Send(new LoadMessage());
                    break;
                case "Save":
                    Messenger.Default.Send(new SaveMessage());
                    break;
                case "Quit":
                    Messenger.Default.Send(new QuitMessage());
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
