using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class AVLNode<T> where T : IComparable<T>
    {
        public AVLNode<T> Left;
        public AVLNode<T> Right;
        public T Value;
        public int Height;



        public int ChildCount
        {
            get
            {
                int count = 0;
                if (Left != null) count++;
                if (Right != null) count++;
                return count;
            }
        }
        public bool IsLeafNode()
        {
            if (ChildCount == 0)
            {
                return true;
            }
            return false;

        }
  
        
        public AVLNode(T value)
        {

            Value = value;
            Left = null;
            Right = null;


        }

    }










}

