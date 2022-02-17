using System.Collections.Generic;

namespace Clientes.Dominio.Entidades
{
    public class Profissao : BaseEntidade
    {
        public string Descricao { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
