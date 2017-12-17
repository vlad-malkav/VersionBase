using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
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
        public ObservableCollection<UIElement> ListUIElement { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public HexMapViewModel()
        {
            UnregisterMessages();
            ListHexViewModel = new List<HexViewModel>();
            ListUIElement = new ObservableCollection<UIElement>();
            RegisterMessages();
        }

        public void ApplyModel(HexMapModel hexMapModel, double width, double height, double cellSize)
        {
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
            ListUIElement.Clear();
            foreach (var hexModel in hexMapModel.ListHexModel)
            {
                var hexViewModel = new HexViewModel(hexModel, CellSize);
                ListHexViewModel.Add(hexViewModel);
                foreach (UIElement uiElement in hexViewModel.GetAllUIElements())
                {
                    ListUIElement.Add(uiElement);
                }
            }

        }

        private void UnregisterMessages()
        {
            Messenger.Default.Deregister<HexModelUpdatedMessage>(this, HexModelUpdatedMessageFunction);
            Messenger.Default.Deregister<HexModelSelectedMessage>(this, HexSelectedMessageFunction);
            Messenger.Default.Deregister<HexModelUnselectedMessage>(this, HexUnselectedMessageFunction);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<HexModelUpdatedMessage>(this, HexModelUpdatedMessageFunction);
            Messenger.Default.Register<HexModelSelectedMessage>(this, HexSelectedMessageFunction);
            Messenger.Default.Register<HexModelUnselectedMessage>(this, HexUnselectedMessageFunction);
        }

        private void HexModelUpdatedMessageFunction(HexModelUpdatedMessage msgHexModelUpdatedMessage)
        {
            var hexViewModel = GetHexViewModel(msgHexModelUpdatedMessage.HexModel.Column, msgHexModelUpdatedMessage.HexModel.Row);
            if (hexViewModel != null)
                hexViewModel.UpdateFromHexModel(msgHexModelUpdatedMessage.HexModel);
        }

        private void HexSelectedMessageFunction(HexModelSelectedMessage msgHexSelectedMessage)
        {
            var hexViewModel = GetHexViewModel(msgHexSelectedMessage.HexModel.Column, msgHexSelectedMessage.HexModel.Row);
            if (hexViewModel != null)
                hexViewModel.SelectHex();
        }

        private void HexUnselectedMessageFunction(HexModelUnselectedMessage msgHexUnselectedMessage)
        {
            var hexViewModel = GetHexViewModel(msgHexUnselectedMessage.HexModel.Column, msgHexUnselectedMessage.HexModel.Row);
            if (hexViewModel != null)
                hexViewModel.UnselectHex();
        }

        public HexViewModel GetHexViewModel(int column, int row)
        {
            return ListHexViewModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }
    }
}