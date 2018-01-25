using System.Collections.Generic;
using System.Windows.Input;
using VersionBase.Commands;
using VersionBase.Events;
using VersionBase.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace VersionBase.ViewModels
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
