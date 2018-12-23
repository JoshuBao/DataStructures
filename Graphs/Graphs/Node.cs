using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Node<T>
    {
        public Node<T> Next;
        public T Value;

        public Node(T Value)
        {
            this.Value = Value;
            Next = null;
        }
    }
}
