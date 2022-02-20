using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Clientes.Infra.Data.Contexto
{
    public class SQlServerContextoFactory : IDesignTimeDbContextFactory<SqlServerContexto>
    {
        SqlServerContexto IDesignTimeDbContextFactory<SqlServerContexto>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlServerContexto>();

            builder.UseSqlServer("Server=localhost;Initial Catalog=Clientes;Trusted_Connection=True;");

            return new SqlServerContexto(builder.Options);
        }
    }
}
