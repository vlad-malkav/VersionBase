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
        private List<TileColorModel> _listTileColorModel;
        private List<TileImageTypeModel> _listTileImageTypeModel;

        public List<TileColorModel> ListTileColorModel
        {
            get { return _listTileColorModel; }
        }

        public List<TileImageTypeModel> ListTileImageTypeModel
        {
            get { return _listTileImageTypeModel; }
        }

        public TileEditorModel()
        {
            _listTileColorModel = new List<TileColorModel>();
            _listTileImageTypeModel = new List<TileImageTypeModel>();
            Messenger.Default.Register<GetTileColorTileImageTypeModelsFromIdRequestMessage>(this, RequestSelectedColorImageIdsFunction);
        }

        public void ImportListTileColor(List<TileColor> listTileColor)
        {
            _listTileColorModel.Clear();
            foreach (var tileColor in listTileColor)
            {
                _listTileColorModel.Add(new TileColorModel(tileColor));
            }
        }

        public void ImportListTileImageType(List<TileImageType> listTileImageType)
        {
            _listTileImageTypeModel.Clear();
            foreach (var tileImageType in listTileImageType)
            {
                _listTileImageTypeModel.Add(new TileImageTypeModel(tileImageType));
            }
        }

        public TileColorModel GetTileColorModelFromId(string id)
        {
            return ListTileColorModel.FirstOrDefault(x => x.Id == id);
        }

        public TileImageTypeModel GetTileImageTypeModelFromId(string id)
        {
            return ListTileImageTypeModel.FirstOrDefault(x => x.Id == id);
        }

        private void RequestSelectedColorImageIdsFunction(GetTileColorTileImageTypeModelsFromIdRequestMessage msg)
        {
            msg.CallSuccessCallback(new Tuple<TileColorModel, TileImageTypeModel>(
                GetTileColorModelFromId(msg.TileColorModelId),
                GetTileImageTypeModelFromId(msg.TileImageTypeModelId)));
        }
    }
}
