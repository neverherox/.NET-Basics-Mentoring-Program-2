using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public int Length { get; private set; }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public void Add(T e)
        {
            var node = new Node<T>(e);
            if (Tail == null)
            {
                Head = node;
            }
            else
            {
                node.Previous = Tail;
                Tail.Next = node;
            }
            Tail = node;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            var found = Find(index);
            if (found != null)
            {
                var node = new Node<T>(e);
                if (found == Head)
                {
                    found.Previous = node;
                    node.Next = found;
                    Head = node;
                }
                else
                {
                    node.Next = found;
                    node.Previous = found.Previous;
                    found.Previous.Next = node;
                    found.Previous = node;
                }
                Length++;
            }
            else
            {
                Add(e);
            }
        }

        public T ElementAt(int index)
        {
            var found = Find(index);
            return found != null? found.Value : throw new IndexOutOfRangeException();
        }

        public void Remove(T item)
        {
            var index = GetIndex(item);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public T RemoveAt(int index)
        {
            var found = Find(index);
            if (found != null)
            {
                if (found == Tail)
                {
                    Tail = found.Previous;
                }
                else
                {
                    found.Next.Previous = found.Previous;
                }

                if (found == Head)
                {
                    Head = found.Next;
                }
                else
                {
                    found.Previous.Next = found.Next;
                }
                var value = found.Value;
                Length--;
                return value;
            }
            throw new IndexOutOfRangeException();
        }


        public DoublyLinkedListEnumerator GetEnumerator()
        {
            return new DoublyLinkedListEnumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> Find(int index)
        {
            var counter = 0;
            using var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (counter == index)
                {
                    return enumerator.CurrentNode;
                }
                counter++;
            }
            return null;
        }

        private int GetIndex(T value)
        {
            var counter = 0;
            using var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                var currentValue = enumerator.Current;
                if (currentValue.Equals(value))
                {
                    return counter;
                }
                counter++;
            }
            return -1;
        }

        public struct DoublyLinkedListEnumerator : IEnumerator<T>
        {
            private readonly DoublyLinkedList<T> _dll;
            private Node<T> _currentNode;

            public DoublyLinkedListEnumerator(DoublyLinkedList<T> dll)
            {
                _dll = dll;
                _currentNode = null;
            }

            public bool MoveNext()
            {
                if (_currentNode == null)
                {
                    _currentNode = _dll.Head;
                }
                else
                {
                    _currentNode = _currentNode.Next;
                }
                return _currentNode != null;
            }

            public void Reset()
            {
                _currentNode = _dll.Head;
            }

            public T Current => _currentNode.Value;

            public Node<T> CurrentNode => _currentNode;

            object? IEnumerator.Current => Current;

            public void Dispose()
            {

            }
        }
    }
}
