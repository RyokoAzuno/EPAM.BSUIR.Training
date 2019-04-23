using System;

namespace MyQueue
{
    /// <summary>
    /// Class represents custom queue(First-In First-Out) collection
    /// </summary>
    public class Queue<T>
    {
        // Generic array for storing data
        private T[] items;

        // Head index
        private int head;

        // Tail index
        private int tail;

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

            items = new T[size];
            head = tail = 0;
        }

        // Add element into queue and resize dynamically when it's necessary
        public void Enqueue(T value)
        {
            if (tail >= items.Length)
            {
                T[] newItems = new T[items.Length * 2];
                items.CopyTo(newItems, 0);
                items = newItems;
            }

            items[tail] = value;
            ++tail;
        }

        // Remove element from queue
        public T Dequeue()
        {
            if (!IsEmpty())
            {
                T curr = items[head];
                items[head] = default(T);
                ++head;
                return curr;
            }

            return default(T);
        }

        // Get first(head) element in da queue without removing it
        public T Peek()
        {
            return items[head];
        }

        // Get last(tail) element in da queue without removing it
        public T Last()
        {
            return items[tail - 1];
        }

        // Check if current queue is empty
        public bool IsEmpty()
        {
            return head == tail;
        }

        // Convert current queue to array
        public T[] ToArray()
        {
            T[] arr = new T[tail];
            Array.Copy(items, 0, arr, 0, tail);

            return arr;
        }
    }
}
