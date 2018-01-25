using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Models;

namespace VersionBase.ViewModels
{
    public class MenuViewModel : ViewModel<MenuModel>
    {
        public List<MenuItemViewModel> ListMenuItemViewModel { get; set; }

        public MenuViewModel()
        {
            ListMenuItemViewModel=new List<MenuItemViewModel>();
        }

        public override void ApplyModel(MenuModel model)
        {
            foreach (MenuItemModel menuItemModel in model.ListMenuItemModel)
            {
                MenuItemViewModel menuItemViewModel = new MenuItemViewModel();
                menuItemViewModel.ApplyModel(menuItemModel);
                ListMenuItemViewModel.Add(menuItemViewModel);
            }
        }
    }
}
