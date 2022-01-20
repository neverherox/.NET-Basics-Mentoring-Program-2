using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly IDoublyLinkedList<T> _dll;

        public HybridFlowProcessor()
        {
            _dll = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            try
            {
                return _dll.RemoveAt(0);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }

        public void Enqueue(T item)
        {
            _dll.Add(item);
        }

        public T Pop()
        {
            try
            {
                return _dll.RemoveAt(0);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }

        public void Push(T item)
        {
            _dll.AddAt(0, item);
        }
    }
}
