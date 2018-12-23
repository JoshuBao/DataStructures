using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            //add random numbers to avl tree
            //print numbers to screen using pre order traversal

            
            SkipList<int> Tree;
            Tree = new SkipList<int>();

            for (int i = 10; i > 0 ; i--)
            {
                Tree.Add(i);
            }

            Tree.Contains(3);


            Tree.Remove(5);
            
            Console.ReadKey();

        }

    }

}












