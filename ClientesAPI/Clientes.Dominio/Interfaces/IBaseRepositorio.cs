using Clientes.Dominio.Entidades;
using System.Collections.Generic;

namespace Clientes.Dominio.Interfaces
{
    public interface IBaseRepositorio<TEntidade> where TEntidade : BaseEntidade
    {
        void Inserir(TEntidade objeto);
        void Atualizar(TEntidade objeto);
        void DeletarPorId(int id);
        IList<TEntidade> Listar();
        TEntidade SelecionarPorId(int id);
    }
}
