﻿// <auto-generated />
using System;
using CaixaEletronico.Dominio.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaixaEletronico.Dominio.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210206000105_CriarBase")]
    partial class CriarBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CaixaEletronico.Dominio.Entidades.Cartao", b =>
                {
                    b.Property<int>("CartaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cvc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Limite")
                        .HasColumnType("float");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCartao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.HasKey("CartaoId");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("CaixaEletronico.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CaixaEletronico.Dominio.Entidades.Comprovante", b =>
                {
                    b.Property<int>("ComprovanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Validacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("ComprovanteId");

                    b.ToTable("Comprovantes");
                });

            modelBuilder.Entity("CaixaEletronico.Dominio.Entidades.Conta", b =>
                {
                    b.Property<int>("ContaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CartaoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroConta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContaId");

                    b.HasIndex("CartaoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("CaixaEletronico.Dominio.Entidades.Conta", b =>
                {
                    b.HasOne("CaixaEletronico.Dominio.Entidades.Cartao", "Cartao")
                        .WithMany()
                        .HasForeignKey("CartaoId");

                    b.HasOne("CaixaEletronico.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartao");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
