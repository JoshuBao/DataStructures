using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    public class EmptyCollectionException : InvalidOperationException
    {
        public EmptyCollectionException() : base("You can not invoke this opeartion on an empty collection. Also, you zuck") { }
        public EmptyCollectionException(string message) : base(message) { }
    }
}
