using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Controls.Library.Annotations;
using Controls.Library.ViewModels;

namespace Controls.Library.Views
{
    /// <summary>
    /// Interaction logic for RightPanelView.xaml
    /// </summary>
    public partial class RightPanelView : UserControl, INotifyPropertyChanged
    {
        public RightPanelView()
        {
            InitializeComponent();
        }

        public RightPanelViewModel ViewModel
        {
            get { return (RightPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
