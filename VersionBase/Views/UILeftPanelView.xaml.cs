using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for UILeftPanelView.xaml
    /// </summary>
    public partial class UILeftPanelView : IViewWithModel<UILeftPanelViewModel>
    {
        public UILeftPanelView()
        {
            InitializeComponent();
        }

        public UILeftPanelViewModel ViewModel
        {
            get { return (UILeftPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
                UITileEditorViewControl.ViewModel = value.UITileEditorViewModel;
            }
        }
    }
}
