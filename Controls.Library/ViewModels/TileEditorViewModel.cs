using System;
using System.Collections.Generic;
using System.Linq;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Command;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class TileEditorViewModel : ViewModelBase // from MyToolkit
    {   public List<TileImageViewModel> ListTileImageViewModel { get; set; }
        private TileImageViewModel _selectedTileImageModel;
        public TileImageViewModel SelectedTileImageViewModel
        {
            get { return _selectedTileImageModel; }
            set { _selectedTileImageModel = value;
                RaisePropertyChanged("SelectedTileImageViewModel");
            }
        }

        public List<TileColorViewModel> ListTileColorViewModel { get; set; }
        private TileColorViewModel _selectedTileColorViewModel;

        public TileColorViewModel SelectedTileColorViewModel
        {
            get { return _selectedTileColorViewModel; }
            set { _selectedTileColorViewModel = value;
                RaisePropertyChanged("SelectedTileColorViewModel");
            }
        }

        private bool _isHexSelected;
        private bool _isHexUnselected;

        public bool IsHexSelected
        {
            get { return _isHexSelected; }
            set
            {
                _isHexSelected = value;
                RaisePropertyChanged("IsHexSelected");
                if (SaveButtonCommand != null) SaveButtonCommand.RaiseCanExecuteChanged();
                if (DegreExplorationMinusCommand != null) DegreExplorationMinusCommand.RaiseCanExecuteChanged();
                if (DegreExplorationPlusCommand != null) DegreExplorationPlusCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsHexUnselected
        {
            get { return _isHexUnselected; }
            set
            {
                _isHexUnselected = value;
                RaisePropertyChanged("IsHexUnselected");
            }
        }

        #region Hex Data

        private string _label;
        private string _description;
        private int _degreExploration;
        private string _selectedHexColor;
        private string _selectedHexImage;

        public string Label
        {
            get { return _label; }
            set { _label = value;
                RaisePropertyChanged("Label");
            }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value;
                RaisePropertyChanged("Description");
            }
        }

        public int DegreExploration
        {
            get { return _degreExploration; }
            set { _degreExploration = value;
                RaisePropertyChanged("DegreExploration");
                if(DegreExplorationMinusCommand != null) DegreExplorationMinusCommand.RaiseCanExecuteChanged();
                if (DegreExplorationPlusCommand != null) DegreExplorationPlusCommand.RaiseCanExecuteChanged();
            }
        }

        public string SelectedHexColor
        {
            get { return _selectedHexColor; }
            set { _selectedHexColor = value;
                RaisePropertyChanged("SelectedHexColor");
            }
        }

        public string SelectedHexImage
        {
            get { return _selectedHexImage; }
            set { _selectedHexImage = value;
                RaisePropertyChanged("SelectedHexImage");
            }
        }

        public int? SelectedHexColumn = null;
        public int? SelectedHexRow = null;

        #endregion

        public RelayCommand SaveButtonCommand { get; private set; }
        public RelayCommand DegreExplorationPlusCommand { get; private set; }
        public RelayCommand DegreExplorationMinusCommand { get; private set; }
        private int TimeUnique { get; set; }

        public TileEditorViewModel()
        {
            TimeUnique = DateTime.Now.Millisecond;
            UnregisterMessages();
            SetHexSelectedState(false);
            ListTileColorViewModel = new List<TileColorViewModel>();
            ListTileImageViewModel = new List<TileImageViewModel>();
            SaveButtonCommand = new RelayCommand(
                () => SaveButtonAction(),
                () => IsHexSelected);
            
                DegreExplorationPlusCommand = new RelayCommand(
                    () => DegreExploration++,
                    () => DegreExploration < 6 && IsHexSelected);
            
                DegreExplorationMinusCommand = new RelayCommand(
                    () => DegreExploration--,
                    () => DegreExploration > 0 && IsHexSelected);
            RegisterMessages();
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

        private void UnregisterMessages()
        {
            Messenger.Default.Deregister<GetSelectedColorImageIdsRequestMessage>(this, GetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Deregister<SetSelectedColorImageIdsRequestMessage>(this, SetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Deregister<HexModelSelectedMessage>(this, HexModelSelectedMessageFunction);
            Messenger.Default.Deregister<HexModelUnselectedMessage>(this, HexModelUnselectedMessageFunction);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<GetSelectedColorImageIdsRequestMessage>(this, GetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Register<SetSelectedColorImageIdsRequestMessage>(this, SetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Register<HexModelSelectedMessage>(this, HexModelSelectedMessageFunction);
            Messenger.Default.Register<HexModelUnselectedMessage>(this, HexModelUnselectedMessageFunction);
        }

        private void HexModelSelectedMessageFunction(HexModelSelectedMessage msgHexModelSelectedMessage)
        {
            SelectHex(msgHexModelSelectedMessage.HexModel);
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
            SetHexSelectedState(true);
        }

        private void HexModelUnselectedMessageFunction(HexModelUnselectedMessage msgHexModelUnselectedMessagee)
        {
            UnselectHex();
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
            SetHexSelectedState(false);
        }

        private void SetHexSelectedState(bool isHexSelected)
        {
            IsHexSelected = isHexSelected;
            IsHexUnselected = !IsHexSelected;
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

        public TileColorViewModel GetTileColorViewModelFromId(string id)
        {
            return ListTileColorViewModel.FirstOrDefault(x => x.Id == id);
        }

        public TileImageViewModel GetTileImageViewModelFromId(string id)
        {
            return ListTileImageViewModel.FirstOrDefault(x => x.Id == id);
        }
    }
}
