using System;

namespace Clientes.Dominio.Entidades
{
    public class Cliente : BaseEntidade
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int Idade { get; set; }
        public int IdProfissao { get; set; }
        public Profissao Profissao { get; set; }
    }
}
