using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyDruggystore_172244_172442
{
    class PriorityQueue
    {
        public Customer[] priorityQueue = new Customer[100];
        int size = 0;
        int counter = 1;

        public int Counter()
        {
            return counter;
        }

        public void MinHeap(Customer[] prioQ, int n, int i)
        {
            int smallest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && prioQ[l].GetAge < prioQ[smallest].GetAge)
                smallest = l;

            if (r < n && prioQ[r].GetAge < prioQ[smallest].GetAge)
                smallest = r;

            if (smallest != i)
            {
                Customer temp = prioQ[i];
                prioQ[i] = prioQ[smallest];
                prioQ[smallest] = temp;

                MinHeap(prioQ, n, smallest);
            }
        }

        public void MaxHeap(Customer[] prioQ, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && prioQ[l].GetAge > prioQ[largest].GetAge)
                largest = l;

            if (r < n && prioQ[r].GetAge > prioQ[largest].GetAge)
                largest = r;

            if (largest != i)
            {
                Customer temp = prioQ[i];
                prioQ[i] = prioQ[largest];
                prioQ[largest] = temp;

                MaxHeap(prioQ, n, largest);
            }
        }
        
        public void Heapify(Customer[] PQ, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                if (counter % 2 == 0)
                {
                    MaxHeap(PQ, n, i);
                }
                else
                {
                    MinHeap(PQ, n, i);
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Customer temp = PQ[0];
                PQ[0] = PQ[i];
                PQ[i] = temp;

                if (counter % 2 == 0)
                {
                    MaxHeap(PQ, i, 0);
                }
                else
                {
                    MinHeap(PQ, i, 0);
                }
            }
        }
        public int Count()
        {
            return size;
        }
        public void Enqueue(Customer element)
        {
            priorityQueue[size] = element;
            size++;
            Heapify(priorityQueue, size);
        }

        public Customer Dequeue()
        {
            Customer element;
            Heapify(priorityQueue, size);
            element = priorityQueue[size - 1];
            priorityQueue[size - 1] = null;
            size--;
            Heapify(priorityQueue, size);
            return element;
        }
        public void Rotate()
        {
            counter++;
        }
        public List<Customer> GetList()
        {
            List<Customer> list = new List<Customer>();
            Customer[] SQ = priorityQueue;
            Heapify(SQ, size);

            for (int i = size - 1; i >= 0; i--)
            {
                list.Add(SQ[i]);
            }

            return list;
        }
        public bool LinedUp(Customer element)
        {
            bool Queued = false;

            for (int i = 0; i < size; i++)
            {
                if (priorityQueue[i] == element)
                {
                    Queued = true;
                    break;
                }
            }

            return Queued;
        }
        public Customer Peek()
        {
            if (size != 0)
            {
                return priorityQueue[0];
            }
            return null;
        }
        int heapSize;

        private void BuildHeap(Customer[] arr, int size)
        {
            heapSize = size - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }
        public Customer DequeueingHeap()
        {
            Customer next = priorityQueue[0];
            for (int i = 1; i < size; i++)
            {
                priorityQueue[i - 1] = priorityQueue[i];
                if (i == size - 1)
                {
                    priorityQueue[i] = null;
                }
            }
            size--;

            BuildHeap(priorityQueue, size);
            return next;
        }
    }
}
