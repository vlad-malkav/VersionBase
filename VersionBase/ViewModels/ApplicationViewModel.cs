using DataLibrary.Menu;
using VersionBase.Commands;
using VersionBase.Events;
using VersionBase.Models;
using VersionBase.ViewModels;
using MyToolkit.Messaging;
using VersionBase.Libraries.Enums;

namespace VersionBase.ViewModels
{
    public class ApplicationViewModel : AbstractViewModel<ApplicationModel>
    {
        public GameViewModel GameViewModel { get; set; }
        public UIViewModel UIViewModel { get; set; }

        public ApplicationViewModel()
        {
            GameViewModel = new GameViewModel();
            UIViewModel = new UIViewModel();
        }

        public override void ApplyModel(ApplicationModel applicationModel)
        {
            UIViewModel.ApplyModel(applicationModel.UIModel);
            GameViewModel.ApplyModel(applicationModel.GameModel);
        }
    }
}
