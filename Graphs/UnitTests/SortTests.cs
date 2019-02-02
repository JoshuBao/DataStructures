using System;
using System.IO;
using Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{

    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void BubbleSortTest()
        {
            int[] items = new int[] { 5, 8, 1, 14, 82, 95, 12 };

            Sorts.BubbleSort(items);

            int[] correctItems = new int[] { 1, 5, 8, 12, 14, 82, 95 };


            Assert.AreEqual(items.Length, correctItems.Length);

            for(int i = 0; i < items.Length; i++)
            {
                Assert.AreEqual(items[i], correctItems[i]);
            }
        }
        [TestMethod]
        public void LinkedListTest()
        {
            
            LinkedList<int> List = new LinkedList<int>();

            List.Add(1);
            List.Add(2);
            List.Add(3);
            List.Add(4);
            
            var node = List.Find(3);
            node.Next = List.Find(1);

            //stuf
           


            //at this point 
            //1->2->3->1 
            //should be 1->2->3->4




            
        }

    }
    [TestClass]
    public class PathFindingNemo
    {
        [TestMethod]
        public void Dijkstra()
        {
            string[] lines = File.ReadAllLines("ALEXISBAD.txt");
            UndirectedGraph<int> Graph = new UndirectedGraph<int>();
            int path = int.Parse(lines[0]);
        }



       




    }
}
