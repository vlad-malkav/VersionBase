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
        private List<TileImageModel> _listTileImageModel;

        public List<TileColorModel> ListTileColorModel
        {
            get { return _listTileColorModel; }
        }

        public List<TileImageModel> ListTileImageModel
        {
            get { return _listTileImageModel; }
        }

        public TileEditorModel()
        {
            _listTileColorModel = new List<TileColorModel>();
            _listTileImageModel = new List<TileImageModel>();
            Messenger.Default.Register<GetTileColorTileImageModelsFromIdRequestMessage>(this, RequestSelectedColorImageIdsFunction);
        }

        public void ImportListTileColor(List<TileColor> listTileColor)
        {
            _listTileColorModel.Clear();
            foreach (var tileColor in listTileColor)
            {
                _listTileColorModel.Add(new TileColorModel(tileColor));
            }
        }

        public void ImportListTileImage(List<TileImage> listTileImage)
        {
            _listTileImageModel.Clear();
            foreach (var tileImage in listTileImage)
            {
                _listTileImageModel.Add(new TileImageModel(tileImage));
            }
        }

        public TileColorModel GetTileColorModelFromId(string id)
        {
            return ListTileColorModel.FirstOrDefault(x => x.Id == id);
        }

        public TileImageModel GetTileImageModelFromId(string id)
        {
            return ListTileImageModel.FirstOrDefault(x => x.Id == id);
        }

        private void RequestSelectedColorImageIdsFunction(GetTileColorTileImageModelsFromIdRequestMessage msg)
        {
            msg.CallSuccessCallback(new Tuple<TileColorModel, TileImageModel>(
                GetTileColorModelFromId(msg.TileColorModelId),
                GetTileImageModelFromId(msg.TileImageModelId)));
        }
    }
}
