namespace VersionBase.Logic
{
    public class GameLogic
    {
        public EventLogic EventLogic { get; set; }

        public GameLogic()
        {
            EventLogic = new EventLogic();
            EventLogic.SubscribeToEvents();
        }
    }
}
