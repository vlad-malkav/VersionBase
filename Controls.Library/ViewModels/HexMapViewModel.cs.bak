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
        public int Columns { get; set; }
        public int Rows { get; set; }
        public double CellSize { get; set; }
        public List<HexViewModel> ListHexViewModel { get; set; }
        public ObservableCollection<UIElement> ListPolygon { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public HexMapViewModel()
        {
            Width = 300;
            Height = 300;
            Columns = 10;
            Rows = 10;
            CellSize = 25;
            ListHexViewModel = GenerateListHexModel(Columns, Rows, CellSize)
                .Select(x => new HexViewModel(x, CellSize)).ToList();
            ListPolygon = new ObservableCollection<UIElement>(ListHexViewModel.Select(x => x.Polygon));
            SetHexButtonActions();
        }

        public HexMapViewModel(HexMapModel hexMapModel)
        {
            Width = hexMapModel.Width;
            Height = hexMapModel.Height;
            CellSize = hexMapModel.CellSize;
            Columns = hexMapModel.Rows;
            Rows = hexMapModel.Rows;
            ListHexViewModel = hexMapModel.ListHexModel.Select(x => new HexViewModel(x, CellSize)).ToList();
            ListPolygon = new ObservableCollection<UIElement>(ListHexViewModel.Select(x => x.Polygon));
            SetHexButtonActions();
        }

        public HexViewModel GetHexViewModel(int column, int row)
        {
            return ListHexViewModel.FirstOrDefault(x => x.Column == column && x.Row == row);
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
                    TileData tileData = new TileData(new TileColor(Color.LightGreen),
                        listTileImageType[tileTypeCurrent++ % listTileImageType.Count]);
                    HexData hexDataTmp = new HexData(col, row, "-", tileData, cellSize);
                    listHexModel.Add(new HexModel(hexDataTmp));
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
            HexViewModel selectedHexViewModel = ListHexViewModel.First(x => x.Polygon == sender);

            // Broadcast Events
            EventSystem.Publish<HexClickedLeftButtonMessage>(
                new HexClickedLeftButtonMessage
                {
                    Column = selectedHexViewModel.Column,
                    Row = selectedHexViewModel.Row
                });
        }

        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            HexViewModel selectedHexViewModel = ListHexViewModel.First(x => x.Polygon == sender);

            // Broadcast Events
            EventSystem.Publish<HexClickedRightButtonMessage>(
                new HexClickedRightButtonMessage
                {
                    Column = selectedHexViewModel.Column,
                    Row = selectedHexViewModel.Row
                });
        }
    }
}
