using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for UIRightPanelView.xaml
    /// </summary>
    public partial class UIRightPanelView : IViewWithModel<UIRightPanelViewModel>
    {
        public UIRightPanelView()
        {
            InitializeComponent();
        }

        public UIRightPanelViewModel ViewModel
        {
            get { return (UIRightPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
            }
        }
    }
}
