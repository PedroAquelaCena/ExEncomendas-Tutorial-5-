using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex0Order.Entities
{
    internal class Product
    {
        public string Name { get; private set; }
        private double price;

        public Product(string name, double price)
        {
            this.Name = name;
            this.price = price;
        }

        public override string ToString()
        {
            return $"\nDados do produto {Name}: \n\tPreço (PVPN) --> {price}";
        }
    }
}
