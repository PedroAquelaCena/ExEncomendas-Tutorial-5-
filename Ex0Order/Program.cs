using System;
using Ex0Order.Entities;
using System.Collections.Generic;
using Ex0Order.Entities;
using Ex0Order.Entities.Enums;

namespace Ex0Order
{
    class Program
    {
        static public List<Client> listaClientes = new List<Client>();
        static public List<Product> listaProdutos = new List<Product>();
        static public List<Order> listaEncomendas = new List<Order>();
        static void Main(string[] args)
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("\n\t\tMenu ");
                Console.WriteLine("\n\t1. Inserir cliente");
                Console.WriteLine("\t2. Apresentar clientes");
                Console.WriteLine("\t3. Inserir produto");
                Console.WriteLine("\t4. Apresentar produto");
                Console.WriteLine("\t5. Inserir encomenda");
                Console.WriteLine("\t6. Apresentar encomenda");
                Console.WriteLine("\t7. Sair");
                Console.Write("\n\tOpção --> ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        InserirCliente();
                        break;

                    case "2":
                        ApresentarCliente();
                        break;

                    case "3":
                        InserirProduto();
                        break;

                    case "4":
                        ApresentarProduto();
                        break;

                    case "5":
                        InserirEncomenda();
                        break;

                    case "6":
                        ApresentarEncomendas();
                        break;

                    case "7":
                        sair = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
        static public void InserirCliente()
        {
            Console.WriteLine("Dados do cliente: ");

            Console.Write("\n\tNome --> ");
            string nomCliente = Console.ReadLine();

            Console.Write("\tE-mail --> ");
            string email = Console.ReadLine();

            Console.Write("\tData de nascimento (dd/mm/aaaa) --> ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());


            Client cliente = new Client(nomCliente, email, dataNascimento);
            listaClientes.Add(cliente);
        }

        static public void ApresentarCliente()
        {
            Console.WriteLine("Lista de clientes");
            foreach (Client cl in listaClientes)
                Console.WriteLine(cl.ToString());
        }

        static public void InserirProduto()
        {
            Console.Clear();
            Console.WriteLine("Inserir dados do produto: ");

            Console.Write("\n\tNome do produto --> ");
            string nomProduto = Console.ReadLine();

            Console.Write("\tPreço --> ");
            double preco = double.Parse(Console.ReadLine());

            Product produto = new Product(nomProduto, preco);
            listaProdutos.Add(produto);

            Console.WriteLine("Produto adicionado com sucesso");
        }

        static public void ApresentarProduto()
        {
            foreach (Product pr in listaProdutos)
                Console.WriteLine(pr.ToString());
        }

        static public void InserirEncomenda()
        {
            Console.WriteLine("\n\nInserir Dados da nova encomenda");
            Console.Write("Estado da Encomenda (0 - Pendente, 1 - Processando, 2 - Em envio, 3 - Entregue");
            OrderStatus os = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            DateTime dt = DateTime.Now;

            Console.WriteLine("\nSelecione o Cliente proprietário da encomenda: ");
            for (int i = 0; i < listaProdutos.Count; i++)
                Console.WriteLine($"{i} - {listaClientes[i].Name}");
            Console.Write("Indice do cliente: ");
            int id = int.Parse(Console.ReadLine());
            if (id > 0 && id < listaProdutos.Count)
            {
                Order order = new Order(dt, os, listaClientes[id]);
                listaEncomendas.Add(order);
                bool inserirItems = true;
                while (inserirItems)
                {
                    Console.WriteLine("\nSelecione o produto: ");
                    for (int i = 0; i < listaProdutos.Count; i++)
                        Console.WriteLine($"{i} - {listaProdutos[i].Name}");
                    Console.Write("Indice dos Produtos: ");
                    id = int.Parse(Console.ReadLine());
                    if (id >= 0 && id < listaProdutos.Count)
                    {
                        Product p = listaProdutos[id];
                        Console.Write("Quantidade: ");
                        int qt = int.Parse(Console.ReadLine());
                        Console.Write("Preço: ");
                        double preco = double.Parse(Console.ReadLine());
                        order.AddItem(new OrderItem(p, qt, preco));
                        Console.Write("Adicionar novo item? s/n: ");
                        if (Console.ReadLine().ToUpper() != "S") inserirItems = false;
                    }
                    else
                        Console.WriteLine("Indice do produto inválido!");
                }
            }
            else
                Console.WriteLine("Indice de cliente inválido");
        }
            static public void ApresentarEncomendas()
        {
            Console.WriteLine("\n\nLista de encomendas no sistema: ");
            foreach (Order or in listaEncomendas)
                Console.WriteLine(or.ToString());
        }   
    }
}