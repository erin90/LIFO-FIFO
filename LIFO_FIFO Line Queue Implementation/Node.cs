using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyDruggystore_172244_172442
{
    class Node
    {
        private Customer element;
        private Node next;

        public Node(Customer c, Node n)
        {
            element = c;    
            next = n;
        }
        public Customer GetElement()
        {
            return element;
        }
        public Node GetNext()
        {
            return next;
        }
        public void SetElement(Customer newElem)
        {
            element = newElem;
        }
        public void SetNext(Node newNext)
        {
            next = newNext;
        }
    }
}
