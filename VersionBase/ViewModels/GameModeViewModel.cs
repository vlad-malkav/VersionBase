using VersionBase.Models;
using VersionBase.Libraries.Enums;

namespace VersionBase.ViewModels
{
    public class GameModeViewModel : ViewModel<GameModeModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameMode GameMode { get; set; }

        public GameModeViewModel()
        {

        }

        public override void ApplyModel(GameModeModel gameModeModel)
        {
            Id = gameModeModel.Id;
            Name = gameModeModel.Name;
            GameMode = gameModeModel.GameMode;
        }
    }
}
