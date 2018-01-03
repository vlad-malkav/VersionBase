﻿using System.Collections.Generic;
using System.Linq;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class LeftPanelViewModel : ViewModelBase // from MyToolkit
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

        public void ApplyModel(LeftPanelModel leftPanelModel)
        {
            TileEditorViewModel.ApplyModel(leftPanelModel.TileEditorModel);
            ListGameModeViewModel.Clear();
            foreach (var gameModeModel in leftPanelModel.ListGameModeModel)
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