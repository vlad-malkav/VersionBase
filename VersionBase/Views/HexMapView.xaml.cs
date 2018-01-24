using System;
using System.Windows.Controls;
using VersionBase.Events;
using VersionBase.ViewModels;
using MyToolkit.Messaging;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for HexMapView.xaml
    /// </summary>
    public partial class HexMapView : IViewWithModel<HexMapViewModel>
    {
        public HexMapView()
        {
            UnregisterMessages();
            InitializeComponent();
            RegisterMessages();
        }



        private void UnregisterMessages()
        {
            Messenger.Default.Deregister<GetHexMapCanvasDimensionsRequestMessage>(this,
                GetHexMapCanvasDimensionsRequestMessageFunction);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<GetHexMapCanvasDimensionsRequestMessage>(this,
                GetHexMapCanvasDimensionsRequestMessageFunction);
        }

        private void GetHexMapCanvasDimensionsRequestMessageFunction(GetHexMapCanvasDimensionsRequestMessage msg)
        {
            msg.CallSuccessCallback(GetCanvasDimensions());
        }

        public HexMapViewModel ViewModel
        {
            get { return (HexMapViewModel)Resources["ViewModel"]; }
            set { Resources["ViewModel"] = value; }
        }

        public Tuple<double,double> GetCanvasDimensions()
        {
            return new Tuple<double, double>(
                CanvasUIElement.ActualWidth,
                CanvasUIElement.ActualHeight);
        }
    }
}
