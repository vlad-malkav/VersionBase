using System.Collections.Generic;
using System.Windows.Input;
using Controls.Library.Commands;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class MenuItemViewModel : ViewModel<MenuItemModel>
    {
        public string Header { get; set; }
        public List<MenuItemViewModel> ListMenuItemViewModel { get; set; }
        public ICommand Command { get; set; }

        public MenuItemViewModel()
        {
            ListMenuItemViewModel = new List<MenuItemViewModel>();
        }

        public override void ApplyModel(MenuItemModel model)
        {
            Header = model.Header;
            Command = model.Command;
            foreach (MenuItemModel menuItemModel in model.ListMenuItemModel)
            {
                MenuItemViewModel menuItemViewModel = new MenuItemViewModel();
                menuItemViewModel.ApplyModel(menuItemModel);
                ListMenuItemViewModel.Add(menuItemViewModel);
            }
        }
    }
}
