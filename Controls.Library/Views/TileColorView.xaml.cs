using System.Windows.Controls;

namespace Controls.Library.Views
{
    /// <summary>
    /// Interaction logic for TileColorView.xaml
    /// </summary>
    public partial class TileColorView : UserControl
    {
        public TileColorView()
        {
            InitializeComponent();
        }

        private void cmbTileColor_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            /*Color selectedColor = (Color)(cmbColors.SelectedItem as PropertyInfo).GetValue(null, null);
            this.Background = new SolidColorBrush(selectedColor);**/
        }
    }
}
