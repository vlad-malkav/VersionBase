using System.Windows.Controls;
using VersionBase.ViewModels;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for TopMenu.xaml
    /// </summary>
    public partial class UITopMenuView : IViewWithModel<UITopMenuViewModel>
    {
        public UITopMenuView()
        {
            InitializeComponent();
        }

        public UITopMenuViewModel ViewModel
        {
            get { return (UITopMenuViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
            }
        }
    }
}
