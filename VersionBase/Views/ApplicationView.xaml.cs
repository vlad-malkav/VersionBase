using System.Windows;
using System.Windows.Controls;
using VersionBase.Views;
using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class ApplicationView : UserControl, IViewWithModel<ApplicationViewModel>
    {
        public ApplicationView()
        {
            InitializeComponent();
        }

        public ApplicationViewModel ViewModel
        {
            get { return (ApplicationViewModel)((FrameworkElement)this).Resources["ViewModel"]; }
            set
            {
                ((FrameworkElement)this).Resources["ViewModel"] = value;
                HexMapViewControl.ViewModel = value.GameViewModel.HexMapViewModel;
                TopMenuViewControl.ViewModel = value.UIViewModel.UITopMenuViewModel;
                UILeftPanelViewControl.ViewModel = value.UIViewModel.UILeftPanelViewModel;
                UIRightPanelViewControl.ViewModel = value.UIViewModel.UIRightPanelViewModel;
                TopMenuViewControl.ViewModel = value.UIViewModel.UITopMenuViewModel;
                UIBottomPanelViewControl.ViewModel = value.UIViewModel.UIBottomPanelViewModel;
            }
        }
    }
}
