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

        public GameViewModel()
        {
            HexMapViewModel = new HexMapViewModel();
        }

        public override void ApplyModel(GameModel model)
        {
            HexMapViewModel.ApplyModel(model.HexMapModel);
        }
    }
}
