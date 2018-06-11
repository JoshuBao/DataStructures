using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class Stack<T>
    {
        StackNode<T> Head;
        public int Count { get; private set; }

        public Stack()
        {

            Head = null;
        }
        public void Push(T insertedvalue)
        {
            var temp = new StackNode<T>(insertedvalue, Head);
            Head = temp;
            Count++;
        }
        public void Pop()
        {
            if (Head == null)
            {
                throw new Exception();
            }
            Head = Head.Next;
            Count--;
        }

        public T Peek()
        {
            
            return Head.Item;
        }
        public bool IsEmpty()
        {

            if (Head == null)
            {
                return true;

            }
            else
            {

                return false;
            }

        }
        public int ReturnCount()
        {

            return Count;
        }
        public void ClearAll()
        {
            Count = 0;
            Head = null;
            
        }

    }
}