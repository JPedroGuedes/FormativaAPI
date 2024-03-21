﻿// <auto-generated />
using System;
using FormativaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormativaAPI.Migrations
{
    [DbContext(typeof(SistemaBibliotecaDBContex))]
    partial class SistemaBibliotecaDBContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FormativaAPI.Models.AutorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataNascimento")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Autors");
                });

            modelBuilder.Entity("FormativaAPI.Models.AvaliacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly>("DataAvaliacao")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<int>("LivroId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("Pontuacao")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Avaliacaos");
                });

            modelBuilder.Entity("FormativaAPI.Models.EditoraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnoFundacao")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("LivroId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("FormativaAPI.Models.EmprestimoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataDevolucao")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataEmprestimo")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<int>("LivroId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("FormativaAPI.Models.LivroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnoPublicacao")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ISBN")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("FormativaAPI.Models.ReservaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataReserva")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<int>("LivroId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("FormativaAPI.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FormativaAPI.Models.AvaliacaoModel", b =>
                {
                    b.HasOne("FormativaAPI.Models.LivroModel", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormativaAPI.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FormativaAPI.Models.EditoraModel", b =>
                {
                    b.HasOne("FormativaAPI.Models.LivroModel", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("FormativaAPI.Models.EmprestimoModel", b =>
                {
                    b.HasOne("FormativaAPI.Models.LivroModel", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormativaAPI.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FormativaAPI.Models.ReservaModel", b =>
                {
                    b.HasOne("FormativaAPI.Models.LivroModel", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormativaAPI.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
