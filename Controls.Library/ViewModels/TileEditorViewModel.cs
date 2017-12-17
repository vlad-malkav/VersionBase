using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Command;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;
using MyToolkit.Utilities;

namespace Controls.Library.ViewModels
{
    public class TileEditorViewModel : ViewModelBase // from MyToolkit
    {
        public bool IsActive { get; set; }

        public List<TileImageTypeViewModel> ListTileImageTypeViewModel { get; set; }
        private TileImageTypeViewModel _selectedTileImageTypeModel;
        public TileImageTypeViewModel SelectedTileImageTypeViewModel
        {
            get { return _selectedTileImageTypeModel; }
            set { _selectedTileImageTypeModel = value;
                RaisePropertyChanged("SelectedTileImageTypeViewModel");
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

        private string _label;
        private string _description;
        private int _degreExploration;

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
            }
        }

        public int? SelectedHexColumn = null;
        public int? SelectedHexRow = null;

        public ICommand SaveButtonCommand { get; private set; }

        public TileEditorViewModel()
        {
            IsActive = true;
            ListTileColorViewModel = new List<TileColorViewModel>();
            ListTileImageTypeViewModel = new List<TileImageTypeViewModel>();
            SaveButtonCommand = new RelayCommand(() => SaveButtonAction());
        }

        public void ApplyModel(TileEditorModel tileEditorModel)
        {
            UnregisterMessages();
            ListTileColorViewModel.Clear();
            foreach (var tileColorModel in tileEditorModel.ListTileColorModel)
            {
                ListTileColorViewModel.Add(new TileColorViewModel(tileColorModel));
            }
            SelectedTileColorViewModel = ListTileColorViewModel.First();
            ListTileImageTypeViewModel.Clear();
            foreach (var tileImageTypeModel in tileEditorModel.ListTileImageTypeModel)
            {
                ListTileImageTypeViewModel.Add(new TileImageTypeViewModel(tileImageTypeModel));
            }
            SelectedTileImageTypeViewModel = ListTileImageTypeViewModel.First();
            RegisterMessages();
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
            Label = msgHexModelSelectedMessage.HexModel.GetLabel();
            Description = msgHexModelSelectedMessage.HexModel.Description;
            DegreExploration = msgHexModelSelectedMessage.HexModel.DegreExploration;
            SelectedHexColumn = msgHexModelSelectedMessage.HexModel.Column;
            SelectedHexRow = msgHexModelSelectedMessage.HexModel.Row;
            IsActive = false;
        }

        private void HexModelUnselectedMessageFunction(HexModelUnselectedMessage msgHexModelUnselectedMessagee)
        {
            Label = "";
            Description = "";
            DegreExploration = 0;
            SelectedHexColumn = null;
            SelectedHexRow = null;
            IsActive = true;
        }

        private void HexViewUnselectedMessageFunction(HexViewModelUnselectedMessage msgHexUnselectedMessage)
        {

        }

        private void GetSelectedColorImageIdsRequestMessageFunction(GetSelectedColorImageIdsRequestMessage msg)
        {
            msg.CallSuccessCallback(new Tuple<string, string>(SelectedTileColorViewModel.Id, SelectedTileImageTypeViewModel.Id));
        }

        private void SetSelectedColorImageIdsRequestMessageFunction(SetSelectedColorImageIdsRequestMessage msg)
        {
            SelectedTileColorViewModel = GetTileColorViewModelFromId(msg.TileColorModelId);
            SelectedTileImageTypeViewModel = GetTileImageTypeViewModelFromId(msg.TileImageTypeModelId);
        }

        public TileColorViewModel GetTileColorViewModelFromId(string id)
        {
            return ListTileColorViewModel.FirstOrDefault(x => x.Id == id);
        }

        public TileImageTypeViewModel GetTileImageTypeViewModelFromId(string id)
        {
            return ListTileImageTypeViewModel.FirstOrDefault(x => x.Id == id);
        }
    }
}
