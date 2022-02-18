using Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Infra.Data.Mapping
{
    public class ProfissaoMap : IEntityTypeConfiguration<Profissao>
    {
        public void Configure(EntityTypeBuilder<Profissao> builder)
        {
            builder.ToTable("Profissao");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Descricao)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnType("varchar(50)");

        }
    }
}
