using Controls.Library.Models;

namespace Controls.Library.ViewModels
{
    public class GameModeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GameModeViewModel()
        {

        }

        public void ApplyModel(GameModeModel gameModeModel)
        {
            Id = gameModeModel.Id;
            Name = gameModeModel.Name;
        }
    }
}
