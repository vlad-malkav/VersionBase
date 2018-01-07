using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Libraries.Menu;

namespace Controls.Library.Models
{
    public class MenuModel : Model<MenuData>
    {
        public List<MenuItemModel> ListMenuItemModel { get; set; }

        public MenuModel()
        {
            ListMenuItemModel=new List<MenuItemModel>();
        }

        public override void ImportData(MenuData data)
        {
            foreach (MenuItemData menuItemData in data.ListMenuItemData)
            {
                MenuItemModel menuItemModel = new MenuItemModel();
                menuItemModel.ImportData(menuItemData);
                ListMenuItemModel.Add(menuItemModel);
            }
        }
    }
}
