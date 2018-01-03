using Controls.Library.Models;
using VersionBase.Libraries.Enums;

namespace Controls.Library.ViewModels
{
    public class GameModeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameMode GameMode { get; set; }

        public GameModeViewModel()
        {

        }

        public void ApplyModel(GameModeModel gameModeModel)
        {
            Id = gameModeModel.Id;
            Name = gameModeModel.Name;
            GameMode = gameModeModel.GameMode;
        }
    }
}
