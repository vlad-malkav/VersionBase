using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Models;

namespace VersionBase.ViewModels
{
    public class GameViewModel : AbstractViewModel<GameModel>
    {
        public HexMapViewModel HexMapViewModel { get; set; }

        public override void ApplyModel(GameModel model)
        {
            HexMapViewModel = new HexMapViewModel();
            HexMapViewModel.ApplyModel(model.HexMapModel);
        }
    }
}
