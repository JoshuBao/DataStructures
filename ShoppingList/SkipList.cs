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


       
        public int Count{ get;private set;}

        public bool IsReadOnly => false;


        private int ChooseRandom(int max)
        {
            int height = 1;
            
            while (numgen.Next(2) == 0 || height < max)
            {
                height++;
            }
            return height;
        }



        class Node
        {
            
            T Value;
            public List<Node> Neighbors;
            public int Height => Neighbors.Count;
            public Node(T value, int height)
            {
                this.Value = value;
                Neighbors = new List<Node>(height);
                for (int i = 0; i < height; i++)
                {
                    Neighbors.Add(null);
                }
            }
        }


        public SkipList()
        {
            Head = new Node(default(T), 1);
            Count = 0;
        }


        public void Add(T item)
        {
            var newNode = new Node(item, ChooseRandom(Head.Height + 1));

            if(newNode.Height > Head.Height)
            {
                Head.Neighbors.Add(newNode);
            }

            var curr = Head; //if smaller change current
            int level = Head.Neighbors.Count - 1; //if bigger (or null) link new node if possible, move down
            while(level >= 0)
            {
                
            }
        }
        
        public void Clear()
        {
            Head.Neighbors = new List<Node>();
            Head.Neighbors.Add(null);
            Count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
