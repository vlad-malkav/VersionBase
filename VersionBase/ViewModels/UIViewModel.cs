using DataLibrary.Menu;
using VersionBase.Commands;
using VersionBase.Events;
using VersionBase.Models;
using VersionBase.ViewModels;
using MyToolkit.Messaging;
using VersionBase.Libraries.Enums;

namespace VersionBase.ViewModels
{
    public class UIViewModel : AbstractViewModel<UIModel>
    {
        public UITopMenuViewModel UITopMenuViewModel { get; set; }
        public UILeftPanelViewModel UILeftPanelViewModel { get; set; }
        public UIRightPanelViewModel UIRightPanelViewModel { get; set; }
        public UITopPanelViewModel UITopPanelViewModel { get; set; }
        public UIBottomPanelViewModel UIBottomPanelViewModel { get; set; }

        public UIViewModel()
        {
            UITopMenuViewModel = new UITopMenuViewModel();
            UILeftPanelViewModel = new UILeftPanelViewModel();
            UIRightPanelViewModel = new UIRightPanelViewModel();
            UITopPanelViewModel = new UITopPanelViewModel();
            UIBottomPanelViewModel = new UIBottomPanelViewModel();

            UIMenuModel menuModel = new UIMenuModel();
            menuModel.ImportData(InitializeMenuData());
            UITopMenuViewModel.ApplyModel(menuModel);
        }

        private UIMenuData InitializeMenuData()
        {
            UIMenuData menuData = new UIMenuData();

            UIMenuItemData menuFichier = new UIMenuItemData("Fichier");

            menuFichier.ListMenuItemData.Add(new UIMenuItemData("New", "New"));

            menuFichier.ListMenuItemData.Add(new UIMenuItemData("Load", "Load"));

            menuFichier.ListMenuItemData.Add(new UIMenuItemData("Save", "Save"));

            menuFichier.ListMenuItemData.Add(new UIMenuItemData("Quit", "Quit"));

            menuData.ListMenuItemData.Add(menuFichier);

            UIMenuItemData menuMove = new UIMenuItemData("Move");

            menuMove.ListMenuItemData.Add(new UIMenuItemData("MoveLeft", "MoveLeft"));

            menuMove.ListMenuItemData.Add(new UIMenuItemData("MoveRight", "MoveRight"));

            menuMove.ListMenuItemData.Add(new UIMenuItemData("MoveUp", "MoveUp"));

            menuMove.ListMenuItemData.Add(new UIMenuItemData("MoveDown", "MoveDown"));

            menuData.ListMenuItemData.Add(menuMove);

            UIMenuItemData menuZoom = new UIMenuItemData("Zoom");

            menuZoom.ListMenuItemData.Add(new UIMenuItemData("ZoomIn", "ZoomIn"));

            menuZoom.ListMenuItemData.Add(new UIMenuItemData("ZoomOut", "ZoomOut"));

            menuData.ListMenuItemData.Add(menuZoom);

            UIMenuItemData menuOptions = new UIMenuItemData("Options");

            menuOptions.ListMenuItemData.Add(new UIMenuItemData("Option1"));

            menuData.ListMenuItemData.Add(menuOptions);

            return menuData;
        }

        public override void ApplyModel(UIModel model)
        {
            UILeftPanelViewModel.ApplyModel(model.UILeftPanelModel);
            UIRightPanelViewModel.ApplyModel(model.UIRightPanelModel);
            UITopPanelViewModel.ApplyModel(model.UITopPanelModel);
            UIBottomPanelViewModel.ApplyModel(model.UIBottomPanelModel);
        }
    }
}
