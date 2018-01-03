﻿using System;
using System.Collections.Generic;
using System.Linq;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Command;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;
using VersionBase.Libraries.Enums;

namespace Controls.Library.ViewModels
{
    public class TileEditorViewModel : ViewModelBase // from MyToolkit
    {

        #region General Properties

        private bool _isHexSelected;

        public bool IsHexSelected
        {
            get { return _isHexSelected; }
            set
            {
                if (_isHexSelected != value)
                {
                    _isHexSelected = value;
                    RaisePropertyChanged("IsHexSelected");
                    RefreshInterfaceButtons();
                }
            }
        }

        private GameMode _gameMode;

        public GameMode GameMode
        {
            get { return _gameMode; }
            set
            {
                if (_gameMode != value)
                {
                    _gameMode = value;
                }
            }
        }

        #endregion General Properties

        #region Tile Editor Properties

        public List<TileImageViewModel> ListTileImageViewModel { get; set; }
        private TileImageViewModel _selectedTileImageModel;

        public TileImageViewModel SelectedTileImageViewModel
        {
            get { return _selectedTileImageModel; }
            set
            {
                if (_selectedTileImageModel != value)
                {
                    _selectedTileImageModel = value;
                    RaisePropertyChanged("SelectedTileImageViewModel");
                }
            }
        }

        public List<TileColorViewModel> ListTileColorViewModel { get; set; }
        private TileColorViewModel _selectedTileColorViewModel;

        public TileColorViewModel SelectedTileColorViewModel
        {
            get { return _selectedTileColorViewModel; }
            set
            {
                if (_selectedTileColorViewModel != value)
                {
                    _selectedTileColorViewModel = value;
                    RaisePropertyChanged("SelectedTileColorViewModel");
                }
            }
        }

        private bool _tileEditionAvailable;

        public bool TileEditionAvailable
        {
            get { return _tileEditionAvailable; }
            set
            {
                if (_tileEditionAvailable != value)
                {
                    _tileEditionAvailable = value;
                    RaisePropertyChanged("TileEditionAvailable");
                    RefreshInterfaceButtons();
                }
            }
        }

        #endregion Tile Editor Properties

        #region Hex Data

        private string _label;
        private string _description;
        private int _degreExploration;
        private string _selectedHexColor;
        private string _selectedHexImage;

