using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Controls.Library.Annotations;
using Controls.Library.ViewModels;

namespace Controls.Library.Views
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
