using System;
using System.Collections.Generic;
using System.Linq;
using DataLibrary.Tiles;
using VersionBase.Events;
using MyToolkit.Messaging;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Models
{
    public class UITileEditorModel
    {
        private List<UITileColorModel> _listTileColorModel;
        private List<UITileImageModel> _listTileImageModel;

        public List<UITileColorModel> ListTileColorModel
        {
            get { return _listTileColorModel; }
        }

        public List<UITileImageModel> ListTileImageModel
        {
            get { return _listTileImageModel; }
        }

        public UITileEditorModel()
        {
            _listTileColorModel = new List<UITileColorModel>();
            _listTileImageModel = new List<UITileImageModel>();
            Messenger.Default.Register<GetTileColorTileImageModelsFromIdRequestMessage>(this, RequestSelectedColorImageIdsFunction);
        }

        public void ImportListTileColor(List<TileColorData> listTileColor)
        {
            _listTileColorModel.Clear();
            foreach (var tileColor in listTileColor)
            {
                UITileColorModel tileColorModelTmp = new UITileColorModel();
                tileColorModelTmp.ImportData(tileColor);
                _listTileColorModel.Add(tileColorModelTmp);
            }
        }

        public void ImportListTileImage(List<TileImageData> listTileImage)
        {
            _listTileImageModel.Clear();
            foreach (var tileImage in listTileImage)
            {
                UITileImageModel tileImageModelTmp = new UITileImageModel();
                tileImageModelTmp.ImportData(tileImage);
                _listTileImageModel.Add(tileImageModelTmp);
            }
        }

        public UITileColorModel GetTileColorModelFromId(string id)
        {
            return ListTileColorModel.FirstOrDefault(x => x.Id == id);
        }

        public UITileImageModel GetTileImageModelFromId(string id)
        {
            return ListTileImageModel.FirstOrDefault(x => x.Id == id);
        }

        private void RequestSelectedColorImageIdsFunction(GetTileColorTileImageModelsFromIdRequestMessage msg)
        {
            msg.CallSuccessCallback(new Tuple<UITileColorModel, UITileImageModel>(
                GetTileColorModelFromId(msg.TileColorModelId),
                GetTileImageModelFromId(msg.TileImageModelId)));
        }
    }
}
