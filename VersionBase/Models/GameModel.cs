using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.General;

namespace VersionBase.Models
{
    public class GameModel : AbstractModel<GameData>
    {
        private HexMapModel _hexMapModel;

        public HexMapModel HexMapModel
        {
            get { return _hexMapModel; }
        }

        public override void ImportData(GameData data)
        {
            _hexMapModel = new HexMapModel();
            _hexMapModel.ImportData(data.HexMapData);
        }
    }
}
