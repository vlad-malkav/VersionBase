using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using Controls.Library.Events;
using Controls.Library.Models;
using VersionBase.Libraries.Events;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.ViewModels
{
    public class HexMapViewModel
    {
        public List<HexModel> ListHexModel { get; set; }
        public ObservableCollection<UIElement> ListPolygon { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public HexMapViewModel()
        {
            Width = 300;
            Height = 300;
            ListHexModel = GenerateListHexModel(10, 10, 25);
            ListPolygon = new ObservableCollection<UIElement>(ListHexModel.Select(x => x.Polygon));
            SetHexButtonActions();
        }

        public HexMapViewModel(List<HexModel> listHexModel, double width, double height)
        {
            Width = width;
            Height = height;
            ListHexModel = listHexModel;
            ListPolygon = new ObservableCollection<UIElement>(ListHexModel.Select(x => x.Polygon));
            SetHexButtonActions();
        }

        public static List<HexModel> GenerateListHexModel(int columns, int rows, double cellSize)
        {
            List<HexModel> listHexModel = new List<HexModel>();

            List<TileImageType> listTileImageType = TileImageTypes.GetAllTileImageTypes();

            int tileTypeCurrent = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    TileData tileData = new TileData(new TileColor(Color.LightGreen), listTileImageType[tileTypeCurrent++ % listTileImageType.Count]);
                    HexData hexDataTmp = new HexData(new HexCoordinates(col, row), "-", tileData, cellSize);
                    listHexModel.Add(new HexModel(hexDataTmp, cellSize));
                }
            }
            return listHexModel;
        }

        public void SetHexButtonActions()
        {
            foreach (UIElement polygonUiElement in ListPolygon)
            {
                polygonUiElement.MouseLeftButtonDown += MouseLeftButtonDown;
                polygonUiElement.MouseRightButtonDown += MouseRightButtonDown;
            }
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HexModel selectedHexModel = ListHexModel.First(x => x.Polygon == sender);

            // Broadcast Events
            EventSystem.Publish<HexClickedLeftButtonMessage>(
                new HexClickedLeftButtonMessage { HexModel = selectedHexModel });
        }

        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            HexModel selectedHexModel = ListHexModel.First(x => x.Polygon == sender);

            // Broadcast Events
            EventSystem.Publish<HexClickedRightButtonMessage>(
                new HexClickedRightButtonMessage { HexModel = selectedHexModel });
        }
    }
}
