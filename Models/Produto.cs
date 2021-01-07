using System.Collections.Generic;
using System.IO;

namespace MVC_Console.Models
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
         
        private const string PATH = "Database/Produto.csv";

        public Produto()
        {
            //Verificar se a pasta existe
            string pasta = PATH.Split("/")[0];
            
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            //Verificar se o arquivo existe
            if (!File.Exists(PATH))
            {
                File.Create(PATH); 
            }
        }

        public List<Produto> Ler()
        {
            //Lista criada para armazenar os produtos
            List<Produto> produtos = new List<Produto>();

            //Feito para ler as linhas do CSV
            string[] linhas = File.ReadAllLines(PATH);

            //Percorrendo as linhas do CSV
            foreach (string item in linhas)
            {
                //Separamos os elementos de cada linha
                string[] atributos = item.Split(";");

                Produto prod = new Produto();

                //Passamos para um objeto do tipo Produto
                prod.Codigo = int.Parse( atributos[0]);
                prod.Nome = atributos[1];
                prod.Preco = float.Parse( atributos[2]);

                produtos.Add(prod);
            }

            return produtos;
        }

        public void Inserir(Produto produto)
        {
            //Criamos o array de linhas para inserir no CSV
            string[] linhas = { PrepararLinhaCSV(produto) };

            //Método resposável por inserir as linhas em um arquivo
            File.AppendAllLines(PATH, linhas);
        }

        public string PrepararLinhaCSV(Produto prod)
        {
            return $"{prod.Codigo};{prod.Nome};{prod.Preco}";
        }
    }
}