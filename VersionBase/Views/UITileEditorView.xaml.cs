using System.Windows.Controls;
using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for UITileEditorView.xaml
    /// </summary>
    public partial class UITileEditorView : IViewWithModel<UITileEditorViewModel>
    {
        public UITileEditorView()
        {
            InitializeComponent();
        }

        public UITileEditorViewModel ViewModel
        {
            get { return (UITileEditorViewModel)Resources["ViewModel"]; }
            set { Resources["ViewModel"] = value; }
        }
    }
}
