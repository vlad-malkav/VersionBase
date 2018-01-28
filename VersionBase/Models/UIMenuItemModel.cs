using System.Collections.Generic;
using System.Windows.Input;
using DataLibrary.Menu;

namespace VersionBase.Models
{
    public class UIMenuItemModel : AbstractModel<MenuItemData>
    {
        public string Header { get; set; }
        public List<UIMenuItemModel> ListMenuItemModel { get; set; }
        public ICommand Command { get; set; }

        public UIMenuItemModel()
        {
            ListMenuItemModel = new List<UIMenuItemModel>();
        }

        public override void ImportData(MenuItemData data)
        {
            Header = data.Header;
            Command = data.Command;
            foreach (MenuItemData menuItemData in data.ListMenuItemData)
            {
                UIMenuItemModel menuItemModel = new UIMenuItemModel();
                menuItemModel.ImportData(menuItemData);
                ListMenuItemModel.Add(menuItemModel);
            }
        }
    }
}
