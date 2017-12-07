using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Controls.Library.ViewModels
{
    public class MenuItemViewModel
    {
        public string Text { get; set; }
        public List<MenuItemViewModel> Children { get; private set; }
        public ICommand Command { get; set; }

        public MenuItemViewModel(string item)
        {
            Text = item;
            Children = new List<MenuItemViewModel>();
        }
    }
}
