using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Sorts
    {
        public static void BubbleSort<T>(T[] items) where T : IComparable<T>
        {
            bool unsorted = true;

            while (unsorted)
            {
                unsorted = false;
                for (int i = 0; i < items.Length - 1; i++)
                {
                    if (items[i].CompareTo(items[i + 1]) > 0)
                    {
                        T tmp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = tmp;
                        unsorted = true;
                    }
                }
            }
        }

     

    }
    class BST<T> where T : IComparable<T>
    {
        public TreeNode<T> root;
        
        void Add(T value)
        {
            if (root == null)
            {
                root = new TreeNode<T>(value);
                return;
            }

            var curr = root;
        }

    }



    class TreeNode<T> where T : IComparable<T>
    {
        public TreeNode<T> Left;
        public TreeNode<T> Right;
        public T Value;
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
        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }


}





