using System.Collections.Generic;
using System.Windows.Input;
using VersionBase.Commands;
using VersionBase.Events;
using VersionBase.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace VersionBase.ViewModels
{
    public class UIMenuItemViewModel : AbstractViewModel<UIMenuItemModel>
    {
        public string Header { get; set; }
        public List<UIMenuItemViewModel> ListMenuItemViewModel { get; set; }
        public ICommand Command { get; set; }

        public UIMenuItemViewModel()
        {
            ListMenuItemViewModel = new List<UIMenuItemViewModel>();
        }

        public override void ApplyModel(UIMenuItemModel model)
        {
            Header = model.Header;
            Command = model.Command;
            foreach (UIMenuItemModel menuItemModel in model.ListMenuItemModel)
            {
                UIMenuItemViewModel menuItemViewModel = new UIMenuItemViewModel();
                menuItemViewModel.ApplyModel(menuItemModel);
                ListMenuItemViewModel.Add(menuItemViewModel);
            }
        }
    }
}
