using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controls.Library.Annotations;
using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl, INotifyPropertyChanged
    {
        public GameView()
        {
            InitializeComponent();
        }

        public GameViewModel ViewModel
        {
            get { return (GameViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
                TileEditorViewControl.ViewModel = value.TileEditorViewModel;
                HexMapViewControl.ViewModel = value.HexMapViewModel;
                TopMenuViewControl.ViewModel = value.TopMenuViewModel;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
