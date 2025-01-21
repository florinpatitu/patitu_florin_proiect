﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using patitu_florin_proiect.Modele;

#nullable disable

namespace patitu_florin_proiect.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250121150420_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("patitu_florin_proiect.Modele.Mecanic", b =>
                {
                    b.Property<int>("MecanicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MecanicID"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MecanicID");

                    b.ToTable("Mecanici");
                });

            modelBuilder.Entity("patitu_florin_proiect.Modele.Piesa", b =>
                {
                    b.Property<int>("PiesaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PiesaID"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PiesaID");

                    b.ToTable("Piese");
                });

            modelBuilder.Entity("patitu_florin_proiect.Modele.SarcinaService", b =>
                {
                    b.Property<int>("SarcinaServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SarcinaServiceID"));

                    b.Property<DateTime>("DataProgramare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MecanicID")
                        .HasColumnType("int");

                    b.Property<int?>("PiesaID")
                        .HasColumnType("int");

                    b.Property<int>("VehiculID")
                        .HasColumnType("int");

                    b.HasKey("SarcinaServiceID");

                    b.HasIndex("MecanicID");

                    b.HasIndex("PiesaID");

                    b.HasIndex("VehiculID");

                    b.ToTable("SarciniService");
                });

            modelBuilder.Entity("patitu_florin_proiect.Modele.Vehicul", b =>
                {
                    b.Property<int>("VehiculID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehiculID"));

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarInmatriculare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehiculID");

                    b.ToTable("Vehicule");
                });

            modelBuilder.Entity("patitu_florin_proiect.Modele.SarcinaService", b =>
                {
                    b.HasOne("patitu_florin_proiect.Modele.Mecanic", "Mecanic")
                        .WithMany("SarciniService")
                        .HasForeignKey("MecanicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("patitu_florin_proiect.Modele.Piesa", null)
                        .WithMany("SarciniService")
                        .HasForeignKey("PiesaID");

                    b.HasOne("patitu_florin_proiect.Modele.Vehicul", "Vehicul")
                        .WithMany("SarciniService")
                        .HasForeignKey("VehiculID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mecanic");

                    b.Navigation("Vehicul");
                });

            modelBuilder.Entity("patitu_florin_proiect.Modele.Mecanic", b =>
                {
                    b.Navigation("SarciniService");
                });

            modelBuilder.Entity("patitu_florin_proiect.Modele.Piesa", b =>
                {
                    b.Navigation("SarciniService");
                });

            modelBuilder.Entity("patitu_florin_proiect.Modele.Vehicul", b =>
                {
                    b.Navigation("SarciniService");
                });
#pragma warning restore 612, 618
        }
    }
}
