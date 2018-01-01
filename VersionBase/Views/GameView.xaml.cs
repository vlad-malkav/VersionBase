using System.Windows.Controls;
using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
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
                HexMapViewControl.ViewModel = value.HexMapViewModel;
                TopMenuViewControl.ViewModel = value.TopMenuViewModel;
                LeftPanelViewControl.ViewModel = value.LeftPanelViewModel;
                RightPanelViewControl.ViewModel = value.RightPanelViewModel;
                TopMenuViewControl.ViewModel = value.TopMenuViewModel;
                BottomPanelViewControl.ViewModel = value.BottomPanelViewModel;
            }
        }
    }
}
