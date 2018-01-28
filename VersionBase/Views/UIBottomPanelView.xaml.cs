using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for UIBottomPanelView.xaml
    /// </summary>
    public partial class UIBottomPanelView : IViewWithModel<UIBottomPanelViewModel>
    {
        public UIBottomPanelView()
        {
            InitializeComponent();
        }

        public UIBottomPanelViewModel ViewModel
        {
            get { return (UIBottomPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
            }
        }
    }
}
