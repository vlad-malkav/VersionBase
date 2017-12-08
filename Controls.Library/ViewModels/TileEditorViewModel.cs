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

        public TileEditorViewModel() { }

        public void ApplyModel(TileEditorModel tileEditorModel)
        {
            ListTileColorViewModel = tileEditorModel.ListTileColorModel.Select(x => new TileColorViewModel(x)).ToList();
            SelectedTileColorViewModel = ListTileColorViewModel.First();
            ListTileImageTypeViewModel = tileEditorModel.ListTileImageTypeModel.Select(x => new TileImageTypeViewModel(x)).ToList();
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
