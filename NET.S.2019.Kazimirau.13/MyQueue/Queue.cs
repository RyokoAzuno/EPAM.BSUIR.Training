using System;

namespace MyQueue
{
    /// <summary>
    /// Class represents custom queue(First-In First-Out) collection
    /// </summary>
    public class Queue<T>
    {
        // Generic array for storing data
        private T[] _items;

        // Head index
        private int _head;

        // Tail index
        private int _tail;

        // Default constructor
        public Queue() : this(5)
        {
        }

        // Overloaded constructor with 1 parameter(size - max elements into queue)
        public Queue(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size must be > 0(zero)!");
            }

            _items = new T[size];
            _head = _tail = 0;
        }

        // Private indexer for Enumerator class
        private T this[int index]
        {
            get
            {
                return _items[index];
            }
        }

        // Add element into queue and resize dynamically when it's necessary
        public void Enqueue(T value)
        {
            if (_tail >= _items.Length)
            {
                T[] newItems = new T[_items.Length * 2];
                _items.CopyTo(newItems, 0);
                _items = newItems;
            }

            _items[_tail] = value;
            ++_tail;
        }

        // Remove element from queue
        public T Dequeue()
        {
            if (!IsEmpty())
            {
                T curr = _items[_head];
                _items[_head] = default(T);
                ++_head;

                return curr;
            }

            return default(T);
        }

        // Get first(head) element in da queue without removing it
        public T Peek()
        {
            return _items[_head];
        }

        // Get last(tail) element in da queue without removing it
        public T Last()
        {
            return _items[_tail - 1];
        }

        // Check if current queue is empty
        public bool IsEmpty()
        {
            return _head == _tail;
        }

        // Convert current queue to array
        public T[] ToArray()
        {
            T[] arr = new T[_tail];
            Array.Copy(_items, 0, arr, 0, _tail);

            return arr;
        }

        // Get Enumerator
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        // Class represents custom enumerator
        public class Enumerator
        {
            private readonly Queue<T> _collection;
            private int _index;

            public Enumerator(Queue<T> collection)
            {
                _collection = collection;
                _index = -1;
            }

            public T Current
            {
                get
                {
                    if (_index == -1 || _index == _collection._tail)
                    {
                        throw new InvalidOperationException();
                    }

                    return _collection[_index];
                }
            }

            public bool MoveNext()
            {
                return ++_index < _collection._tail;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
