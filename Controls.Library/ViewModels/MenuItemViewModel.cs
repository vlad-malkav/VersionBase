using System.Collections.Generic;
using System.Windows.Input;
using Controls.Library.Commands;
using Controls.Library.Events;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        public string Header { get; set; }
        public List<MenuItemViewModel> ListMenuItemViewModel { get; set; }
        public ICommand Command { get; set; }

        public MenuItemViewModel()
        {
            ListMenuItemViewModel = new List<MenuItemViewModel>();
        }

        public MenuItemViewModel(string header)
            : this()
        {
            Header = header;
            Command = new MyICommand(() => Messenger.Default.Send(
                new MenuItemClickedMessage
                {
                    Name = header
                }));
        }
    }
}