        public string Label
        {
            get { return _label; }
            set
            {
                if (_label != value)
                {
                    _label = value;
                    RaisePropertyChanged("Label");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }

        public int DegreExploration
        {
            get { return _degreExploration; }
            set
            {
                if (_degreExploration != value)
                {
                    _degreExploration = value;
                    RaisePropertyChanged("DegreExploration");
                    RefreshInterfaceButtons();
                }
            }
        }

        public string SelectedHexColor
        {
            get { return _selectedHexColor; }
            set
            {
                if (_selectedHexColor != value)
                {
                    _selectedHexColor = value;
                    RaisePropertyChanged("SelectedHexColor");
                }
            }
        }

        public string SelectedHexImage
        {
            get { return _selectedHexImage; }
            set
            {
                if (_selectedHexImage != value)
                {
                    _selectedHexImage = value;
                    RaisePropertyChanged("SelectedHexImage");
                }
            }
        }

        private bool _hexEditionAvailable;

        public bool HexEditionAvailable
        {
            get { return _hexEditionAvailable; }
            set
            {
                if (_hexEditionAvailable != value)
                {
                    _hexEditionAvailable = value;
                    RaisePropertyChanged("HexEditionAvailable");
                    RefreshInterfaceButtons();
                }
            }
        }

        public int? SelectedHexColumn = null;
        public int? SelectedHexRow = null;

        #endregion

        public RelayCommand SaveButtonCommand { get; private set; }
        public RelayCommand DegreExplorationPlusCommand { get; private set; }
        public RelayCommand DegreExplorationMinusCommand { get; private set; }

        public TileEditorViewModel()
        {
            UnregisterMessages();
            IsHexSelected = false;
            ListTileColorViewModel = new List<TileColorViewModel>();
            ListTileImageViewModel = new List<TileImageViewModel>();
            SaveButtonCommand = new RelayCommand(
                () => SaveButtonAction(),
                () => SaveButtonAvailable());
            
                DegreExplorationPlusCommand = new RelayCommand(
                    () => DegreExploration++,
                    () => IsDegreExplorationPlusAvailable());
            
                DegreExplorationMinusCommand = new RelayCommand(
                    () => DegreExploration--,
                    () => IsDegreExplorationMinusAvailable());
            RegisterMessages();
        }

        public bool SaveButtonAvailable()
        {
            return HexEditionAvailable && IsHexSelected;
        }

        public bool IsDegreExplorationPlusAvailable()
        {
            return HexEditionAvailable && IsHexSelected && DegreExploration < 6;
        }

        public bool IsDegreExplorationMinusAvailable()
        {
            return HexEditionAvailable && IsHexSelected && DegreExploration > 0;
        }

        public void ApplyModel(TileEditorModel tileEditorModel)
        {
            UnselectHex();
            ListTileColorViewModel.Clear();
            foreach (var tileColorModel in tileEditorModel.ListTileColorModel)
            {
                ListTileColorViewModel.Add(new TileColorViewModel(tileColorModel));
            }
            SelectedTileColorViewModel = ListTileColorViewModel.First();
            ListTileImageViewModel.Clear();
            foreach (var tileImageModel in tileEditorModel.ListTileImageModel)
            {
                ListTileImageViewModel.Add(new TileImageViewModel(tileImageModel));
            }
            SelectedTileImageViewModel = ListTileImageViewModel.First();
        }

        public void SaveButtonAction()
        {
            if (SelectedHexColumn != null && SelectedHexRow != null)
            {
                Messenger.Default.Send(
                    new UpdateHexDescriptionDegreExplorationMessage
                    {
                        Column = SelectedHexColumn.Value,
                        Row = SelectedHexRow.Value,
                        Description = Description,
                        DegreExploration = DegreExploration
                    });
            }
        }

        private void SelectHex(HexModel hexModel)
        {
            Label = hexModel.GetLabel();
            Description = hexModel.Description;
            DegreExploration = hexModel.DegreExploration;
            SelectedHexColumn = hexModel.Column;
            SelectedHexRow = hexModel.Row;
            SelectedHexColor = hexModel.TileColorModel.Name;
            SelectedHexImage = hexModel.TileImageModel.Name;
            IsHexSelected = true;
        }

        private void UnselectHex()
        {
            Label = "";
            Description = "";
            DegreExploration = 0;
            SelectedHexColor = "";
            SelectedHexImage = "";
            SelectedHexColumn = null;
            SelectedHexRow = null;
            IsHexSelected = false;
        }

        public TileColorViewModel GetTileColorViewModelFromId(string id)
        {
            return ListTileColorViewModel.FirstOrDefault(x => x.Id == id);
        }

        public TileImageViewModel GetTileImageViewModelFromId(string id)
        {
            return ListTileImageViewModel.FirstOrDefault(x => x.Id == id);
        }

        public void RefreshInterfaceButtons()
        {
            if (SaveButtonCommand != null) SaveButtonCommand.RaiseCanExecuteChanged();
            if (DegreExplorationMinusCommand != null) DegreExplorationMinusCommand.RaiseCanExecuteChanged();
            if (DegreExplorationPlusCommand != null) DegreExplorationPlusCommand.RaiseCanExecuteChanged();
        }

        public void OnHexSelected()
        {
            switch (GameMode)
            {
                case GameMode.MapCreation:
                    HexEditionAvailable = false;
                    break;
                case GameMode.HexEdition:
                    HexEditionAvailable = true;
                    break;
                case GameMode.Visualization:
                    HexEditionAvailable = false;
                    break;
            }
        }

        #region Event functions

        private void UnregisterMessages()
        {
            Messenger.Default.Deregister<GetSelectedColorImageIdsRequestMessage>(this, GetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Deregister<SetSelectedColorImageIdsRequestMessage>(this, SetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Deregister<HexModelSelectedMessage>(this, HexModelSelectedMessageFunction);
            Messenger.Default.Deregister<HexModelUnselectedMessage>(this, HexModelUnselectedMessageFunction);
            Messenger.Default.Deregister<UpdateGameModeMessage>(this, UpdateGameModeMessageFunction);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<GetSelectedColorImageIdsRequestMessage>(this, GetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Register<SetSelectedColorImageIdsRequestMessage>(this, SetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Register<HexModelSelectedMessage>(this, HexModelSelectedMessageFunction);
            Messenger.Default.Register<HexModelUnselectedMessage>(this, HexModelUnselectedMessageFunction);
            Messenger.Default.Register<UpdateGameModeMessage>(this, UpdateGameModeMessageFunction);
        }

        private void HexModelSelectedMessageFunction(HexModelSelectedMessage msg)
        {
            SelectHex(msg.HexModel);
        }

        private void HexModelUnselectedMessageFunction(HexModelUnselectedMessage msg)
        {
            UnselectHex();
        }

        private void GetSelectedColorImageIdsRequestMessageFunction(GetSelectedColorImageIdsRequestMessage msg)
        {
            msg.CallSuccessCallback(new Tuple<string, string>(SelectedTileColorViewModel.Id, SelectedTileImageViewModel.Id));
        }

        private void SetSelectedColorImageIdsRequestMessageFunction(SetSelectedColorImageIdsRequestMessage msg)
        {
            SelectedTileColorViewModel = GetTileColorViewModelFromId(msg.TileColorModelId);
            SelectedTileImageViewModel = GetTileImageViewModelFromId(msg.TileImageModelId);
        }

        private void UpdateGameModeMessageFunction(UpdateGameModeMessage msg)
        {
            GameMode = msg.GameMode;
            switch (GameMode)
            {
                case GameMode.MapCreation:
                    HexEditionAvailable = false;
                    TileEditionAvailable = true;
                    break;
                case GameMode.HexEdition:
                    HexEditionAvailable = true;
                    TileEditionAvailable = false;
                    break;
                case GameMode.Visualization:
                    HexEditionAvailable = false;
                    TileEditionAvailable = false;
                    break;
            }
        }

        #endregion Event functions
    }
}
