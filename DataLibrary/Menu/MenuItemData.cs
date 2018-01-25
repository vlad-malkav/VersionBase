using System.Collections.Generic;
using System.Windows.Input;

namespace DataLibrary.Menu
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
