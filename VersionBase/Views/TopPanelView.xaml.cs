using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for TopPanelView.xaml
    /// </summary>
    public partial class TopPanelView : IViewWithModel<TopPanelViewModel>
    {
        public TopPanelView()
        {
            InitializeComponent();
        }

        public TopPanelViewModel ViewModel
        {
            get { return (TopPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
            }
        }
    }
}
