using System;
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
        public void BST()
        {




        }
    }
}
