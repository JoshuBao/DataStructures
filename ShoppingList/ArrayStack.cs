using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class ArrayStack<T>
    {
        T[] Bigstack;
        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public int Counter => Count;

        public ArrayStack(int capacity = 10)
        {
            if (capacity < 1) capacity = 1;
            Count = 0;
            Bigstack = new T[capacity];
        }

        public void Resize(int size)
        {


            T[] temp = new T[size];
            for (int i = 0; i < Bigstack.Length; i++)
            {
                temp[i] = Bigstack[i];
            }
            Bigstack = temp;
        }

        public void Push(T Value)
        {
            if (Count == Bigstack.Length)
            {
                Resize(Bigstack.Length * 2);
            }
            Bigstack[Count] = Value;
            Count++;
        }
        public void Pop()
        {
        //    if (Count <= Bigstack.Length / 4)
        //    {
        //        Resize(Bigstack.Length / 2);
        //    }

            if (Count > 0)
            {
                Count--;
            }
        }




    }
}
