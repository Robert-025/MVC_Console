using System;
using System.Collections.Generic;
using MVC_Console.Models;

namespace MVC_Console.Views
{
    public class ProdutoView
    {
        public void Listar(List<Produto> produtos)
        {
            foreach (var item in produtos)
            {
                Console.WriteLine($"\nCódigo: {item.Codigo}");
                Console.WriteLine($"Produto: {item.Nome}");
                Console.WriteLine($"Preço: R${item.Preco} \n");
            }
        }

        public Produto CadastrarProduto()
        {
            Produto prod = new Produto();

            string opcao;

            do
            {
                Console.WriteLine($"Digite um código");
                prod.Codigo = int.Parse( Console.ReadLine() );

                Console.WriteLine($"Digite o nome do produto");
                prod.Nome = Console.ReadLine();
                
                Console.WriteLine($"Digite o preço do produto");
                prod.Preco = float.Parse( Console.ReadLine() );
                
                Console.WriteLine($"Deseja cadastrar mais um produto? S/N");
                opcao = Console.ReadLine();
                
            } while (opcao.ToUpper() == "S");
            

            return prod;
        }

        
    }
}