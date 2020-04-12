using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyDruggystore_172244_172442
{
    class NodeQueue
    {
        Node front;
        Node rear;
        int size = 0;
        public NodeQueue()
        {

        }
        public void Enqueue(Customer element)
        {
            if (front == null)
            {
                Node N = new Node(element, null);
                front = N;
                rear = front;
                size++;
            }
            else
            {
                Node N = new Node(element, rear);
                rear.SetNext(N);
                rear = rear.GetNext();
                size++;
            }
            
        }
        public Customer Dequeue()
        {
            Customer element = null;
            if (size > 0)
            {
                if (size > 1)
                {
                    element = front.GetElement();
                    front = front.GetNext();
                    size--;
                }
                else
                {
                    element = front.GetElement();
                    front = null;
                    rear = null;
                    size--;
                }
            }
            return element;
        }
        public int Count()
        {
            return size;
        }
        public List<Customer> GetCustomerQueue()
        {
            List<Customer> customerQueue = new List<Customer>();
            Customer c;
            Node temp = front;

            for (int i = 0; i < size; i++)
            {
                c = temp.GetElement();
                customerQueue.Add(c);
                temp = temp.GetNext();
            }

            return customerQueue;
        }
        public void Clear()
        {
            front = null;
            rear = null;
            size = 0;
        }
        public object Peek()
        {
            return front.GetElement();
        }
    }
}
