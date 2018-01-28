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

        private MenuData InitializeMenuData()
        {
            MenuData menuData = new MenuData();

            MenuItemData menuFichier = new MenuItemData("Fichier");

            menuFichier.ListMenuItemData.Add(new MenuItemData("New")
            {
                Command = new MyICommand(() => Messenger.Default.Send(new NewMessage()))
            });

            menuFichier.ListMenuItemData.Add(new MenuItemData("Load")
            {
                Command = new MyICommand(() => Messenger.Default.Send(new LoadMessage()))
            });

            menuFichier.ListMenuItemData.Add(new MenuItemData("Save")
            {
                Command = new MyICommand(() => Messenger.Default.Send(new SaveMessage()))
            });

            menuFichier.ListMenuItemData.Add(new MenuItemData("Quit")
            {
                Command = new MyICommand(() => Messenger.Default.Send(new QuitMessage()))
            });

            menuData.ListMenuItemData.Add(menuFichier);

            MenuItemData menuMove = new MenuItemData("Move");

            menuMove.ListMenuItemData.Add(new MenuItemData("MoveLeft")
            {
                Command = new MyICommand(() =>
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveLeft)))
            });

            menuMove.ListMenuItemData.Add(new MenuItemData("MoveRight")
            {
                Command = new MyICommand(() =>
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveRight)))
            });

            menuMove.ListMenuItemData.Add(new MenuItemData("MoveUp")
            {
                Command = new MyICommand(() =>
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveUp)))
            });

            menuMove.ListMenuItemData.Add(new MenuItemData("MoveDown")
            {
                Command = new MyICommand(() =>
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveDown)))
            });
            menuData.ListMenuItemData.Add(menuMove);

            MenuItemData menuZoom = new MenuItemData("Zoom");

            menuZoom.ListMenuItemData.Add(new MenuItemData("ZoomIn")
            {
                Command = new MyICommand(() =>
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.ZoomIn)))
            });

            menuZoom.ListMenuItemData.Add(new MenuItemData("ZoomOut")
            {
                Command = new MyICommand(() =>
                    Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.ZoomOut)))
            });

            menuData.ListMenuItemData.Add(menuZoom);

            MenuItemData menuOptions = new MenuItemData("Options");

            menuOptions.ListMenuItemData.Add(new MenuItemData("Option1"));

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
