using System.Windows;
using System.Windows.Controls;
using VersionBase.Views;
using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl, IViewWithModel<GameViewModel>
    {
        public GameView()
        {
            InitializeComponent();
        }

        public GameViewModel ViewModel
        {
            get { return (GameViewModel)((FrameworkElement)this).Resources["ViewModel"]; }
            set
            {
                ((FrameworkElement)this).Resources["ViewModel"] = value;
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
