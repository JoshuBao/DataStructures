using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        private Node root;
        public int Count { get; private set; }
        
        class Node
        {
            public T Value;
            public Node Left;
            public Node Right;
            public bool IsRed;

            public Node(T value)
            {
                Value = value;
                IsRed = true;
            }
        }

        //overloading methods
        public void Add(T value) //
        {
            root = Add(root, value);
        }

        //recursivly
        private Node Add(Node curr, T value) //calls itself
        {
            
            if(curr == null)
            {
                return new Node(value);
            }

            //as we go down the tree


            //recursive segment
            if(value.CompareTo(curr.Value) < 0)
            {
                curr.Left = Add(curr.Left, value);
            }
            else if (value.CompareTo(curr.Value) > 0)
            {
                curr.Right = Add(curr.Right, value);
            }
            else if (value.CompareTo(curr.Value) == 0)
            {
                throw new Exception("lol kid no duplicates xdxd lol asterics rawr");
            }

            //as we go up the tree


            return curr;
        }

        //RotateLeft
        //RotateRight

        //FlipColor
        public void FlipColor(Node node)
        {

        }
        //Fixup


    }
}
