﻿// <auto-generated />
using System;
using Clientes.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clientes.Infra.Data.Migrations
{
    [DbContext(typeof(SqlServerContexto))]
    [Migration("20220218112649_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clientes.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("DataDeNascimento")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdProfissao")
                        .HasColumnType("int");

                    b.Property<byte>("Idade")
                        .HasColumnType("tinyint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdProfissao");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Clientes.Dominio.Entidades.Profissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Profissao");
                });

            modelBuilder.Entity("Clientes.Dominio.Entidades.Cliente", b =>
                {
                    b.HasOne("Clientes.Dominio.Entidades.Profissao", "Profissao")
                        .WithMany("Clientes")
                        .HasForeignKey("IdProfissao")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Profissao");
                });

            modelBuilder.Entity("Clientes.Dominio.Entidades.Profissao", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}