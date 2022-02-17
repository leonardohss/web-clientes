using System;

namespace Clientes.App.Dtos
{
    public class ClienteDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public byte Idade { get; set; }
        public int IdProfissao { get; set; }
    }
}
