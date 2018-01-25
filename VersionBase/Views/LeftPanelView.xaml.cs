using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for LeftPanelView.xaml
    /// </summary>
    public partial class LeftPanelView : IViewWithModel<LeftPanelViewModel>
    {
        public LeftPanelView()
        {
            InitializeComponent();
        }

        public LeftPanelViewModel ViewModel
        {
            get { return (LeftPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
                TileEditorViewControl.ViewModel = value.TileEditorViewModel;
            }
        }
    }
}
