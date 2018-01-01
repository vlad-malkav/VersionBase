using System.Windows.Controls;
using System.Windows.Input;
using Controls.Library.Events;
using MyToolkit.Messaging;

namespace Controls.Library.Views
{
    /// <summary>
    /// Interaction logic for TestControl.xaml
    /// </summary>
    public partial class TestControl : UserControl
    {
        public TestControl()
        {
            InitializeComponent();
            PolygonNavigateUp.MouseLeftButtonDown += PolygonNavigateUpAction;
            PolygonNavigateDown.MouseLeftButtonDown += PolygonNavigateDownAction;
            PolygonNavigateLeft.MouseLeftButtonDown += PolygonNavigateLeftAction;
            PolygonNavigateRight.MouseLeftButtonDown += PolygonNavigateRightAction;
            PolygonZoomIn.MouseLeftButtonDown += PolygonZoomInAction;
            PolygonZoomOut.MouseLeftButtonDown += PolygonZoomOutAction;
            PolygonNavigateCenter.MouseLeftButtonDown += PolygonNavigateCenterAction;
        }

        private void PolygonNavigateUpAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(
                new GeneralMapTransformationMessage
                {
                    XMovement = 0,
                    YMovement = 100
                });
        }

        private void PolygonNavigateDownAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(
                new GeneralMapTransformationMessage
                {
                    XMovement = 0,
                    YMovement = -100
                });
        }

        private void PolygonNavigateLeftAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(
                new GeneralMapTransformationMessage
                {
                    XMovement = 100,
                    YMovement = 0
                });
        }

        private void PolygonNavigateRightAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(
                new GeneralMapTransformationMessage
                {
                    XMovement = -100,
                    YMovement = 0
                });
        }

        private void PolygonZoomInAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(new GeneralMapTransformationMessage
            {
                ZoomMultiplicator = 1.25
            });
        }

        private void PolygonZoomOutAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(new GeneralMapTransformationMessage
            {
                ZoomMultiplicator = 0.8
            });
        }

        private void PolygonNavigateCenterAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(new GeneralMapTransformationMessage
            {
                DoCenter = true
            });
        }
    }
}
