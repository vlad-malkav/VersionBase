namespace Controls.Library.Models
{
    public class GameModeModel
    {
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public GameModeModel() { }

        public void ImportGameModeData(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
