using System;
using System.IO;
using Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
            //Airpot

            
            string[] lines = File.ReadAllLines("ALEXISBAD.txt");

            var Graph = new DirectedGraph<string>();

            int path = int.Parse(lines[0]);
            
            var CorrectPathes = new string[path][];
            for (int i = 0; i < path; i++)
            {
                CorrectPathes[i] = lines[i + 1].Split(',');
                
            }
            for (int i = path + 1; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(',');

                if (Graph.search(temp[0]) == null)
                {
                    Graph.AddVertex(new Vertex<string>(temp[0]));
                }
                //do samething for temp 1
                if (Graph.search(temp[1]) == null)
                {
                    Graph.AddVertex(new Vertex<string>(temp[1]));

                }
                Graph.AddEdge(Graph.search(temp[0]), Graph.search(temp[1]), int.Parse(temp[2]));
                


            }
            // why do we use ' instead of "
            for (int i = 1; i < path + 1; i++)
            {
                for (int j = 0; j < path; j++)
                {
                    string[] temp = lines[i].Split(',');

                    string[] myPath = Graph.Dijkstra(Graph.search(temp[0]), Graph.search(temp[temp.Length - 1])).ToArray().Select(x => x.Value).ToArray();
                    

                   // Assert.AreEqual(, CorrectPathes[j]);

                }
            }
            
      

            











        }



       




    }
}
