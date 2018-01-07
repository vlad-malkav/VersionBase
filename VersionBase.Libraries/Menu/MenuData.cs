using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionBase.Libraries.Menu
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
