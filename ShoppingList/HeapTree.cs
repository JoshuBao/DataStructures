using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class HeapTree<T> where T : IComparable<T>
    {

        private Node root;
        public int count { get; private set; }
        public T[] Heap = new T[10];


        class Node
        {
            public T Value;
            public Node Right;
        }



        public void insert(T value)
        {
            if (count == Heap.Length )
            {
                Resize(Heap);
            }
            Heap[count] = value;

            count++;
            HeapifyUp(count - 1);


        }
        public void pop()
        {

            if (count == 0) throw new InvalidOperationException("Heap is empty");


            


            T value = Heap[0];
            Heap[0] = Heap[count - 1];
            count--;
            HeapifyDown(0);


        }
        public void HeapifyDown(int i)
        {
            int master = i;
            int left = LeftChild(i);
            int right = RightChild(i);

            if (left < count && Heap[master].CompareTo(Heap[left]) >= 0)
            {
                master = left;
            }

            if (right < count && Heap[master].CompareTo(Heap[right]) >= 0)
            {
                master = right;
            }

            if (master == i) return;

            Swap(i, master);
            HeapifyDown(master);

        }
        public static int Parent(int i)
        {
            return (i - 1) / 2;
        }

        public static int LeftChild(int i)
        {
            return (i * 2) + 1;
        }

        public static int RightChild(int i)
        {
            return (i * 2) + 2;
        }

        private void HeapifyUp(int i)
        {
            int parent = Parent(i);
            if (i == 0 || Heap[i].CompareTo(Heap[parent]) >= 0)
            {

                return;
            }
            Swap(i, parent);
            HeapifyUp(parent);

        }
        private void Swap(int i, int j)
        {
            T tmp = Heap[i];
            Heap[i] = Heap[j];
            Heap[j] = tmp;
        }





        private void Resize(T[] Heap)
        {
            T[] tmp = new T[Heap.Length*2];
            for (int i = 0; i < Heap.Length; i++)
            {
                tmp[i] = Heap[i];

            }
            Heap = tmp;
            

        }








    }
}
