using Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Infra.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(prop => prop.Sobrenome)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Cpf)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(prop => prop.DataDeNascimento)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Idade)
                .IsRequired()
                .HasColumnType("tinyint");

            builder.HasOne(prop => prop.Profissao)
                .WithMany(prop => prop.Clientes)
                .HasForeignKey(prop => prop.IdProfissao)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
