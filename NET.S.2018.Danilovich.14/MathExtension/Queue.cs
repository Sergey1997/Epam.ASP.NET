using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtension
{
    public class Queue<T>
    {
        #region Fields
        private T[] array = default(T[]);
        private int head;
        private int tail;
        #endregion
        #region Constructors
        public Queue()
        {
            array = new T[0];
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
            Count = 0;
        }

        #endregion

        #region Properties
        public int Count { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add element to Queue
        /// </summary>
        /// <param name="item">element for adding</param>
        public void Add(T item)
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, array.Length + 1);
            }
            
            array[Count] = array[array.Length - 1];
            array[Count] = item;
            tail = (tail + 1) % array.Length;
            Count++;
        }

        /// <summary>
        /// Remove last element in queue
        /// </summary>
        /// <returns>Removed element</returns>
        public T Remove()
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
        #endregion
    }
}
