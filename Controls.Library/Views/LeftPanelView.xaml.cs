using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Controls.Library.Annotations;
using Controls.Library.ViewModels;

namespace Controls.Library.Views
{
    /// <summary>
    /// Interaction logic for LeftPanelView.xaml
    /// </summary>
    public partial class LeftPanelView : UserControl, INotifyPropertyChanged
    {
        public LeftPanelView()
        {
            InitializeComponent();
        }

        public LeftPanelViewModel ViewModel
        {
            get { return (LeftPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
                TileEditorViewControl.ViewModel = value.TileEditorViewModel;
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
