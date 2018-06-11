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
        int currentheightleft = 0;
        int rootleftcount = 0;
        bool left = true;
        int rootrightcount = 0;
        int currentheightright = 0;


       
        public AVLTree()
        {
            root = null;

        }


        public void BalanceHelp(AVLNode<T> current)
        {
          
        
            if (left)
            {
                if (current == root.Left)
                {
                    rootleftcount++;

                }
                if (rootleftcount == root.Left.ChildCount + 1)
                {
                    left = false;

                }
                if (current.Left != null)
                {
                    BalanceHelp(current.Left);

                }

                if (current.Right != null)
                {
                    BalanceHelp(current.Right);

                }
                if (current.Left == null && current.Right == null)
                {

                    if (HeighReturn(current) > currentheightleft)
                    {
                        currentheightleft = HeighReturn(current);

                    }


                }
            }
            if (left == false)
            {
                if (current == root.Right)
                {
                    rootrightcount++;

                }
                if (rootrightcount == root.Right.ChildCount + 1)
                {
                    if (currentheightleft - currentheightright == 1 || currentheightleft - currentheightright == -1 || currentheightleft - currentheightright == 0)
                    {
                        return;
                    }
                    else
                    {
                        // now you hav to do rotations
                        if (Count > 2)
                        {

                            //rotate here


                        }
                        else
                        {

                            return;                                                                                             
                        }

                    }
                }
                if (current.Left != null)
                {
                    BalanceHelp(current.Left);

                }

                if (current.Right != null)
                {
                    BalanceHelp(current.Right);

                }
                if (current.Left == null && current.Right == null)
                {

                    if (HeighReturn(current) > currentheightright)
                    {
                        currentheightright = HeighReturn(current);

                    }


                }

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

        public int HeighReturn(AVLNode<T> findthisnode)
        {

            T value = findthisnode.Value;
            int height = 0;
            var curr = root;
            while (curr != null)
            {
                if (value.CompareTo(curr.Value) < 0)
                {
                    curr = curr.Left;
                    height++;
                }
                else if (value.CompareTo(curr.Value) == 0)
                {

                    height++;

                    break;

                }
                else if (value.CompareTo(curr.Value) > 0)
                {
                    curr = curr.Right;
                    height++;

                }


            }
            return height;






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
