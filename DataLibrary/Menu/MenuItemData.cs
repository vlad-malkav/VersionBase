using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VersionBase.Libraries.Menu
{
    public class MenuItemData
    {
        public string Header { get; set; }
        public List<MenuItemData> ListMenuItemData { get; set; }
        public ICommand Command { get; set; }

        public MenuItemData()
        {
            ListMenuItemData = new List<MenuItemData>();
        }

        public MenuItemData(string header)
            :this()
        {
            Header = header;
        }
    }
}
