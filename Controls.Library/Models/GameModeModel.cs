using VersionBase.Libraries.Enums;

namespace Controls.Library.Models
{
    public class GameModeModel
    {
        private int _id;
        private string _name;
        private GameMode _gameMode;

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public GameMode GameMode
        {
            get { return _gameMode; }
        }

        public GameModeModel() { }

        public void ImportGameModeData(GameMode gameMode)
        {
            _gameMode = gameMode;
            _id = (int)GameMode;
            _name = EnumFunctions.GetDescription(GameMode);
        }
    }
}
