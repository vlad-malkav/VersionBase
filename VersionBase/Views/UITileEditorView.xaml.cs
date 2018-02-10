using System.Windows;
using System.Windows.Controls;
using MyToolkit.Messaging;
using VersionBase.Events;
using VersionBase.Libraries.Enums;
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

        private void OnAddCommunityButtonClicked(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send(new SetClickActionMessage(ClickAction.AddCommunity));
        }
    }
}
