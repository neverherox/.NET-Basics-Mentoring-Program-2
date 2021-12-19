namespace FileSystemVisitorLibrary.Interfaces
{
    public interface IEventSubscriber<T> where T: class
    {
        void Subscribe(T publisher);

        void Unsubscribe(T publisher);
    }
}
