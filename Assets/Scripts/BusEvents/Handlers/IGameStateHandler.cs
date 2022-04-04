namespace BusEvents.Handlers
{
    public interface IGameStateHandler : IGlobalSubscriber
    {
        void Win();
        void Lose();
    }
}