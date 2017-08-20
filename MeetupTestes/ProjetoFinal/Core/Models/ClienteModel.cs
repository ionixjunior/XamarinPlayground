using System;
using SQLite;

namespace Core.Models
{
    public class ClienteModel
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
