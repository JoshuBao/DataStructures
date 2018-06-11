using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
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
