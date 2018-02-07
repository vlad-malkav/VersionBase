using System;
using System.Windows.Controls;
using System.Windows.Media;
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
            _scaleTransform = new ScaleTransform();
            UnregisterMessages();
            InitializeComponent();
            RegisterMessages();
        }



        private void UnregisterMessages()
        {
            Messenger.Default.Deregister<GetHexMapCanvasDimensionsRequestMessage>(this,
                GetHexMapCanvasDimensionsRequestMessageFunction);
            Messenger.Default.Deregister<AddPointMessage>(this, AddPointMessageFunction);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<GetHexMapCanvasDimensionsRequestMessage>(this,
                GetHexMapCanvasDimensionsRequestMessageFunction);
            Messenger.Default.Register<AddPointMessage>(this, AddPointMessageFunction);
        }

        //TODO DESBONAL
        private ScaleTransform _scaleTransform;
        private void AddPointMessageFunction(AddPointMessage msg)
        {
            CanvasTest.Sc.ScaleX *= 1.5;
            St.ScaleY *= 1.5;
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
