using System.Windows.Controls;
using System.Windows.Input;
using VersionBase.Events;
using MyToolkit.Messaging;
using VersionBase.Libraries.Enums;

namespace VersionBase.Views
{
    /// <summary>
    /// Interaction logic for UIMapTransformPad.xaml
    /// </summary>
    public partial class UIMapTransformPad : UserControl
    {
        public UIMapTransformPad()
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
            Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveUp));
        }

        private void PolygonNavigateDownAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveDown));
        }

        private void PolygonNavigateLeftAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveLeft));
        }

        private void PolygonNavigateRightAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.MoveRight));
        }

        private void PolygonZoomInAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.ZoomIn));
        }

        private void PolygonZoomOutAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.ZoomOut));
        }

        private void PolygonNavigateCenterAction(object sender, MouseButtonEventArgs e)
        {
            // Broadcast Events
            Messenger.Default.Send(new MapTransformationTypeBroadcastMessage(MapTransformationType.Recenter));
        }
    }
}
