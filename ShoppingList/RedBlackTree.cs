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

            #region graphic
            public void PrintPretty(string indent, bool last)
            {

                Console.Write(indent);
                if (last)
                {
                    Console.Write("└─");
                    indent += "  ";
                }
                else
                {
                    Console.Write("├─");
                    indent += "| ";
                }
                Console.WriteLine(Value);

                var children = new List<Node>();
                if (this.Left != null)
                    children.Add(this.Left);
                if (this.Right != null)
                    children.Add(this.Right);

                for (int i = 0; i < children.Count; i++)
                {
                    children[i].PrintPretty(indent, i == children.Count - 1);
                }


            }
            #endregion
        }
        #region Adding
        //overloading methods
        public void Add(T value) //
        {
            root = Add(root, value);
            root.IsRed = false;
        }

        //recursivly
        private Node Add(Node curr, T value) //calls itself
        {

            if (curr == null)
            {
                return new Node(value);
            }

            //as we go down the tree

            if (!IsBlack(curr.Left) && !IsBlack(curr.Right))
            {
                FlipColor(curr);
            }


            //recursive segment
            if (value.CompareTo(curr.Value) < 0)
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
            curr = Fixup(curr);


            return curr;
        }

        //RotateLeft
        private Node RotateLeft(Node node)
        {
            Node child = node.Right;
            node.Right = child.Left;
            child.Left = node;

            child.IsRed = node.IsRed;
            node.IsRed = true;

            return child;
        }

        //RotateRight
        private Node RotateRIght(Node node)
        {
            Node child = node.Left;
            node.Left = child.Right;
            child.Right = node;

            child.IsRed = node.IsRed;
            node.IsRed = true;

            return child;
        }
        //FlipColor
        private void FlipColor(Node node)
        {
            node.IsRed = !node.IsRed;
            if (node.Left != null)
            {
                node.Left.IsRed = !node.Left.IsRed;

            }
            if (node.Right != null)
            {
                node.Right.IsRed = !node.Right.IsRed;
            }
        }

        private bool IsBlack(Node node)
        {
            if (node == null || node.IsRed == false)
            {
                return true;
            }
            return false;
        }

        //Fixup
        private Node Fixup(Node curr)
        {
            if (!IsBlack(curr.Right))
            {
                curr = RotateLeft(curr);

            }

            if (!IsBlack(curr.Left) && !IsBlack(curr.Left.Left))
            {
                curr = RotateRIght(curr);
            }

            if (!IsBlack(curr.Left) && !IsBlack(curr.Right))
            {
                FlipColor(curr);
            }

            if (curr.Left != null && IsBlack(curr.Left.Left) && !IsBlack(curr.Left.Right))
            {
                curr.Left = RotateLeft(curr.Left);
            }


            return curr;
        }
        #endregion
        #region printingETC
        public void PreOrder()
        {
            Function(root);

            void Function(RedBlackTree<T>.Node node)
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

        public void Print()
        {
            root.PrintPretty("", true);
        }
        #endregion
        #region deleting
        public bool Delete(T value)
        {
            int oldCount = Count;
            root = Delete(root, value);
            root.IsRed = false;
            return Count != oldCount;
        }

        private Node Delete(Node curr, T value)
        {
            if(value.CompareTo(curr.Value) < 0)
            {
                if(Is2Node(curr.Left))
                {
                    curr = MoveRedLeft(curr);
                }

                curr.Left = Delete(curr.Left, value);
            }
            else if(value.CompareTo(curr.Value) > 0 )
            {
                if (!IsBlack(curr.Left))
                {

                    curr.Left = RotateRIght(curr.Left);
                }
                
            }
            else if (value.CompareTo(curr.Value) == 0 && curr.Left == null && curr.Right == null)
            {

                curr = Delete(curr,value);
            }
            else if (Is2Node(curr.Right))
            {


            }
        }
        private Node MoveRedRight(Node curr)
        {
            FlipColor(curr);
            if (curr.Left != null && !IsBlack(curr.Left.Left))
            {
                curr = RotateRIght(curr);
                FlipColor(curr);
            }
            return curr;
        }

        private bool Is2Node(Node node)
        {
            if (IsBlack(node) && IsBlack(node.Left))
            {
                return true;
            }
            return false;
        }

        private Node MoveRedLeft(Node curr)
        {
            FlipColor(curr);
            if (curr.Right != null && !IsBlack(curr.Right.Left))
            {
                curr.Right = RotateRIght(curr.Right);
                curr = RotateLeft(curr);
                FlipColor(curr);
            }
            return curr;

        }
        #endregion


        //}

    }
}
