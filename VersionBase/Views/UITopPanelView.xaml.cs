using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for UITopPanelView.xaml
    /// </summary>
    public partial class UITopPanelView : IViewWithModel<UITopPanelViewModel>
    {
        public UITopPanelView()
        {
            InitializeComponent();
        }

        public UITopPanelViewModel ViewModel
        {
            get { return (UITopPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
            }
        }
    }
}
