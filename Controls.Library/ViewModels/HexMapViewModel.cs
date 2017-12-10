using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using MyToolkit.Mvvm;

namespace Controls.Library.ViewModels
{
    public class HexMapViewModel : ViewModelBase
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
            ListHexViewModel = new List<HexViewModel>();
            ListPolygon = new ObservableCollection<UIElement>();
        }

        public void ApplyModel(HexMapModel hexMapModel, double width, double height, double cellSize)
        {
            Messenger.Default.Deregister<HexModelUpdatedMessage>(this, HexModelUpdatedMessageFunction);
            Width = width;
            Height = height;
            CellSize = cellSize;
            Columns = hexMapModel.Rows;
            Rows = hexMapModel.Rows;
            foreach (var hexViewModel in ListHexViewModel)
            {
                hexViewModel.UnsubscribePolygonEvents();
            }
            ListHexViewModel.Clear();
            ListPolygon.Clear();
            foreach (var hexModel in hexMapModel.ListHexModel)
            {
                ListHexViewModel.Add(new HexViewModel(hexModel, CellSize));
            }
            foreach (var hexViewModel in ListHexViewModel)
            {
                ListPolygon.Add(hexViewModel.Polygon);
            }
            Messenger.Default.Register<HexModelUpdatedMessage>(this, HexModelUpdatedMessageFunction);
        }

        private void HexModelUpdatedMessageFunction(HexModelUpdatedMessage msgHexModelUpdatedMessage)
        {
            var hexViewModel = GetHexViewModel(msgHexModelUpdatedMessage.HexModel.Column, msgHexModelUpdatedMessage.HexModel.Row);
            if(hexViewModel != null)
                hexViewModel.UpdateFromHexModel(msgHexModelUpdatedMessage.HexModel);
        }

        public HexViewModel GetHexViewModel(int column, int row)
        {
            return ListHexViewModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }
    }
}