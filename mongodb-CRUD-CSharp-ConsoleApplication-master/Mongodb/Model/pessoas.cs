using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mongodb.Model
{
    public class Pessoas
    {
        public ObjectId Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public List<Endereco> Enderecos { get; set; }
    }
}
