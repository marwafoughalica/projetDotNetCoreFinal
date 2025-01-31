﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mini_ProjetDonetCore.Models;

#nullable disable

namespace Mini_ProjetDonetCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240619195750_three")]
    partial class three
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mini_ProjetDonetCore.Models.Client", b =>
                {
                    b.Property<int>("IdCl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCl"));

                    b.Property<string>("adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCl");

                    b.ToTable("client");
                });

            modelBuilder.Entity("Mini_ProjetDonetCore.Models.Location", b =>
                {
                    b.Property<int>("IdLoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLoc"));

                    b.Property<int>("VoitureIdVoi")
                        .HasColumnType("int");

                    b.Property<int>("clientIdCl")
                        .HasColumnType("int");

                    b.Property<string>("dateLoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dateRetour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLoc");

                    b.HasIndex("VoitureIdVoi");

                    b.HasIndex("clientIdCl");

                    b.ToTable("location");
                });

            modelBuilder.Entity("Mini_ProjetDonetCore.Models.Voiture", b =>
                {
                    b.Property<int>("IdVoi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVoi"));

                    b.Property<string>("couleur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_sortie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("matricule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVoi");

                    b.ToTable("voiture");
                });

            modelBuilder.Entity("Mini_ProjetDonetCore.Models.Location", b =>
                {
                    b.HasOne("Mini_ProjetDonetCore.Models.Voiture", "Voiture")
                        .WithMany("Locations")
                        .HasForeignKey("VoitureIdVoi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mini_ProjetDonetCore.Models.Client", "client")
                        .WithMany("Locations")
                        .HasForeignKey("clientIdCl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voiture");

                    b.Navigation("client");
                });

            modelBuilder.Entity("Mini_ProjetDonetCore.Models.Client", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Mini_ProjetDonetCore.Models.Voiture", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
