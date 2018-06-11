using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class AVLTree<T> where T : IComparable<T>
    {
        public AVLNode<T> root;
        public int Count { get; private set; }
        public bool IsEmpty => root == null;

       
        public AVLTree()
        {
            root = null;

        }


        public void Balance(AVLNode<T> current)
        {
            
            if(root.GetBalance() < -1 )
            {
                //too heavy on left, rotate right
                RotateRight(current);

            }
            else if (root.GetBalance() > 1)
            {
                //too heavy on right, rotate left
                RotateLeft(current);
            }

        }

        private AVLNode<T> RotateLeft(AVLNode<T> node)
        {
            var child = node.Right;

            node.Right = child.Left;
            child.Left = node;
        
            return child;
        }

        private AVLNode<T> RotateRight(AVLNode<T> node)
        {
            var child = node.Left;

            node.Left = child.Right;
            child.Right = node;

            return child;
        }

        #region Adding
        public void Adding(T value)
        {
            if (root == null)
            {
                root.Value = value;
                return;

            }
            var curr = root;
            while (curr != null)
            {
                if (value.CompareTo(curr.Value) < 0)
                {
                    if (curr.Left == null)
                    {
                        curr.Left = new AVLNode<T>(value);
                        Count++;
                        break;
                    }
                    else
                    {
                        curr = curr.Left;
                    }
                }
                else if (value.CompareTo(curr.Value) == 0)
                {
                    throw new InvalidOperationException("u zucc and duplicates r not allowed boi");

                }
                else if (value.CompareTo(curr.Value) > 0)
                {
                    if (curr.Right == null)
                    {
                        curr.Right = new AVLNode<T>(value);
                        Count++;
                        break;
                        
                    }
                    else
                    {
                        curr = curr.Right;
                    }


                }


            }



        }
        #endregion
    }
}
