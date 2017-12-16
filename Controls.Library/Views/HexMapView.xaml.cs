using System.Windows.Controls;
using Controls.Library.Events;
using Controls.Library.ViewModels;
using MyToolkit.Messaging;

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
            Messenger.Default.Register<HexViewModelSelectedMessage>(this, HexViewSelectedMessageFunction);
            Messenger.Default.Register<HexViewModelUnselectedMessage>(this, HexViewUnselectedMessageFunction);
        }
        
        private void HexViewSelectedMessageFunction(HexViewModelSelectedMessage msgHexSelectedMessage)
        {
            //Canvas.SetZIndex(msgHexSelectedMessage.HexViewModel.InsidePolygon, 1000);
        }

        private void HexViewUnselectedMessageFunction(HexViewModelUnselectedMessage msgHexUnselectedMessage)
        {
            //Canvas.SetZIndex(msgHexUnselectedMessage.HexViewModel.InsidePolygon, 0);
        }

        public HexMapViewModel ViewModel
        {
            get { return (HexMapViewModel)Resources["ViewModel"]; }
            set { Resources["ViewModel"] = value; }
        }
    }
}
