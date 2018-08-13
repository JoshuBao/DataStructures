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

            Mylist<string> input;
            string userinput = "";
            input = new Mylist<string>();
            AVLTree<int> Tree;
            Tree = new AVLTree<int>();
            Tree.Add(3);
            Tree.Add(6);
            Tree.Add(1);
            Tree.Add(7);
            Tree.Add(5);
            Tree.Add(44);
            Tree.Add(23);
            Tree.Add(54);
            Tree.Add(123);
            Tree.Add(9);
            Tree.Add(10);
            Tree.Add(13);
            Tree.Add(12);
            Tree.Add(64);
            Tree.Add(25);
            Tree.Delete(6);
            Tree.PreOrder();



            while (true)
            {
                userinput = Console.ReadLine();

                if (userinput == "add")
                {
                    Console.WriteLine("What do you want to add?");
                    string holder = Console.ReadLine();
                    input.Add(holder);
                    
                }
                else if (userinput == "list")
                {
                    input.Display();

                }
                else if(userinput == "dellast")
                {

                    input.Dellast();

                }
                else if(userinput == "delete")
                {
                    Console.WriteLine("What do you want to delete? \n(use the number next to the item you want to delete)");
                    int tmpnum = int.Parse(Console.ReadLine());
                    input.Delete(tmpnum);

                }

            }

        }











    }
}

