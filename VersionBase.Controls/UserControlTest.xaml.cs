using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VersionBase.Controls
{
    /// <summary>
    /// Interaction logic for UserControlTest.xaml
    /// </summary>
    public partial class UserControlTest : UserControl
    {
        public string TextInControl
        {
            get { return (string)GetValue(TextInControlProperty); }
            set { SetValue(TextInControlProperty, value); }
        }

        public static readonly DependencyProperty TextInControlProperty =
            DependencyProperty.Register("TextInControl", typeof(string),
                typeof(UserControlTest));

        public UserControlTest()
        {
            InitializeComponent();

            List<TodoItem> items = new List<TodoItem>();
            items.Add(new TodoItem() { Title = "Complete this WPF tutorial", Completion = 45 });
            items.Add(new TodoItem() { Title = "Learn C#", Completion = 80 });
            items.Add(new TodoItem() { Title = "Wash the car", Completion = 0 });
            items.Add(new TodoItem() { Title = TextInControl, Completion = 0 });

            icTodoList.ItemsSource = items;
        }
        public static void OnMyStatePropertyChanged
        (
            DependencyObject d, // i.e. owner of the dependency property.
            DependencyPropertyChangedEventArgs e // Event arguments.
        )
        {
        }
    }

    public class TodoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }
}
