using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for BottomPanelView.xaml
    /// </summary>
    public partial class BottomPanelView : IViewWithModel<BottomPanelViewModel>
    {
        public BottomPanelView()
        {
            InitializeComponent();
        }

        public BottomPanelViewModel ViewModel
        {
            get { return (BottomPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
            }
        }
    }
}
