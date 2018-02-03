using System.Collections.Generic;

namespace DataLibrary.Menu
{
    public class UIMenuData
    {
        public List<UIMenuItemData> ListMenuItemData { get; set; }

        public UIMenuData()
        {
            ListMenuItemData=new List<UIMenuItemData>();
        }
    }
}
