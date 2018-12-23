using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Sorts
    {
        public static void BubbleSort<T>(T[] items) where T : IComparable<T>
        {
            bool unsorted = true;

            while (unsorted)
            {
                unsorted = false;
                for (int i = 0; i < items.Length - 1; i++)
                {
                    if (items[i].CompareTo(items[i + 1]) > 0)
                    {
                        T tmp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = tmp;
                        unsorted = true;
                    }
                }
            }
        }





    }


}





