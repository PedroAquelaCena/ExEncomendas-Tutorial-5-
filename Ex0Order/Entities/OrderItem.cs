using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex0Order.Entities
{
    internal class OrderItem
    {
        private Product produto;
        private int quantity;
        private double price;

        public OrderItem(Product produto, int quantity, double price)
        {
            this.produto = produto;
            this.quantity = quantity;
            this.price = price;
        }

        public double SubTotal() => quantity * price;

        public override string ToString()
        {
            return $"Dados do item encomendado: \n\t{produto.ToString()};\n\tQuantidade --> {quantity};\n\tSubtotal --> {SubTotal().ToString("F2")} Euros";
        }
    }
}
