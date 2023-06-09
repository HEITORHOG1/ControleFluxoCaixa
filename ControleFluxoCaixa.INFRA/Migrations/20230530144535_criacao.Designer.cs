﻿// <auto-generated />
using System;
using ControleFluxoCaixa.INFRA.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleFluxoCaixa.INFRA.Migrations
{
    [DbContext(typeof(FluxoContext))]
    [Migration("20230530144535_criacao")]
    partial class criacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControleFluxoCaixa.DOMAIN.Model.Lancamento", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("RelatorioId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("RelatorioId");

                    b.ToTable("Lancamento", (string)null);
                });

            modelBuilder.Entity("ControleFluxoCaixa.DOMAIN.Model.Relatorio", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("SaldoAtual")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("TotalCreditos")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("TotalDebitos")
                        .HasMaxLength(50)
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Relatorio", (string)null);
                });

            modelBuilder.Entity("ControleFluxoCaixa.DOMAIN.Model.Lancamento", b =>
                {
                    b.HasOne("ControleFluxoCaixa.DOMAIN.Model.Relatorio", null)
                        .WithMany("Lancamentos")
                        .HasForeignKey("RelatorioId");
                });

            modelBuilder.Entity("ControleFluxoCaixa.DOMAIN.Model.Relatorio", b =>
                {
                    b.Navigation("Lancamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
