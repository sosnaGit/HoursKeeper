namespace HoursKeeper.Application.Interfaces
{
    public interface IHandleEvent
    {
    }

    public interface IHandleEvent<TEvent> : IHandleEvent
        where TEvent : IEvent
    {
        void Publish(TEvent @event);
    }
}
