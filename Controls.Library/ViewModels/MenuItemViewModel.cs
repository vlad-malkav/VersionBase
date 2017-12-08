using System.Collections.Generic;
using System.Windows.Input;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
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
