using Clientes.Dominio.Entidades;
using Clientes.Dominio.Interfaces;
using Clientes.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Clientes.Infra.Data.Repositorio
{
    public class ClienteRepositorio : BaseRepositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(SqlServerContexto sqlServerContexto) : base(sqlServerContexto)
        {
        }

        public Cliente SelecionarClientePorId(int id)
        {
            var item = _sqlServerContexto.Cliente.IgnoreAutoIncludes()
                .Include(x => x.Profissao)
                .Where(x => x.Id == id).FirstOrDefault();
            return item;
        }
    }
}
