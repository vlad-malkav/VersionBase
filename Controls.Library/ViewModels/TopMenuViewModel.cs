using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;
using Controls.Library.Commands;
using MyToolkit.Mvvm;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.ViewModels
{
    public class TopMenuViewModel : ViewModelBase
    {
        public string Header { get; set; }

        public List<MenuItemViewModel> MenuOptions
        {
            get
            {
                var menu = new List<MenuItemViewModel>();
                if (ListStringTest.Count > 0)
                {
                    var mi = new MenuItemViewModel("O_pen");
                    foreach (var fl in ListStringTest)
                    {
                        menu.Add(new MenuItemViewModel(fl)
                            { Command = new MyICommand(OnClickSurTruc) });
                    }
                    menu.Add(mi);
                }


                menu.Add(new MenuItemViewModel("VisualStyleElement.ToolTip.Close _All") { Command = new MyICommand(OnClickSurMachin) });
                return menu;
            }
        }
        public List<string> ListStringTest { get; set; }

        public BitmapImage Image { get; set; }

        public TopMenuViewModel()
        {
            ListStringTest = new List<string>();
            ListStringTest.Add("A");
            ListStringTest.Add("B");
            ListStringTest.Add("V");
            Header = "head head";
            Image = HexMapDrawing.GenerateTileBitmapImage(Color.LightGreen, TileImageTypes.GetBitmapTile("empty"));
        }

        public void OnClickSurTruc()
        {

        }

        public void OnClickSurMachin()
        {

        }
    }
}
