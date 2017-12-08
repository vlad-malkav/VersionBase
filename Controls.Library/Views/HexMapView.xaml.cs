using System.Windows.Controls;
using Controls.Library.ViewModels;

namespace Controls.Library.Views
{
    /// <summary>
    /// Interaction logic for HexMapView.xaml
    /// </summary>
    public partial class HexMapView : UserControl
    {
        public HexMapView()
        {
            InitializeComponent();
        }

        public HexMapViewModel ViewModel
        {
            get { return (HexMapViewModel)Resources["ViewModel"]; }
            set { Resources["ViewModel"] = value; }
        }
    }
}
