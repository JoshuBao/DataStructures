using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class Tree<T> where T : IComparable<T>
    {
        public TreeNode<T> root;
        public int Count { get; private set; }
        public bool IsEmpty => root == null;

        public Tree()
        {
            root = null;

        }
        #region adding

        public void Add(T value)
        {
            if (root == null)
            {
                root = new TreeNode<T>(value);
                return;
            }

            var curr = root;
            while (curr != null)
            {
                if (value.CompareTo(curr.Value) < 0)
                {
                    if (curr.Left == null)
                    {
                        curr.Left = new TreeNode<T>(value);
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
                        curr.Right = new TreeNode<T>(value);
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
        #region delete

        public void Delete(T value)
        {

            if (root == null)
            {
                throw new IndexOutOfRangeException("yo maama");
            }

            var curr = root;
            TreeNode<T> parent = null;
            while (curr != null)
            {
                int comparison = value.CompareTo(curr.Value);
                if (comparison < 0)
                {
                    parent = curr;
                    curr = curr.Left;
                }
                else if (comparison > 0)
                {
                    parent = curr;
                    curr = curr.Right;
                }
                else if (comparison == 0)
                {
                    //current is the one we want to delete, parent is  the parent of current
                    //remove current from the tree
                    if (curr.ChildCount == 0)
                    {
                        if (parent.Right == curr)
                        {
                            parent.Right = null;
                        }
                        else
                        {
                            parent.Left = null;
                        }
                    }
                    else if (curr.ChildCount == 1)
                    {
                        var child = curr.Left;
                        if (curr.Right != null)
                        {
                            child = curr.Right;
                        }

                        if (parent.Right == curr)
                        {

                            parent.Right = child;

                        }
                        else if (parent.Left == curr)
                        {
                            parent.Left = child;

                        }
                    }
                    else if (curr.ChildCount == 2)
                    {

                        var temp = curr.Left;
                        var tempPar = curr;
                        while (temp.Right != null)
                        {
                            tempPar = temp;
                            temp = temp.Right;
                        }
                        curr.Value = temp.Value;

                        //we want to delete temp, and we have its parent TempValue
                        if (temp.ChildCount == 0)
                        {
                            if (tempPar.Right == temp)
                            {
                                tempPar.Right = null;
                            }
                            else
                            {
                                tempPar.Left = null;
                            }
                        }
                        else if (temp.ChildCount == 1)
                        {
                            if (tempPar.Left == temp)
                            {
                                tempPar.Left = temp.Left;

                            }
                            else
                            {
                                tempPar.Right = temp.Left;
                            }
                        }

                    }
                    break;
                }

            }
        }




        #endregion
        #region soulsearching

        public TreeNode<T> search(T value)
        {
            if (root == null)
            {
                throw new Exception("cant find nofin cos its empty bro");
            }

            var curr = root;
            while (curr != null)
            {
                if (value.CompareTo(curr.Value) < 0)
                {
                    curr = curr.Left;
                }
                else if (value.CompareTo(curr.Value) == 0)
                {
                    return curr;

                }
                else if (value.CompareTo(curr.Value) > 0)
                {
                    curr = curr.Right;

                }


            }
            return null;


        }

        public bool Contains(T value)
        {
            return search(value) != null;
        }

        public void InOrder(TreeNode<T> current )
        {

            if (current.Left != null)
            {
                InOrder(current.Left);
            }
            
            
            Console.Write("{0},", current.Value);
            
            if (current.Right !=null)
            {
                InOrder(current.Right);
            }



        }
        public void PreOrder(TreeNode<T> current)
        {

            Console.Write("{0},",current.Value);
            if (current.Left != null)
            {
                PreOrder(current.Left);

            }
            if (current.Right != null)
            {
                PreOrder(current.Right);

            }
        }
        public void PostOrder(TreeNode<T> current)
        {
            if (current.Left != null)
            {
                PostOrder(current.Left);

            }
            if (current.Right != null)
            {
                PostOrder(current.Right);

            }
            Console.Write("{0}", current.Value);

        }
        #endregion
        //constructor
        //Add
        //Remove



    }
}



