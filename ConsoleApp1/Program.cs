using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<(string Nome, string Tipo, double Preco)> produtos = new List<(string, string, double)>();

    static void Main(string[] args)
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("\nEscolha uma das opções:");
            Console.WriteLine("\n1 - Adicionar produto à lista");
            Console.WriteLine("2 - Exibir lista de compras");
            Console.WriteLine("3 - Remover produto");
            Console.WriteLine("4 - Buscar produto");
            Console.WriteLine("5 - Editar produto");
            Console.WriteLine("6 - Sair");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarProd();
                    break;
                case "2":
                    ExibirList();
                    break;
                case "3":
                    RemoverProd();
                    break;
                case "4":
                    BuscarProd();
                    break;
                case "5":
                    EditarProd();
                    break;
                case "6":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void AdicionarProd()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Tipo: ");
        string tipo = Console.ReadLine();
        double preco;
        Console.WriteLine("Preço:");
        string entrada = Console.ReadLine();
        if (!double.TryParse(entrada, out preco))
        {
            Console.WriteLine("Preço inválido.");
            return;
        }
        produtos.Add((nome, tipo, preco));
        Console.WriteLine("Produto adicionado com sucesso.");
    }

    static void ExibirList()
    {
        foreach (var produto in produtos)
        {
            Console.WriteLine($"Nome: {produto.Nome}, Tipo: {produto.Tipo}, Preço: {produto.Preco}");
        }
    }

    static void RemoverProd()
    {
        Console.Write("Digite o nome ou tipo do produto a remover: ");
        string entrada = Console.ReadLine();
        var produto = produtos.FirstOrDefault(c => c.Nome == entrada || c.Tipo == entrada);

        if (produto != default)
        {
            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    static void BuscarProd()
    {
        Console.Write("Digite o nome ou tipo do produto a buscar: ");
        string entrada = Console.ReadLine();
        var produto = produtos.FirstOrDefault(c => c.Nome == entrada || c.Tipo == entrada);

        if (produto != default)
        {
            Console.WriteLine($"Nome: {produto.Nome}, Tipo: {produto.Tipo}, Preço: {produto.Preco}");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    static void EditarProd()
    {
        Console.Write("Digite o produto a editar: ");
        string nome = Console.ReadLine();
        var index = produtos.FindIndex(c => c.Nome == nome);

        if (index != -1)
        {
            Console.Write("Novo Tipo: ");
            string novoTipo = Console.ReadLine();
            
            double novoPreco;
            Console.Write("Novo Preço: ");
            string entrada = Console.ReadLine();
            if (!double.TryParse(entrada, out novoPreco))
            {
                Console.WriteLine("Preço inválido.");
                return;
            }
            produtos[index] = (produtos[index].Nome, novoTipo, novoPreco);
            Console.WriteLine("Produto atualizado com sucesso.");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
}