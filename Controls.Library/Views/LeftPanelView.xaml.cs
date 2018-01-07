using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Controls.Library.Annotations;
using Controls.Library.ViewModels;

namespace Controls.Library.Views
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
