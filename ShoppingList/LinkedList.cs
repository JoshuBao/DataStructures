using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    public class LinkedList<T> where T : IComparable<T>
    {
        Node<T> Head;
        public int count = 0;

        public LinkedList()
        {
            Head = null;
        }
        #region Adding
        public void AddBack(T Value)
        {
            if (Head == null)
            {
                Head = new Node<T>(Value);
            }
            else
            {
                Node<T> currentNode = Head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = new Node<T>(Value);
            }
            count++;
        }

        public void AddFront(T Value)
        {
            if (Head == null)
            {
                Head = new Node<T>(Value);
            }
            else
            {
                Node<T> NewHead = new Node<T>(Value);
                Node<T> storedvalue = Head;
                Head = NewHead;
                NewHead.Next = storedvalue;


            }
            count++;

        }
        public void Insert(T Value, int inputnum)
        {
            Node<T> insertednode = new Node<T>(Value);
            Node<T> currentNode = Head;

            int counter = 0;
            count++;

            //YOU NEED A SPECIAL CASE FOR 0 
            if (inputnum != 0)
            {
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    counter++;
                }

            }
            if (inputnum <= counter)
            {
                Node<T> holder = currentNode.Next;
                currentNode.Next = insertednode;
                insertednode.Next = holder;
            }
            if (inputnum > counter)
            {
                currentNode.Next = insertednode;

            }
            if (inputnum == 0)
            {
                Node<T> holder = Head;
                Head = insertednode;
                insertednode.Next = holder;
            }
        }
        #endregion
        #region Delete


        public void DelFront()
        {
            Node<T> tmp = Head;
            Head = Head.Next;
            tmp = null;
            
            count -= 1;
        }
        public void DelBack()
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
            }
            else
            {
                Head = null;
            }
        }
        public void DeleteAt(int insertednum)
        {

            Node<T> currentNode = Head;
            int counter = 0;
            count--;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                counter++;
            }
            if (insertednum == 0)
            {
                DelFront();

            }
            else if (insertednum >= counter)
            {

                DelBack();
            }
            else
            {
                counter = 0;
                Node<T> funnode = Head;
                while (counter < insertednum - 1 && counter >= 0)
                {

                    funnode = funnode.Next;
                    counter++;
                }
                funnode.Next = funnode.Next.Next;

            }



        }
        public void ClearAll()
        {
            Head = null;
            count = 0;
        }


        #endregion
        #region tools
        public bool IsEmpty()
        {
            bool empty = true;
            if (Head == null)
            {
                empty = true;
            }
            else
            {
                empty = false;
                count = 0;
            }
            return empty;
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
        public Node<T> Find(T Value)
        {
            Node<T> currentNode = Head;
            while (currentNode.Next != null)
            {
                if (Value.CompareTo(currentNode.Value) == 0 || currentNode.Next.Value.CompareTo(Value) == 0)
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
        public void Print()
        {
            Node<T> currentNode = Head;
           

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value.ToString());

                currentNode = currentNode.Next;
            }

        }



        #endregion


    }
}