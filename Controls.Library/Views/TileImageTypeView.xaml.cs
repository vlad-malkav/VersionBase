using System.Windows.Controls;

namespace Controls.Library.Views
{
    /// <summary>
    /// Interaction logic for TileTypeView.xaml
    /// </summary>
    public partial class TileImageTypeView : UserControl
    {
        public TileImageTypeView()
        {
            InitializeComponent();
        }
        
        private void cmbTileImageType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            /*Color selectedColor = (Color)(cmbColors.SelectedItem as PropertyInfo).GetValue(null, null);
            this.Background = new SolidColorBrush(selectedColor);**/
        }
    }
}
