using System.Collections.Generic;

namespace DataLibrary.Menu
{
    public class MenuData
    {
        public List<MenuItemData> ListMenuItemData { get; set; }

        public MenuData()
        {
            ListMenuItemData=new List<MenuItemData>();
        }
    }
}
