﻿// <auto-generated />
using System;
using Filmes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Filmes.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241106193154_criandoBancoDeDados")]
    partial class criandoBancoDeDados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Filmes.Models.AtorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datanasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Atores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Datanasc = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Americana",
                            Nome = "Robert",
                            Sobrenome = "Downey Jr."
                        },
                        new
                        {
                            Id = 2,
                            Datanasc = new DateTime(1983, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Americana",
                            Nome = "Christopher",
                            Sobrenome = "Hemsworth"
                        },
                        new
                        {
                            Id = 3,
                            Datanasc = new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Americana",
                            Nome = "Chris",
                            Sobrenome = "Evans"
                        },
                        new
                        {
                            Id = 4,
                            Datanasc = new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Americana",
                            Nome = "Scarlett",
                            Sobrenome = "Johansson"
                        });
                });

            modelBuilder.Entity("Filmes.Models.FilmeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AtorId")
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTrailler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AtorId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Filmes.Models.FilmeModel", b =>
                {
                    b.HasOne("Filmes.Models.AtorModel", "Ator")
                        .WithMany("Filmes")
                        .HasForeignKey("AtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ator");
                });

            modelBuilder.Entity("Filmes.Models.AtorModel", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}