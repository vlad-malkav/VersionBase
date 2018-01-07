using System.Windows.Controls;
using Controls.Library.ViewModels;

namespace Controls.Library.Views
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
