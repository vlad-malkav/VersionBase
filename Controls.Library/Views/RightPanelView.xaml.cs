using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Controls.Library.Annotations;
using Controls.Library.ViewModels;

namespace Controls.Library.Views
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
