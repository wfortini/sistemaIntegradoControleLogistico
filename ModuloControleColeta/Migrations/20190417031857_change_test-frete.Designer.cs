﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModuloControleColeta.Data;

namespace ModuloControleColeta.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20190417031857_change_test-frete")]
    partial class change_testfrete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModuleControleColeta.Models.Solicitacao", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClienteSolicitanteId")
                        .IsRequired();

                    b.Property<string>("DestinoId");

                    b.Property<string>("FreteId");

                    b.Property<string>("Observacao");

                    b.Property<int?>("ParceiroId");

                    b.Property<string>("ProdutoId")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<DateTime>("dataPrevistaEntrega");

                    b.Property<DateTime>("dataSolicitacao");

                    b.HasKey("Id");

                    b.HasIndex("ClienteSolicitanteId");

                    b.HasIndex("DestinoId");

                    b.HasIndex("FreteId");

                    b.HasIndex("ParceiroId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Solicitacao");
                });

            modelBuilder.Entity("ModuloControleColeta.Models.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("RazaoSocial")
                        .IsRequired();

                    b.Property<string>("Teleone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ModuloControleColeta.Models.Destino", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CEP");

                    b.Property<string>("CPFCNPJDestinatatio");

                    b.Property<string>("Cidade");

                    b.Property<string>("Endereco");

                    b.Property<int>("Numero");

                    b.Property<string>("UF");

                    b.HasKey("Id");

                    b.ToTable("Destino");
                });

            modelBuilder.Entity("ModuloControleColeta.Models.Frete", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dataPrevista");

                    b.Property<int>("prazoEntregaDias");

                    b.Property<decimal>("valor");

                    b.HasKey("Id");

                    b.ToTable("Frete");
                });

            modelBuilder.Entity("ModuloControleColeta.Models.Produto", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("nCdEmpresa");

                    b.Property<int>("nCdFormato");

                    b.Property<string>("nCdServico");

                    b.Property<decimal>("nVlAltura");

                    b.Property<decimal>("nVlComprimento");

                    b.Property<decimal>("nVlDiametro");

                    b.Property<decimal>("nVlLargura");

                    b.Property<string>("nVlPeso")
                        .IsRequired();

                    b.Property<decimal>("nVlValorDeclarado");

                    b.Property<string>("sCdAvisoRecebimento")
                        .IsRequired();

                    b.Property<string>("sCdMaoPropria");

                    b.Property<string>("sCepDestino")
                        .IsRequired();

                    b.Property<string>("sCepOrigem")
                        .IsRequired();

                    b.Property<string>("sDsSenha");

                    b.Property<decimal>("valor");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ModuloControleColeta.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPFCNPJ")
                        .IsRequired();

                    b.Property<string>("Login");

                    b.Property<string>("NomeFantasia");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("RazaoSocial")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ModuleControleColeta.Models.Solicitacao", b =>
                {
                    b.HasOne("ModuloControleColeta.Models.Cliente", "ClienteSolicitante")
                        .WithMany()
                        .HasForeignKey("ClienteSolicitanteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ModuloControleColeta.Models.Destino", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoId");

                    b.HasOne("ModuloControleColeta.Models.Frete", "Frete")
                        .WithMany()
                        .HasForeignKey("FreteId");

                    b.HasOne("ModuloControleColeta.Models.Usuario", "Parceiro")
                        .WithMany()
                        .HasForeignKey("ParceiroId");

                    b.HasOne("ModuloControleColeta.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
