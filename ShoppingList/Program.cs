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
            SkipList<int> Tree;
            Tree = new SkipList<int>();

            for (int i = 10; i > 0 ; i--)
            {
                Tree.Add(i);
            }
            



            

            Console.ReadKey();

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
            else if (userinput == "dellast")
            {

                input.Dellast();

            }
            else if (userinput == "delete")
            {
                Console.WriteLine("What do you want to delete? \n(use the number next to the item you want to delete)");
                int tmpnum = int.Parse(Console.ReadLine());
                input.Delete(tmpnum);

            }

        }

    }

}












