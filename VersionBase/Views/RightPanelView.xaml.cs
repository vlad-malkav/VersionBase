using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for RightPanelView.xaml
    /// </summary>
    public partial class RightPanelView : IViewWithModel<RightPanelViewModel>
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
    }
}
