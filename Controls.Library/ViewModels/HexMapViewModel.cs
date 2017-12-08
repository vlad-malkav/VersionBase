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

        public void ApplyModel(HexMapModel hexMapModel)
        {
            Width = hexMapModel.Width;
            Height = hexMapModel.Height;
            CellSize = hexMapModel.CellSize;
            Columns = hexMapModel.Rows;
            Rows = hexMapModel.Rows;
            ListHexViewModel = hexMapModel.ListHexModel.Select(x => new HexViewModel(x, CellSize)).ToList();
            ListPolygon = new ObservableCollection<UIElement>(ListHexViewModel.Select(x => x.Polygon));
            Messenger.Default.Register<HexModelUpdatedMessage>(this, HexModelUpdatedMessageFunction);
        }

        private void HexModelUpdatedMessageFunction(HexModelUpdatedMessage msgHexModelUpdatedMessage)
        {
            GetHexViewModel(msgHexModelUpdatedMessage.HexModel.Column, msgHexModelUpdatedMessage.HexModel.Row).UpdateFromHexModel(msgHexModelUpdatedMessage.HexModel);
        }

        public HexViewModel GetHexViewModel(int column, int row)
        {
            return ListHexViewModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }
    }
}
