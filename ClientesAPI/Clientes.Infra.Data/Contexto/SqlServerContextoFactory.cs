using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
