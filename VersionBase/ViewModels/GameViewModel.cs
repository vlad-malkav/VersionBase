using Controls.Library.Commands;
using Controls.Library.Events;
using Controls.Library.Models;
using Controls.Library.ViewModels;
using MyToolkit.Messaging;
using VersionBase.Libraries.Enums;
using VersionBase.Libraries.Menu;
using VersionBase.Model;

namespace VersionBase.ViewModels
{
    public class GameViewModel : ViewModel<GameModel>
    {
        public TopMenuViewModel TopMenuViewModel { get; set; }
        public HexMapViewModel HexMapViewModel { get; set; }
        public LeftPanelViewModel LeftPanelViewModel { get; set; }
        public RightPanelViewModel RightPanelViewModel { get; set; }
        public TopPanelViewModel TopPanelViewModel { get; set; }
        public BottomPanelViewModel BottomPanelViewModel { get; set; }

        public GameViewModel()
        {
            TopMenuViewModel = new TopMenuViewModel();
            HexMapViewModel = new HexMapViewModel();
            LeftPanelViewModel = new LeftPanelViewModel();
            RightPanelViewModel = new RightPanelViewModel();
            TopPanelViewModel = new TopPanelViewModel();
            BottomPanelViewModel = new BottomPanelViewModel();

            
            MenuModel menuModel = new MenuModel();
            menuModel.ImportData(InitializeMenuData());
            TopMenuViewModel.ApplyModel(menuModel);
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

        public override void ApplyModel(GameModel gameModel)
        {
            LeftPanelViewModel.ApplyModel(gameModel.LeftPanelModel);
            RightPanelViewModel.ApplyModel(gameModel.RightPanelModel);
            TopPanelViewModel.ApplyModel(gameModel.TopPanelModel);
            BottomPanelViewModel.ApplyModel(gameModel.BottomPanelModel);
            HexMapViewModel.ApplyModel(gameModel.HexMapModel);
        }
    }
}
