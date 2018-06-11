using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class StackNode<T>
    {
        public T Item { get; set; }
        public StackNode<T> Next { get; set; }

      
        public StackNode(T itemToStore, StackNode<T> next = null)
        {
            Item = itemToStore;
            Next = next;
        }


    }
}
