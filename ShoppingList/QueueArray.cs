using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class QueueArray<T>
    {
        T[] Qtip;

        private int start;
        private int End => start + Count - 1;
        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;


        public QueueArray(int capacity = 10)
        {
            if (capacity < 1) capacity = 1;
            Count = 0;
            start = 3;
            Qtip = new T[capacity];
        }
        public void Resize(int size)
        {
            T[] temp = new T[size];
            for (int i = start, j = 0; i <= End; i++, j++)
            {
                temp[j] = Qtip[i];
            }
            Qtip = temp;
        }
        public void Enqueue(T Value)
        {
            if (End == Qtip.Length - 1)
            {
                Resize(Qtip.Length * 2);
            }
            Qtip[Count] = Value;
            Count++;
        }
        public void Dequeue()
        {
            if (Count == 0) throw new EmptyCollectionException();

            if (Count <= Qtip.Length / 4)
            {
                Resize(Qtip.Length / 2);
            }
            
            if (Count > 0)
            {
                start++;
            }
        }
        public T Peek()
        {
            if (Count == 0) throw new EmptyCollectionException();
            return Qtip[start];
        }









    }
}
