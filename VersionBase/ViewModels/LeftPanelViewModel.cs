using System.Collections.Generic;
using System.Linq;
using VersionBase.Events;
using VersionBase.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace VersionBase.ViewModels
{
    public class LeftPanelViewModel : ViewModel<LeftPanelModel>
    {
        public List<GameModeViewModel> ListGameModeViewModel { get; set; }

        private GameModeViewModel _selectedGameModeViewModel;
        public GameModeViewModel SelectedGameModeViewModel
        {
            get { return _selectedGameModeViewModel; }
            set { _selectedGameModeViewModel = value;
                RaisePropertyChanged("SelectedGameModeViewModel");
                Messenger.Default.Send(new UpdateGameModeMessage
                {
                    GameMode = _selectedGameModeViewModel.GameMode
                });
            }
        }

        public TileEditorViewModel TileEditorViewModel { get; set; }

        public LeftPanelViewModel()
        {
            TileEditorViewModel = new TileEditorViewModel();
            ListGameModeViewModel= new List<GameModeViewModel>();
        }

        public override void ApplyModel(LeftPanelModel model)
        {
            TileEditorViewModel.ApplyModel(model.TileEditorModel);
            ListGameModeViewModel.Clear();
            foreach (var gameModeModel in model.ListGameModeModel)
            {
                GameModeViewModel gameModeViewModel = new GameModeViewModel();
                gameModeViewModel.ApplyModel(gameModeModel);
                ListGameModeViewModel.Add(gameModeViewModel);
            }
            if (ListGameModeViewModel.Count > 0)
            {
                SelectedGameModeViewModel = ListGameModeViewModel.First();
            }
        }
    }
}