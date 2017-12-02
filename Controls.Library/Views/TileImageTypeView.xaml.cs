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
