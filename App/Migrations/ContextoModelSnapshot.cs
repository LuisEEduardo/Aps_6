﻿// <auto-generated />
using System;
using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.Models.ContextoDados.Dados", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("NivelInformacao")
                        .HasColumnType("int");

                    b.Property<string>("ProdutoQuimico")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Propriedade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Dados", (string)null);
                });

            modelBuilder.Entity("App.Models.ContextoUsuario.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoPermissao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Usuario", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}