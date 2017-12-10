using System;
using System.Collections.Generic;
using System.Linq;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class TileEditorViewModel : ViewModelBase // from MyToolkit
    {
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

        public TileEditorViewModel()
        {
            ListTileColorViewModel = new List<TileColorViewModel>();
            ListTileImageTypeViewModel = new List<TileImageTypeViewModel>();
        }

        public void ApplyModel(TileEditorModel tileEditorModel)
        {
            Messenger.Default.Deregister<GetSelectedColorImageIdsRequestMessage>(this, GetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Deregister<SetSelectedColorImageIdsRequestMessage>(this, SetSelectedColorImageIdsRequestMessageFunction);
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
            Messenger.Default.Register<GetSelectedColorImageIdsRequestMessage>(this, GetSelectedColorImageIdsRequestMessageFunction);
            Messenger.Default.Register<SetSelectedColorImageIdsRequestMessage>(this, SetSelectedColorImageIdsRequestMessageFunction);
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
