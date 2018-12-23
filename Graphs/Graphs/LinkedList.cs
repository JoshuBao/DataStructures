using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
     public class LinkedList<T> : ICollection<T>
    {
        Node<T> Head;
        int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly => false;

        public LinkedList()
        {
            Head = null;
        }
        //contains/find
        public Node<T> Find(T Value)
        {
            Node<T> currentNode = Head;
            while (currentNode.Next != null)
            {
                if (Value.Equals(currentNode.Value) || currentNode.Next.Value.Equals(Value))
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }
            return currentNode;
        }
        public bool Contains(T Nemo)
        {
            bool contains = false;
            if (Find(Nemo) != null)
            {
                contains = true;
            }
            return contains;
        }
        public void Add(T item)
        {
            if (Head == null)
            {
                Head = new Node<T>(item);
            }
            else
            {
                Node<T> NewHead = new Node<T>(item);
                Node<T> storedvalue = Head;
                Head = NewHead;
                NewHead.Next = storedvalue;
            }
            count++;
        }
        public void Clear()
        {
            Head = null;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            //copyes value into array starting at arrayIndex

            foreach(var item in this)
            {
                for (int i = 0; i < arrayIndex; i++)
                {
                    array[i] = item;
                }
            }
            
        }
        public bool Remove()
        {
            Node<T> currentNode = Head;
            Node<T> Countcheck = Head;
            int counter = 0;
            count--;
            while (Countcheck.Next != null)
            {
                Countcheck = Countcheck.Next;
                counter++;
            }
            if (counter == 1)
            {
                Head.Next = null;
            }
            else if (counter > 1)
            {
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = null;
                return true;
            }
            else
            {
                Head = null;
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            //loop through every node and yield return its value
            Node<T> curr;
            
            curr = Head;

            while(curr != null)
            {
                
                yield return curr.Value;
                curr = curr.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T item) //remove an item
        {
            throw new NotImplementedException();
        }
    }


}
