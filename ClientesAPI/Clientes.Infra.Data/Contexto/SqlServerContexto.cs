using Microsoft.EntityFrameworkCore;
using Clientes.Dominio.Entidades;
using Clientes.Infra.Data.Mapping;

namespace Clientes.Infra.Data.Contexto
{
    public class SqlServerContexto : DbContext
    {
        public SqlServerContexto(DbContextOptions<SqlServerContexto> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Profissao> Profissao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Profissao>(new ProfissaoMap().Configure);
        }
    }
}
