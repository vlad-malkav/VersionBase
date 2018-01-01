using System;
using Controls.Library.Models;
using Controls.Library.ViewModels;
using MyToolkit.Messaging;

namespace Controls.Library.Events
{
    #region Basic Messages

    public class HexViewModelMessage
    {
        public HexViewModel HexViewModel { get; set; }
    }

    public class HexModelMessage
    {
        public HexModel HexModel { get; set; }
    }

    public class HexCoordinatesMessage
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }

    #endregion

    public class HexClickedRightButtonMessage : HexViewModelMessage { }

    public class HexClickedLeftButtonMessage : HexViewModelMessage { }

    public class GetSelectedColorImageIdsRequestMessage : CallbackMessage<Tuple<string, string>>
    {
    }

    public class SelectHexMessage : HexCoordinatesMessage { }

    public class HexModelSelectedMessage : HexModelMessage { }

    public class HexModelUnselectedMessage : HexModelMessage { }

    public class HexViewModelSelectedMessage : HexViewModelMessage { }

    public class HexViewModelUnselectedMessage : HexViewModelMessage { }

    public class SetSelectedColorImageIdsRequestMessage
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

    public class MenuItemClickedMessage
    {
        public string Name { get; set; }
    }

    public class NewMessage
    {

    }

    public class LoadMessage
    {

    }

    public class SaveMessage
    {

    }

    public class QuitMessage
    {

    }

    public class GeneralMapTransformationMessage
    {
        public double XMovement { get; set; }
        public double YMovement { get; set; }
        public double ZoomMultiplicator { get; set; }
        public bool DoCenter { get; set; }
    }

    public class GetHexMapCanvasDimensionsRequestMessage : CallbackMessage<Tuple<double, double>>
    {
    }

    public class UpdateGameMode
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
