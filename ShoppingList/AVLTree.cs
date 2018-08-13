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
            current.FixHeight();

            if (current.GetBalance() < -1)
            {
                if (current.Left.GetBalance() > 0)
                {
                    RotateLeft(current.Left);
                }

                RotateRight(current);

            }
            else if (current.GetBalance() > 1)
            {
                //too heavy on right, rotate left

                if (current.Right.GetBalance() < 0)
                {
                    RotateRight(current.Right);

                }

                RotateLeft(current);
            }


            if(current.Parent != null)
            {
                Balance(current.Parent);
            }
        }

        private AVLNode<T> RotateLeft(AVLNode<T> node)
        {
            var parent = node.Parent;
            var child = node.Right;
            var childleft = child.Left;

            //Node
            node.Right = childleft;
            node.Parent = child;
            
            //Child
            child.Left = node;
            child.Parent = parent;

            if(node == root)
            {
                root = child;
            }

            //Possible GChild
            if (childleft != null)
            {
                childleft.Parent = node;
            }
             
            //Possible Parent
            if (parent != null)
            {
                if (parent.Right == node)
                {

                    parent.Right = child;
                }
                else
                {

                    parent.Left = child;
                }
            }

            node.FixHeight();
            child.FixHeight();

            return child;
        }

        private AVLNode<T> RotateRight(AVLNode<T> node)
        {
            var parent = node.Parent;
            var child = node.Left;
            var cat = child.Right;

            //child
            child.Right = node;
            child.Parent = parent;

            //node stuff
            node.Left = cat;
            node.Parent = child;

            if (node == root)
            {
                root = child;
            }

            //cat stuff
            if (cat != null)
            {
                cat.Parent = node;
            }

            //parent stuff
            if (parent != null)
            {
                if (parent.Left == node)
                {
                    parent.Left = child;
                }
                else
                {
                    parent.Right = child;
                }
            }

            node.FixHeight();
            child.FixHeight();

            return child;
        }
        
        #region Adding
        public void Add(T value)
        {
            if (root == null)
            {
                root = new AVLNode<T>(value);
                return;

            }
            var curr = root;
            while (curr != null)
            {
                if (value.CompareTo(curr.Value) < 0)
                {
                    if (curr.Left == null)
                    {
                        curr.Left = new AVLNode<T>(value, curr);
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
                        curr.Right = new AVLNode<T>(value, curr);
                        Count++;
                        break;

                    }
                    else
                    {
                        curr = curr.Right;
                    }


                }


            }

            Balance(curr);
        }
        #endregion


        public void Delete(T value)
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }
            var curr = root;
            while (curr != null)
            {
                int comparison = value.CompareTo(curr.Value);
                if (comparison < 0)
                {
                    curr = curr.Left;
                }
                else if (comparison > 0)
                {
                    curr = curr.Right;
                }
                else if (comparison == 0)
                {
                    DeleteNode(curr);
                    return;
                }
            }
        }

        private void DeleteNode(AVLNode<T> curr)
        {
            //current is the one we want to delete, parent is  the parent of current
            //remove current from the tree
            if (curr.ChildCount == 0)
            {
                if (curr.Parent.Right == curr)
                {
                    curr.Parent.Right = null;
                }
                else
                {
                    curr.Parent.Left = null;
                }

                Balance(curr.Parent);
            }
            else if (curr.ChildCount == 1)
            {
                var child = curr.Left;
                if (curr.Right != null)
                {
                    child = curr.Right;
                }

                if (curr.Parent.Right == curr)
                {

                    curr.Parent.Right = child;

                }
                else if (curr.Parent.Left == curr)
                {
                    curr.Parent.Left = child;

                }

                Balance(curr.Parent);
            }
            else if (curr.ChildCount == 2)
            {

                var temp = curr.Left;
                while (temp.Right != null)
                {
                    temp = temp.Right;
                }
                curr.Value = temp.Value;
                DeleteNode(temp);
            }

        }

        public void PreOrder()
        {
            Function(root);

            void Function(AVLNode<T> node)
            {
                Console.WriteLine($"{node.Value}");
                if (node.Left != null)
                {
                    Function(node.Left);
                }
                if (node.Right != null)
                {
                    Function(node.Right);
                }
            }
        }
    }



}