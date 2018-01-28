using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Menu;

namespace VersionBase.Models
{
    public class UIMenuModel : AbstractModel<MenuData>
    {
        public List<UIMenuItemModel> ListMenuItemModel { get; set; }

        public UIMenuModel()
        {
            ListMenuItemModel=new List<UIMenuItemModel>();
        }

        public override void ImportData(MenuData data)
        {
            foreach (MenuItemData menuItemData in data.ListMenuItemData)
            {
                UIMenuItemModel menuItemModel = new UIMenuItemModel();
                menuItemModel.ImportData(menuItemData);
                ListMenuItemModel.Add(menuItemModel);
            }
        }
    }
}
