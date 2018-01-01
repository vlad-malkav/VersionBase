using System.Collections.Generic;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class TopMenuViewModel : ViewModelBase
    {
        public string Header { get; set; }

        public List<MenuItemViewModel> ListMenuItemViewModel { get; set; }

        public TopMenuViewModel()
        {
            ListMenuItemViewModel = new List<MenuItemViewModel>();
        }

        public void ApplyModel()
        {
            Header = "head head";
            MenuItemViewModel menuFichier = new MenuItemViewModel("Fichier");
            menuFichier.ListMenuItemViewModel.Add(new MenuItemViewModel("New"));
            menuFichier.ListMenuItemViewModel.Add(new MenuItemViewModel("Load"));
            menuFichier.ListMenuItemViewModel.Add(new MenuItemViewModel("Save"));
            menuFichier.ListMenuItemViewModel.Add(new MenuItemViewModel("Quit"));
            ListMenuItemViewModel.Add(menuFichier);
            MenuItemViewModel menuMove = new MenuItemViewModel("Move");
            menuMove.ListMenuItemViewModel.Add(new MenuItemViewModel("GoLeft"));
            menuMove.ListMenuItemViewModel.Add(new MenuItemViewModel("GoRight"));
            menuMove.ListMenuItemViewModel.Add(new MenuItemViewModel("GoUp"));
            menuMove.ListMenuItemViewModel.Add(new MenuItemViewModel("GoDown"));
            ListMenuItemViewModel.Add(menuMove);
            MenuItemViewModel menuZoom = new MenuItemViewModel("Zoom");
            menuZoom.ListMenuItemViewModel.Add(new MenuItemViewModel("ZoomIn"));
            menuZoom.ListMenuItemViewModel.Add(new MenuItemViewModel("ZoomOut"));
            ListMenuItemViewModel.Add(menuZoom);
            MenuItemViewModel menuOptions = new MenuItemViewModel("Options");
            menuOptions.ListMenuItemViewModel.Add(new MenuItemViewModel("Option1"));
            ListMenuItemViewModel.Add(menuOptions);
        }
    }
}
