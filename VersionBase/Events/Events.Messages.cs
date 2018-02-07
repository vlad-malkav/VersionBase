using System;
using System.Drawing;
using System.Windows.Media.Imaging;
using VersionBase.Models;
using VersionBase.ViewModels;
using MyToolkit.Messaging;
using VersionBase.Libraries.Enums;

namespace VersionBase.Events
{
    public abstract class BaseMessage
    {
        
    }

    #region Basic Messages

    public class HexViewModelMessage : BaseMessage
    {
        public HexViewModel HexViewModel { get; set; }
    }

    public class HexModelMessage : BaseMessage
    {
        public HexModel HexModel { get; set; }
    }

    public class HexCoordinatesMessage : BaseMessage
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }

    public class PointMessage : BaseMessage
    {
        public System.Windows.Point Point { get; set; }
    }

    public class HexPointMessage : PointMessage
    {
        public HexViewModel HexViewModel { get; set; }
    }

    #endregion

    public class HexClickedRightButtonMessage : HexPointMessage
    {
        public HexClickedRightButtonMessage(HexViewModel hexViewModel, System.Windows.Point point)
        {
            HexViewModel = hexViewModel;
            Point = point;
        }
    }

    public class HexClickedLeftButtonMessage : HexPointMessage
    {
        public HexClickedLeftButtonMessage(HexViewModel hexViewModel, System.Windows.Point point)
        {
            HexViewModel = hexViewModel;
            Point = point;
        }
    }

    public class AddPointMessage : HexPointMessage
    {
        public AddPointMessage(HexViewModel hexViewModel, System.Windows.Point point)
        {
            HexViewModel = hexViewModel;
            Point = point;
        }
    }

    public class GetSelectedColorImageIdsRequestMessage : CallbackMessage<Tuple<string, string>>
    {
    }

    public class SelectHexMessage : HexCoordinatesMessage { }

    public class HexModelSelectedMessage : HexModelMessage { }

    public class HexModelUnselectedMessage : HexModelMessage { }

    public class HexViewModelSelectedMessage : HexViewModelMessage { }

    public class HexViewModelUnselectedMessage : HexViewModelMessage { }

    public class SetSelectedColorImageIdsRequestMessage : BaseMessage
    {
        public string TileColorModelId { get; set; }
        public string TileImageModelId { get; set; }
    }

    public class GetTileColorTileImageModelsFromIdRequestMessage : CallbackMessage<Tuple<TileColorModel, TileImageModel>>
    {
        public string TileColorModelId { get; set; }
        public string TileImageModelId { get; set; }
    }

    public class GetHexModelFromPositionRequestMessage : CallbackMessage<HexModel>
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }

    public class UpdateHexColorImageModelsMessage : HexCoordinatesMessage
    {
        public TileColorModel TileColorModel { get; set; }
        public TileImageModel TileImageModel { get; set; }
    }

    public class UpdateHexDescriptionDegreExplorationMessage : HexCoordinatesMessage
    {
        public string Description { get; set; }
        public int DegreExploration { get; set; }
    }

    public class HexTileUpdatedMessage : HexModelMessage { }

    public class HexDegreExplorationUpdatedMessage : HexModelMessage { }

    public class MenuItemClickedMessage : BaseMessage
    {
        public string AssociatedActionName { get; set; }

        public MenuItemClickedMessage(string associatedActionName)
        {
            AssociatedActionName = associatedActionName;
        }
    }

    public class NewMessage : BaseMessage
    {

    }

    public class LoadMessage : BaseMessage
    {

    }

    public class SaveMessage : BaseMessage
    {

    }

    public class QuitMessage : BaseMessage
    {

    }

    public class MapTransformationTypeBroadcastMessage : BaseMessage
    {
        public MapTransformationType MapTransformationType { get; set; }

        public MapTransformationTypeBroadcastMessage() { }

        public MapTransformationTypeBroadcastMessage(MapTransformationType mapTransformationType)
        {
            MapTransformationType = mapTransformationType;
        }
    }

    public class MapTransformationRequestMessage : BaseMessage
    {
        public double XMovement { get; set; }
        public double YMovement { get; set; }
        public double ZoomMultiplicator { get; set; }
        public bool DoCenter { get; set; }
    }

    public class GetHexMapCanvasDimensionsRequestMessage : CallbackMessage<Tuple<double, double>>
    {
    }

    public class UpdateGameModeMessage : BaseMessage
    {
        public GameMode GameMode { get; set; }
    }

    public class GetBitmapImageByNameMessage : CallbackMessage<BitmapImage>
    {
        public string ImageName { get; set; }

        public GetBitmapImageByNameMessage(string imageName)
        {
            ImageName = imageName;
        }
    }

    public class GetBitmapByNameMessage : CallbackMessage<Bitmap>
    {
        public string ImageName { get; set; }

        public GetBitmapByNameMessage(string imageName)
        {
            ImageName = imageName;
        }
    }
}
