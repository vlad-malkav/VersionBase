using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.Library.Events;
using Controls.Library.Models;
using MyToolkit.Messaging;
using VersionBase.Data;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Model
{
    public class GameModel
    {
        private HexMapModel _hexMapModel;
        private TileEditorModel _tileEditorModel;

        public TileEditorModel TileEditorModel
        {
            get { return _tileEditorModel; }
        }

        public HexMapModel HexMapModel
        {
            get { return _hexMapModel; }
        }

        public GameModel()
        {
            _tileEditorModel = new TileEditorModel();
            _hexMapModel = new HexMapModel();
            Messenger.Default.Register<GetTileColorTileImageTypeModelsFromIdRequestMessage>(this, RequestSelectedColorImageIdsFunction);
            Messenger.Default.Register<UpdateColorImageModelsFromIdsMessage>(this, UpdateColorImageModelsFromIdsMessageFunction);
        }

        public void ImportGameData(GameData gameData)
        {
            _tileEditorModel.ImportListTileColor(gameData.ListTileColor);
            _tileEditorModel.ImportListTileImageType(gameData.ListTileImageType);
            _hexMapModel.ImportData(gameData.HexMapData);
        }

        public void UpdateColorImageModelsFromIdsMessageFunction(UpdateColorImageModelsFromIdsMessage msg)
        {
            UpdateColorImageModelsFromIds(
                msg.Column,
                msg.Row,
                msg.TileColorModelId,
                msg.TileImageTypeModelId);
        }

        public void UpdateColorImageModelsFromIds(int column, int row, string tileColorId, string tileImageTypeId)
        {
            _hexMapModel.GetHexModel(column, row).UpdateColorImageTypeModels(
                _tileEditorModel.GetTileColorModelFromId(tileColorId),
                _tileEditorModel.GetTileImageTypeModelFromId(tileImageTypeId));
        }

        private void RequestSelectedColorImageIdsFunction(GetTileColorTileImageTypeModelsFromIdRequestMessage msg)
        {
            msg.CallSuccessCallback(new Tuple<TileColorModel, TileImageTypeModel>(
                _tileEditorModel.GetTileColorModelFromId(msg.TileColorModelId),
                _tileEditorModel.GetTileImageTypeModelFromId(msg.TileImageTypeModelId)));
        }
    }
}
