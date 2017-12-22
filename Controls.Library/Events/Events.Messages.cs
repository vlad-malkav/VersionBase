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
        public string TileImageTypeModelId { get; set; }
    }

    public class GetTileColorTileImageTypeModelsFromIdRequestMessage : CallbackMessage<Tuple<TileColorModel, TileImageTypeModel>>
    {
        public string TileColorModelId { get; set; }
        public string TileImageTypeModelId { get; set; }
    }

    public class GetHexModelFromPositionRequestMessage : CallbackMessage<HexModel>
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }

    public class UpdateHexColorImageModelsMessage : HexCoordinatesMessage
    {
        public TileColorModel TileColorModel { get; set; }
        public TileImageTypeModel TileImageTypeModel { get; set; }
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

    public class LoadMessage
    {

    }

    public class SaveMessage
    {

    }

    public class QuitMessage
    {

    }

    public class MoveCanvasRequestMessage
    {
        public double XMovement { get; set; }
        public double YMovement { get; set; }

        public MoveCanvasRequestMessage() { }

        public MoveCanvasRequestMessage(double xMovement, double yMovement)
        {
            XMovement = xMovement;
            YMovement = yMovement;
        }
    }
}
