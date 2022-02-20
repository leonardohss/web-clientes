using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Clientes.Dominio.Entidades
{
    public class Profissao : BaseEntidade
    {
        public string Descricao { get; set; }
        [JsonIgnore]
        public ICollection<Cliente> Clientes { get; set; }
    }
}
