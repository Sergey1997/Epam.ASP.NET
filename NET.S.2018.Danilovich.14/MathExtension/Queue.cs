using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtension
{
    public class Queue<T> : IEnumerable<T>
    {
        #region Fields
        private T[] array = default(T[]);
        private int head;
        private int tail;
        private int version;
        #endregion
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Queue()
        {
            array = new T[0];
            head = 0;
            tail = 0;
            version = 0;
            Count = 0;
        }

        /// <summary>
        /// Constructor of queue
        /// </summary>
        /// <param name="size">size of queue</param>
        public Queue(uint size)
        {
            array = new T[size];
            head = 0;
            tail = 0;
            version = 0;
            Count = 0;
        }

        #endregion

        #region Properties
        public int Count { get; private set; }
        
        /// <summary>
        /// Indexer 
        /// </summary>
        /// <param name="index">index of array</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return array[index];
            }

            private set
            {
                array[index] = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add element to Queue
        /// </summary>
        /// <param name="item">element for adding</param>
        public void Enqueue(T item)
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, array.Length + 1);
            }
            
            array[Count] = array[array.Length - 1];
            array[Count] = item;
            tail = (tail + 1) % array.Length;
            Count++;
            version++;
        }

        /// <summary>
        /// Remove last element in queue
        /// </summary>
        /// <returns>Removed element</returns>
        public T Dequeue()
        {   
            if (Count == 0)
            {
                throw new InvalidOperationException("Exception_Empty_Queue");
            }

            T removed = array[head];
            Array.Reverse(array);
            Array.Resize(ref array, array.Length - 1);
            Array.Reverse(array);
            if (array.Length != 0)
            {
                head = (head + 1) % array.Length;
            }
            else
            {
                head = 0;
            }

            Count--;
            version++;
            return removed;
        }

        /// <summary>
        /// Reset all items in the queue
        /// </summary>
        public void Clear()
        {
            Console.WriteLine(Count);
            if (head < tail)
            {
                Array.Clear(array, 0, Count);
            }
            else
            {
                Array.Clear(array, head, array.Length - head);
                Array.Clear(array, 0, tail);
            }

            head = 0;
            tail = 0;
            Count = 0;
        }

        /// <summary>
        /// Check for contains element in queue
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true or false in depend of result</returns>
        public bool Contains(T item)
        {
            int index = head;
            int count = Count;

            while (count-- > 0)
            {
                if (item == null)
                {
                    if (array[index] == null)
                    {
                        return true;
                    }
                }
                else if (array[index] != null && array[index].Equals(item))
                {
                    return true;
                }

                index = (index + 1) % array.Length;
            }

            return false;
        }

        /// <summary>
        /// moves elements of queue to T array
        /// </summary>
        /// <returns>array of elements</returns>
        public T[] ToArray()
        {
            T[] arr = new T[Count];
            if (Count == 0)
            {
                return arr;
            }

            if (head < tail)
            {
                Array.Copy(array, head, arr, 0, Count);
            }
            else
            {
                Array.Copy(array, head, arr, 0, array.Length - head);
                Array.Copy(array, 0, arr, array.Length - head, tail);
            }

            return arr;
        }
        
        public IEnumerator<T> GetEnumerator() => new Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => array.GetEnumerator();

        /// <summary>
        /// struct Enumerator for foreach
        /// </summary>
        private struct Enumerator : IEnumerator<T>
        {
            private readonly Queue<T> queue;
            private readonly int version;
            private T currentElement;
            private int index;

            public Enumerator(Queue<T> queue)
            {
                this.queue = queue;
                version = queue.version;
                index = 0;
                currentElement = default(T);
                if (queue.Count == 0)
                {
                    index = -1;
                }
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    if (index == 0 || index > queue.Count)
                    {
                        throw new ArgumentException($"{(nameof(index))} doesnt correct");
                    }

                    return currentElement;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index > queue.Count)
                    {
                        throw new ArgumentException($"{(nameof(index))} doesnt correct");
                    }

                    return currentElement;
                }
            }

            public bool MoveNext()
            {
                if (version != queue.version)
                {
                    throw new InvalidOperationException("Queue was changed!");
                }

                if (index < 0)
                {
                    currentElement = default(T);
                    return false;
                }

                currentElement = queue[index];
                index++;
                if (index == queue.Count)
                {
                    index = -1;
                }

                return true;
            }

            void IDisposable.Dispose()
            {
            }

            public void Reset()
            {
                if (version != queue.version)
                {
                    throw new InvalidOperationException("Queue was changed!");
                }

                index = 0;
            }
        }
        #endregion
    }
}
