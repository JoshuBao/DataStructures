using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class Mylist<T>
    {

        T[] list;
        public Mylist()
        {
            list = new T[0];
        }

        public void Add(T holder)
        {
            
            T[] tmp = new T[list.Length + 1];
            for (int i = 0; i < list.Length; i++)
            {
                tmp[i] = list[i];
            }

            tmp[tmp.Length - 1] = holder;
            list = tmp;
        }
        public void Delete(int tmpnum)
        {
            
            T[] tmparr = new T[list.Length - 1];
            for (int i = 0; i < list.Length; i++)
            { 
                if (i < tmpnum)
                {
                    tmparr[i] = list[i];
                }
                if (i > tmpnum)
                {
                    tmparr[i - 1] = list[i];
                }
            }
            list = tmparr;
        }
        public void Dellast()
        {

            T[] tmp = new T[list.Length - 1];
            for (int i = 0; i < list.Length - 1; i++)
            {
                tmp[i] = list[i];
            }
            list = tmp;
        }
        public void Display()
        {

            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine("{0}:{1}", i, list[i]);
            }
            Console.WriteLine("");
        }










    }
}
