using System.Windows.Controls;
using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for TopMenu.xaml
    /// </summary>
    public partial class TopMenuView : IViewWithModel<TopMenuViewModel>
    {
        public TopMenuView()
        {
            InitializeComponent();
        }

        public TopMenuViewModel ViewModel
        {
            get { return (TopMenuViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
            }
        }
    }
}
