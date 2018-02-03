using System.Collections.Generic;
using System.Windows.Input;

namespace DataLibrary.Menu
{
    public class UIMenuItemData
    {
        public string Header { get; set; }
        public List<UIMenuItemData> ListMenuItemData { get; set; }
        public string AssociatedActionName { get; set; }

        public UIMenuItemData()
        {
            ListMenuItemData = new List<UIMenuItemData>();
        }

        public UIMenuItemData(string header, string associatedActionName = null)
            :this()
        {
            Header = header;
            AssociatedActionName = associatedActionName;
        }
    }
}
