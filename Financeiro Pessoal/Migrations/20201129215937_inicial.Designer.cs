﻿// <auto-generated />
using System;
using Financeiro_Pessoal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Financeiro_Pessoal.Migrations
{
    [DbContext(typeof(AppDb))]
    [Migration("20201129215937_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("Financeiro_Pessoal.Models.Categoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<bool>("Despesa")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Receita")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Financeiro_Pessoal.Models.Financeiro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Despesa")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IndividuoID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Receita")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sequencia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SequenciaID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("IndividuoID");

                    b.ToTable("Financeiro");
                });

            modelBuilder.Entity("Financeiro_Pessoal.Models.Individuo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<string>("Observacoes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(120);

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT")
                        .HasMaxLength(16);

                    b.HasKey("ID");

                    b.ToTable("Individuos");
                });

            modelBuilder.Entity("Financeiro_Pessoal.Models.Recibo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataBaixa")
                        .HasColumnType("TEXT");

                    b.Property<int>("FinanceiroID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("FinanceiroID");

                    b.ToTable("Recibos");
                });

            modelBuilder.Entity("Financeiro_Pessoal.Models.Financeiro", b =>
                {
                    b.HasOne("Financeiro_Pessoal.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Financeiro_Pessoal.Models.Individuo", "Individuo")
                        .WithMany()
                        .HasForeignKey("IndividuoID");
                });

            modelBuilder.Entity("Financeiro_Pessoal.Models.Recibo", b =>
                {
                    b.HasOne("Financeiro_Pessoal.Models.Financeiro", "Financeiro")
                        .WithMany("Recibos")
                        .HasForeignKey("FinanceiroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
