using Clientes.Dominio.Entidades;

namespace Clientes.Dominio.Interfaces
{
    public interface IClienteRepositorio : IBaseRepositorio<Cliente>
    {
        Cliente SelecionarClientePorId(int id);
    }
}
