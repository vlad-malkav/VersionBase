using System;
using Controls.Library.Models;
using MyToolkit.Messaging;

namespace Controls.Library.Events
{
    public class HexClickedRightButtonMessage
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }

    public class HexClickedLeftButtonMessage
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }

    public class GetSelectedColorImageIdsRequestMessage : CallbackMessage<Tuple<string, string>>
    {
    }

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

    public class UpdateColorImageModelsFromIdsMessage
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public string TileColorModelId { get; set; }
        public string TileImageTypeModelId { get; set; }
    }

    public class HexModelUpdatedMessage
    {
        public HexModel HexModel { get; set; }
    }

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
}
