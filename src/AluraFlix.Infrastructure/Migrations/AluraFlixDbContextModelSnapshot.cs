﻿// <auto-generated />
using System;
using AluraFlix.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AluraFlix.Infrastructure.Migrations
{
    [DbContext(typeof(AluraFlixDbContext))]
    partial class AluraFlixDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("AluraFlix.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cor = "#FFFFFF",
                            DataCriacao = new DateTimeOffset(new DateTime(2022, 11, 20, 11, 25, 48, 413, DateTimeKind.Unspecified).AddTicks(1856), new TimeSpan(0, -3, 0, 0, 0)),
                            Titulo = "LIVRE"
                        });
                });

            modelBuilder.Entity("AluraFlix.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCriacao = new DateTimeOffset(new DateTime(2022, 11, 20, 11, 25, 48, 413, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, -3, 0, 0, 0)),
                            Email = "firstAdm@gmail.com",
                            Nome = "Administrador",
                            Role = "ADMIN",
                            Senha = "8c5722d24a864a75e1e87e9e9e2926694b2fab0a0be4708984a07af88b1a204db9280ee4760682788428467dcc0a47ab8f6d77500c844a67e0507baaf7987f0a"
                        },
                        new
                        {
                            Id = 2,
                            DataCriacao = new DateTimeOffset(new DateTime(2022, 11, 20, 11, 25, 48, 413, DateTimeKind.Unspecified).AddTicks(2513), new TimeSpan(0, -3, 0, 0, 0)),
                            Email = "user321@gmail.com",
                            Nome = "Usuario",
                            Role = "USER",
                            Senha = "f0eba30fd73259a377087a149274cb51d2c98ac08355faf632c075224887c29298d913169751c21ef10079a4c892ab4b0b47e0d58ebe5a2135f7b493f0f32e0b"
                        });
                });

            modelBuilder.Entity("AluraFlix.Domain.Entities.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1);

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("AluraFlix.Domain.Entities.Video", b =>
                {
                    b.HasOne("AluraFlix.Domain.Entities.Categoria", null)
                        .WithMany("Videos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AluraFlix.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
