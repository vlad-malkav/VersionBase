using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.General;

namespace VersionBase.Models
{
    public class GameModel : IModel<GameData>
    {
        private HexMapModel _hexMapModel;

        public HexMapModel HexMapModel
        {
            get { return _hexMapModel; }
        }

        public GameModel()
        {
            _hexMapModel = new HexMapModel();
        }

        public void ImportData(GameData data)
        {
            _hexMapModel.ImportData(data.HexMapData);
        }
    }
}
