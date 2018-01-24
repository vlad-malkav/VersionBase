using System.Collections.Generic;
using System.Windows.Input;
using VersionBase.Libraries.Menu;

namespace VersionBase.Models
{
    public class MenuItemModel : Model<MenuItemData>
    {
        public string Header { get; set; }
        public List<MenuItemModel> ListMenuItemModel { get; set; }
        public ICommand Command { get; set; }

        public MenuItemModel()
        {
            ListMenuItemModel = new List<MenuItemModel>();
        }

        public override void ImportData(MenuItemData data)
        {
            Header = data.Header;
            Command = data.Command;
            foreach (MenuItemData menuItemData in data.ListMenuItemData)
            {
                MenuItemModel menuItemModel = new MenuItemModel();
                menuItemModel.ImportData(menuItemData);
                ListMenuItemModel.Add(menuItemModel);
            }
        }
    }
}
