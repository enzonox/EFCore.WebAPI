﻿// <auto-generated />
using System;
using EFCore.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.WebAPI.Migrations
{
    [DbContext(typeof(HeroiContext))]
    [Migration("20200420104054_HeroisBatalhas_Identidade")]
    partial class HeroisBatalhas_Identidade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.WebAPI.Models.Arma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeroiId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeroiId");

                    b.ToTable("Arma");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Batalha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Batalha");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Heroi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Nome")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Heroi");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.HeroiBatalha", b =>
                {
                    b.Property<int>("BatalhaId")
                        .HasColumnType("int");

                    b.Property<int>("HeroiId")
                        .HasColumnType("int");

                    b.HasKey("BatalhaId", "HeroiId");

                    b.HasIndex("HeroiId");

                    b.ToTable("HeroiBatalha");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.IdentidadeSecreta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeroiId")
                        .HasColumnType("int");

                    b.Property<int>("NomeReal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HeroiId")
                        .IsUnique();

                    b.ToTable("IdentidadeSecreta");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Arma", b =>
                {
                    b.HasOne("EFCore.WebAPI.Models.Heroi", "Heroi")
                        .WithMany("Armas")
                        .HasForeignKey("HeroiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.HeroiBatalha", b =>
                {
                    b.HasOne("EFCore.WebAPI.Models.Batalha", "Batalha")
                        .WithMany("HeroiBatalhas")
                        .HasForeignKey("BatalhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.WebAPI.Models.Heroi", "Heroi")
                        .WithMany("HeroisBatalhas")
                        .HasForeignKey("HeroiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.IdentidadeSecreta", b =>
                {
                    b.HasOne("EFCore.WebAPI.Models.Heroi", "Heroi")
                        .WithOne("Identidade")
                        .HasForeignKey("EFCore.WebAPI.Models.IdentidadeSecreta", "HeroiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
