using Mongodb.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conectando no servidor");
            //connection server
            var client = new MongoClient("mongodb://localhost:27017");

            Console.WriteLine("Conectando no banco de dados");
            //connection db
            var database = client.GetDatabase("agenda");

            Console.WriteLine("Obtendo a coleção de dados");
            //collection object pessoa
            IMongoCollection<Pessoas> collection = database.GetCollection<Pessoas>("contatos");


            //Console.WriteLine("Inserindo pessoa");
            //InserirPessoa(collection);

            //Console.WriteLine("Atualizando Pessoa");
            //AtualizarPessoa(collection);

            //Console.WriteLine("Excluindo");
            //ExcluirPessoa(collection);

            //Console.WriteLine("Listando");
            //ListarPessoas(collection);

            Console.ReadKey();
        }

        private static void ListarPessoas(IMongoCollection<Pessoas> collection)
        {
            //filtro
            var filtro = Builders<Pessoas>.Filter.Empty;
            var pessoas = collection.Find<Pessoas>(filtro).ToList();

            pessoas.ForEach(x =>
            {
                Console.WriteLine(string.Concat( "nome: ", x.Nome , " Telefone: ", x.Telefone , " Email: ", x.Email));
            });
        }

        private static void ExcluirPessoa(IMongoCollection<Pessoas> collection)
        {
            //filtro
            var filtro = Builders<Pessoas>.Filter.Where(x => x.Nome == "lalala");

            collection.DeleteMany(filtro);
        }

        private static void AtualizarPessoa(IMongoCollection<Pessoas> collection)
        {
            //filter.empty vai atualizar toda a lista pessoas no db (Pega todos os objetos)
            var filtro = Builders<Pessoas>.Filter.Empty;

            //set add propriedade
            //unset ira remover a propriedade do db
            //alterar para
            var alterar = Builders<Pessoas>.Update.Set(p => p.Email, "doisdois@trestres.com");

            //updatemany ira alterar todos os objetos do db
            collection.UpdateMany(filtro, alterar);
        }

        private static void InserirPessoa(IMongoCollection<Pessoas> collection)
        {
            Endereco endereco = new Endereco() { Cidade = "Indaial", Estado = "SC" };

            Endereco endereco2 = new Endereco() { Cidade = "Blumenau", Estado = "SC" };

            List<Endereco> enderecosPessoas = new List<Endereco>();

            enderecosPessoas.Add(endereco);
            enderecosPessoas.Add(endereco2);

            Pessoas pessoa = new Pessoas() { Nome = "lalala", Telefone = "64546454", Email = "lalala@lala.com", Enderecos = enderecosPessoas};

            collection.InsertOne(pessoa);
        }


    }

}
