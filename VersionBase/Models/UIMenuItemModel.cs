using System.Collections.Generic;
using System.Windows.Input;
using DataLibrary.Menu;
using VersionBase.Commands;
using MyToolkit.Messaging;
using VersionBase.Events;

namespace VersionBase.Models
{
    public class UIMenuItemModel : IModel<UIMenuItemData>
    {
        public string Header { get; set; }
        public List<UIMenuItemModel> ListMenuItemModel { get; set; }
        public ICommand Command { get; set; }

        public UIMenuItemModel()
        {
            ListMenuItemModel = new List<UIMenuItemModel>();
        }

        public void ImportData(UIMenuItemData data)
        {
            Header = data.Header;

            Command = new MyICommand(() => Messenger.Default.Send(new MenuItemClickedMessage(data.AssociatedActionName)));

            foreach (UIMenuItemData menuItemData in data.ListMenuItemData)
            {
                UIMenuItemModel menuItemModel = new UIMenuItemModel();
                menuItemModel.ImportData(menuItemData);
                ListMenuItemModel.Add(menuItemModel);
            }
        }
    }
}
