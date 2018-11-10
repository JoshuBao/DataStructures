using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class SkipList<T> : ICollection<T>
    {
        Random numgen = new Random();

        Node Head;
        public IComparer<T> Comparer { get; private set; }


        public int Count { get; private set; }

        public bool IsReadOnly => false;


        private int ChooseRandom(int max)
        {
            int height = 1;

            while (numgen.Next(2) == 0 && height < max)
            {
                height++;
            }
            return height;
        }



        class Node
        {

            public T Value;
            public Node[] Neighbors;
            public int Height => Neighbors.Length;
            public Node(T value, int height)
            {
                this.Value = value;
                Neighbors = new Node[height];
                for (int i = 0; i < height; i++)
                {
                    Neighbors[i] = null;
                }
            }
        }


        public SkipList() : this(null) { }
        public SkipList(IComparer<T> comparer)
        {
            this.Comparer = comparer ?? Comparer<T>.Default;
            Head = new Node(default(T), 1);
            Count = 0;
        }


        public void Add(T item)
        {
            Node temp = new Node(item, ChooseRandom(Head.Height + 1));

            if (temp.Height > Head.Height)
            {
                Node[] tmp = new Node[Head.Neighbors.Length + 1];

                for (int i = 0; i < Head.Neighbors.Length; i++)
                {
                    tmp[i] = Head.Neighbors[i];
                }
                Head.Neighbors = tmp;
                //increase the size of the head neighbors array*
            }

            var curr = Head; //if smaller change current
            int level = Head.Neighbors.Length - 1; //if bigger (or null) link new node if possible, move down
            while (level >= 0)
            {
                int comparison = curr.Neighbors[level] == null ? 1 : Comparer.Compare(curr.Neighbors[level].Value, item);

                if (comparison > 0)
                {
                    //link and move down
                    if (temp.Height > level)
                    {
                        temp.Neighbors[level] = curr.Neighbors[level];
                        curr.Neighbors[level] = temp;
                    }
                    level--;
                }
                else if (comparison < 0)
                {
                    //move right
                    curr = curr.Neighbors[level];
                }
                else if (comparison == 0)
                {
                    throw new Exception("No Duplicates haha alex tis bad");
                }

            }

            Count++;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var curr = Head; //if smaller change current
            int level = Head.Neighbors.Length - 1; //if bigger (or null) link new node if possible, move down
            while (level >= 0)
            {
                int comparison = curr.Neighbors[level] == null ? 1 : Comparer.Compare(curr.Neighbors[level].Value, item);

                if (comparison > 0)
                {
                    level--;
                }
                else if (comparison < 0)
                {
                    //move right
                    curr = curr.Neighbors[level];
                }
                else if (comparison == 0)
                {
                    return true;
                }
            }
            return false;


        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (array.Length < Count + arrayIndex)
            {
                throw new ArgumentException("alex is oof and array too long");
            }
            foreach (var value in this)
            {
                array[arrayIndex] = value;
                arrayIndex++;
            }
           
        }


        //enum thing ***
        public bool Remove(T item)
        {
            bool removal = false;
            var curr = Head; //if smaller change current
            int level = Head.Neighbors.Length - 1; //if bigger (or null) link new node if possible, move down
            while (level >= 0)
            {
                int comparison = curr.Neighbors[level] == null ? 1 : Comparer.Compare(curr.Neighbors[level].Value, item);

                if (comparison > 0)
                {
                    level--;
                }
                else if (comparison < 0)
                {
                    //move right
                    curr = curr.Neighbors[level];
                }
                else if (comparison == 0)
                {

                    removal = true;

                    curr.Neighbors[level] = curr.Neighbors[level].Neighbors[level];
                    level--;
                    //delete here
                }

            }


            if (removal)
            {
                Count--;
            }
            return removal;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node current = Head.Neighbors[0]; current.Neighbors[0] != null; current = current.Neighbors[0])
            {
                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}



//lol hi