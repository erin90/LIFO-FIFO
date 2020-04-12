using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyDruggystore_172244_172442
{
    class CrazyDrugstore
    {
        NodeQueue CustomerQueue = new NodeQueue();
        PriorityQueue SeniorQueue = new PriorityQueue();
        List<Customer> CustomerList = new List<Customer>();
       
        public bool BawalUmulit(string name)
        {
          bool check = true;
            if (FindCustomer(name) == null)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;

        }
        public void Lineup(string name, int age)
        {
            if (age >= 65)
            {
                Customer customer = new Customer(name, age);
                CustomerList.Add(customer);
                SeniorQueue.Enqueue(customer);
            }
            else
            {
                Customer customer = new Customer(name, age);
                CustomerList.Add(customer);
                CustomerQueue.Enqueue(customer);
            }
        }
        public Customer FindCustomer(string name)
        {
            Customer element = null;

            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (CustomerList[i].GetName == name)
                {
                    element = CustomerList[i];
                    break;
                }
            }

            return element;
        }

        public string Display()
        {
            string message = "";
            foreach (Customer lowprio in CustomerQueue.GetCustomerQueue())
            {
                message = message + "Name: " + lowprio.GetName + "\n" + "Age: " + lowprio.GetAge + "\n";
            }
            return message;
        }

        public string Displayfirst()
        {
            string message = "";
            foreach(Customer customer in CustomerList)
            {
                message = message + "Name: " + customer.GetName + "\n" + "Age: " + customer.GetAge + "\n";
            }
            if (SeniorQueue.Counter() != 1)
            {
                message = "New Line! \n";
                IEnumerable<Customer> enumerable = SeniorQueue.GetList();
                foreach (Customer highprio in enumerable.Reverse())
                {
                    message = message + "Name: " + highprio.GetName + "\n" + "Age: " + highprio.GetAge + "\n";
                }
            }
            return message;

        }

        public string Displaytwo()
        {
            string message = "";
            IEnumerable<Customer> enumerable = SeniorQueue.GetList();
            foreach (Customer highprio in enumerable.Reverse())
            {
                message = message + "Name: " + highprio.GetName + "\n" + "Age: " + highprio.GetAge + "\n";
            }

            return message;
        }

        public string Rotate()
        {
            string message = "";
            if (SeniorQueue.Count() != 0 || CustomerQueue.Count() != 0)
            {
                if (SeniorQueue.Count() != 0)
                {
                    SeniorQueue.Rotate();
                }
                else
                {
                    message = "\nThere is no one in line in senior queue!";
                }
                if (CustomerQueue.Count() != 0)
                {
                    int normalQueueSize = CustomerQueue.Count();
                    Customer[] normalCustomers = new Customer[normalQueueSize];

                    normalCustomers = customToarray(CustomerQueue);

                    for (int i = normalQueueSize - 1; i >= 0; i--)
                    {
                        CustomerQueue.Enqueue(FindCustomer(normalCustomers[i].GetName));
                    }
                }
                else
                {
                    message = "\nThere is no one in line in senior queue";
                }
                message = "\nThe queues have been rotated!";
            }
            else
            {
                message = "\nThere is no one in both customer and senior queues!";
            }
            return message;
        }

        public string Serve()
        {
            string message = "";
            if (SeniorQueue.Count() != 0)
            {
                Customer seniorInFront = (Customer)SeniorQueue.Peek();
                seniorInFront.Served(true);
                message = "\nCustomer " + seniorInFront.GetName + " has been served!";
                CustomerList.Remove(seniorInFront);
                SeniorQueue.DequeueingHeap();
            }
            else
            {
                if (CustomerQueue.Count() != 0)
                {
                    Customer customerInFront = (Customer)CustomerQueue.Peek();
                    customerInFront.Served(true);
                    message = "\nCustomer " + customerInFront.GetName + " has been served!";
                    CustomerList.Remove(customerInFront);
                    CustomerQueue.Dequeue();
                }
                else
                {
                    message = "\n There is no one in line!";
                }
            }
            return message;
        }
        
        public Customer[] customToarray(NodeQueue NQ)
        {
            int nodeQueueSize = NQ.Count();
            Customer[] arrayCustoms = new Customer[nodeQueueSize];
            for (int i = 0; i < nodeQueueSize; i++)
            {
                arrayCustoms[i] = (Customer)CustomerQueue.Dequeue();
            }
            return arrayCustoms;
        }
        
    }
}
