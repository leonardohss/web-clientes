using Clientes.Dominio.Entidades;
using Clientes.Dominio.Interfaces;
using Clientes.Infra.Data.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.Infra.Data.Repositorio
{
    public class BaseRepositorio<TEntidade> : IBaseRepositorio<TEntidade> where TEntidade : BaseEntidade
    {
        protected readonly SqlServerContexto _sqlServerContexto;

        public BaseRepositorio(SqlServerContexto sqlServerContexto)
        {
            _sqlServerContexto = sqlServerContexto;
        }

        public void Inserir(TEntidade objeto)
        {
            _sqlServerContexto.Set<TEntidade>().Add(objeto);
            _sqlServerContexto.SaveChanges();
        }

        public void Atualizar(TEntidade objeto)
        {
            _sqlServerContexto.Entry(objeto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlServerContexto.SaveChanges();
        }

        public void DeletarPorId(int id)
        {
            _sqlServerContexto.Set<TEntidade>().Remove(SelecionarPorId(id));
            _sqlServerContexto.SaveChanges();
        }

        public IList<TEntidade> Listar() =>
            _sqlServerContexto.Set<TEntidade>().ToList();

        public TEntidade SelecionarPorId(int id) =>
            _sqlServerContexto.Set<TEntidade>().Find(id);
    }
}
