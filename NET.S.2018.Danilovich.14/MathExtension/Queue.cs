using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtension
{
    public class Queue<T>
    {
        private T[] array = default(T[]);
        private int head;
        private int tail;
        public uint Count { get; private set; }
        
        public Queue()
        {
            array = new T[0];
        }
        public Queue(uint size)
        {
            array = new T[size];
            head = 0;
            tail = 0;
            Count = size;
        }
        public void Add(T item)
        {
            if(Count == array.Length)
            {
                Array.Resize<T>(ref array, array.Length + 1);
                Count++;
            }
            array[tail] = item;
            tail = (tail + 1) % array.Length;
            Count++;
        }

    }
}
