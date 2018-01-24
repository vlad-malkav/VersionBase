using System.Windows.Controls;
using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for TileEditorView.xaml
    /// </summary>
    public partial class TileEditorView : IViewWithModel<TileEditorViewModel>
    {
        public TileEditorView()
        {
            InitializeComponent();
        }

        public TileEditorViewModel ViewModel
        {
            get { return (TileEditorViewModel)Resources["ViewModel"]; }
            set { Resources["ViewModel"] = value; }
        }
    }
}
