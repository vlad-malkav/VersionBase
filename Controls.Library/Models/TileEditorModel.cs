using System;
using System.Collections.Generic;
using System.Linq;
using Controls.Library.Events;
using MyToolkit.Messaging;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Models
{
    public class TileEditorModel
    {
        public List<TileColorModel> ListTileColorModel { get; set; }
        public List<TileImageTypeModel> ListTileImageTypeModel { get; set; }

        public TileEditorModel(List<TileColor> listTileColor, List<TileImageType> listTileImageType)
        {
            ListTileColorModel = listTileColor.Select(x => new TileColorModel(x)).ToList();
            ListTileImageTypeModel = listTileImageType.Select(x => new TileImageTypeModel(x)).ToList();
            Messenger.Default.Register<GetTileColorTileImageTypeModelsFromIdRequestMessage>(this, RequestSelectedColorImageIds);
        }

        private void RequestSelectedColorImageIds(GetTileColorTileImageTypeModelsFromIdRequestMessage msg)
        {
            msg.CallSuccessCallback(new Tuple<TileColorModel, TileImageTypeModel>(
                GetTileColorModelFromId(msg.TileColorModelId),
                GetTileImageTypeModelFromId(msg.TileImageTypeModelId)));
        }

        public TileColorModel GetTileColorModelFromId(string id)
        {
            return ListTileColorModel.FirstOrDefault(x => x.Id == id);
        }

        public TileImageTypeModel GetTileImageTypeModelFromId(string id)
        {
            return ListTileImageTypeModel.FirstOrDefault(x => x.Id == id);
        }
    }
}
