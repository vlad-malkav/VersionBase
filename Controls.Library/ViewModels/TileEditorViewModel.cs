using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Controls.Library.Annotations;
using Controls.Library.Models;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.ViewModels
{
    public class TileEditorViewModel : INotifyPropertyChanged
    {
        public List<TileImageTypeViewModel> ListTileImageTypeViewModel { get; set; }
        private TileImageTypeViewModel _selectedTileImageTypeModel;
        public TileImageTypeViewModel SelectedTileImageTypeViewModel
        {
            get { return _selectedTileImageTypeModel; }
            set { _selectedTileImageTypeModel = value;
                OnPropertyChanged("SelectedTileImageTypeViewModel");
            }
        }

        public List<TileColorViewModel> ListTileColorViewModel { get; set; }
        private TileColorViewModel _selectedTileColorViewModel;
        public TileColorViewModel SelectedTileColorViewModel
        {
            get { return _selectedTileColorViewModel; }
            set { _selectedTileColorViewModel = value;
                OnPropertyChanged("SelectedTileColorViewModel");
            }
        }

        public TileEditorViewModel(TileEditorModel tileEditorModel)
        {
            ListTileColorViewModel = tileEditorModel.ListTileColorModel.Select(x => new TileColorViewModel(x)).ToList();
            SelectedTileColorViewModel = ListTileColorViewModel.First();
            ListTileImageTypeViewModel = tileEditorModel.ListTileImageTypeModel.Select(x => new TileImageTypeViewModel(x)).ToList();
            SelectedTileImageTypeViewModel = ListTileImageTypeViewModel.First();
        }

        public TileColorViewModel GetTileColorViewModel(string name)
        {
            return ListTileColorViewModel.FirstOrDefault(x => x.Name == name);
        }

        public TileImageTypeViewModel GetTileImageTypeViewModel(string name)
        {
            return ListTileImageTypeViewModel.FirstOrDefault(x => x.Name == name);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
