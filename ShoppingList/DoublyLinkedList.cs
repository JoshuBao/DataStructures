using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class DoublyLinkedList<T>
    {
        DoublyLinkedNode<T> Head;


        public int Count;

        public DoublyLinkedList()
        {
            Head = null;
        }

        #region Adding
        public void AddFront(T Value)
        {
            Count++;
            DoublyLinkedNode<T> nodetobeadded = new DoublyLinkedNode<T>(Value);
            if (Head == null)
            {
                Head = new DoublyLinkedNode<T>(Value);
            }
            else
            {
                DoublyLinkedNode<T> holder = Head;
                Head = nodetobeadded;
                Head.Next = holder;
                Head.Previous = null;
                holder.Previous = Head;

            }

        }
        public void AddBack(T Value)
        {
            Count++;
            if (Head == null)
            {
                Head = new DoublyLinkedNode<T>(Value);
            }
            else
            {
                DoublyLinkedNode<T> currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;

                }
                currentNode.Next = new DoublyLinkedNode<T>(Value);
            }
        }
        public void Insert(T Value, int inputnum)
        {
            Count++;
            DoublyLinkedNode<T> insertednode = new DoublyLinkedNode<T>(Value);
            DoublyLinkedNode<T> currentNode = Head;
            DoublyLinkedNode<T> currentNode2 = Head;
            int counter = 0;
            int counter2 = 0;
            while (currentNode != null)
            {
                currentNode = currentNode.Next;
                counter++;
            }
            if (inputnum > counter)
            {
                AddBack(Value);
            }
            if (inputnum == 0)
            {
                AddFront(Value);

            }
            else
            {

                while (currentNode2.Next != null && inputnum - 1 != counter2)
                {
                    currentNode2 = currentNode2.Next;
                    counter2++;
                }

                insertednode.Previous = currentNode2;
                insertednode.Next = currentNode2.Next;


                currentNode2.Next.Previous = insertednode;
                currentNode2.Next = insertednode;




            }


        }

        #endregion
        #region Removing
        public void DelFront()
        {
            Count--;
            DoublyLinkedNode<T> tmp = Head;
            Head = Head.Next;
            Head.Previous = null;
            tmp = null;
        }
        public void DelBack()
        {
            Count--;
            DoublyLinkedNode<T> currentNode = Head;
            DoublyLinkedNode<T> CountCheck = Head;
            int counter = 0;
            while (CountCheck.Next != null)
            {
                CountCheck = CountCheck.Next;
                counter++;

            }
            if (counter == 1)
            {
                Head.Next = null;

            }
            else if (counter == 0)
            {

                Head = null;
            }
            else if (counter > 2)
            {
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;

                }
                currentNode.Next = null;
            }
        }
        public void DeleteAt(int insertednum)
        {
            Count--;
            DoublyLinkedNode<T> currentNode = Head;
            int counter = 0;
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
                DoublyLinkedNode<T> funnode = Head;
                while (counter < insertednum - 1 && counter >= 0)
                {

                    funnode = funnode.Next;
                    counter++;
                }
                funnode.Next = funnode.Next.Next;

            }


        }


        #endregion
        #region tools
        //america explain i am confusion
        public bool IsEmpty
        {
            get
            {
                return Head == null;
            }
        }
        public void Counter()
        {
            Console.WriteLine("There are {0}nodes in this list",Count.ToString());

        }

        #endregion

      
    }
}