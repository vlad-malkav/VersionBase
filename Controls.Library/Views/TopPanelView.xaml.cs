using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Controls.Library.Annotations;
using Controls.Library.ViewModels;

namespace Controls.Library.Views
{
    /// <summary>
    /// Interaction logic for TopPanelView.xaml
    /// </summary>
    public partial class TopPanelView : UserControl, INotifyPropertyChanged
    {
        public TopPanelView()
        {
            InitializeComponent();
        }

        public TopPanelViewModel ViewModel
        {
            get { return (TopPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
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
