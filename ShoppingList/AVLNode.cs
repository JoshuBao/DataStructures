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
        public AVLNode<T> Parent;
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

        public void FixHeight()
        {
            int leftHeight = 0;
            int rightHeight = 0;
            if(Left != null)
            {
                leftHeight = Left.Height;
            }
            if(Right != null)
            {
                rightHeight = Right.Height;
            }

            Height = Math.Max(leftHeight, rightHeight) + 1;
        }

        //get balance function here
        public int GetBalance()
        {
            int rightHeight = Right == null ? 0 : Right.Height;
            int leftHeight = Left == null ? 0 : Left.Height;
            int balance = rightHeight - leftHeight;
            return balance;
        }
  
        
        public AVLNode(T value, AVLNode<T> parent = null)
        {

            Value = value;
            Left = null;
            Right = null;
            Height = 1;
            this.Parent = parent;
        }

    }










}

