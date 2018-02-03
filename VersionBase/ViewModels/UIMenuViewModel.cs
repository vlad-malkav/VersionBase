using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Models;

namespace VersionBase.ViewModels
{
    public class UIMenuViewModel : AbstractViewModel<UIMenuModel>
    {
        public List<UIMenuItemViewModel> ListMenuItemViewModel { get; set; }

        public UIMenuViewModel()
        {
            ListMenuItemViewModel=new List<UIMenuItemViewModel>();
        }

        public  override void ApplyModel(UIMenuModel model)
        {
            foreach (UIMenuItemModel menuItemModel in model.ListMenuItemModel)
            {
                UIMenuItemViewModel menuItemViewModel = new UIMenuItemViewModel();
                menuItemViewModel.ApplyModel(menuItemModel);
                ListMenuItemViewModel.Add(menuItemViewModel);
            }
        }
    }
}
