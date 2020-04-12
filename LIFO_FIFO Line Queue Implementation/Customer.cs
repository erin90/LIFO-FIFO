using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyDruggystore_172244_172442
{
    class Customer
    {
        public string name;
        public int age;
        public bool wasServed = false;

        public Customer(string n, int a)
        {
            this.name = n;
            this.age = a;
        }
        public string GetName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int GetAge
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public void Served(bool serviced)
        {
            wasServed = serviced;
        }
    }
}
