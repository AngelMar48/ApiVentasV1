﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace ApiVentasV1.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.27");

            modelBuilder.Entity("Entities.Models.Factura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("FacturaId");

                    b.Property<string>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PersonaId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Facturas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Fecha = "01052024",
                            Monto = "2000",
                            PersonaId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                        },
                        new
                        {
                            Id = new Guid("52a64329-202e-4091-aff0-80230f189cd1"),
                            Fecha = "01052023",
                            Monto = "3000",
                            PersonaId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Fecha = "01012024",
                            Monto = "1000",
                            PersonaId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                        },
                        new
                        {
                            Id = new Guid("119672b6-0119-44f2-8ae7-8e2c0d7b6212"),
                            Fecha = "01012023",
                            Monto = "4000",
                            PersonaId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                        });
                });

            modelBuilder.Entity("Entities.Models.Persona", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("PersonaId");

                    b.Property<string>("ApellidoMaterno")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            ApellidoMaterno = "Cortes",
                            ApellidoPaterno = "Martinez",
                            Identificacion = "987654321",
                            Nombre = "Angel"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            ApellidoMaterno = "Martínez",
                            ApellidoPaterno = "Cortes",
                            Identificacion = "123456789",
                            Nombre = "Isaac"
                        });
                });

            modelBuilder.Entity("Entities.Models.Factura", b =>
                {
                    b.HasOne("Entities.Models.Persona", "Persona")
                        .WithMany("Facturas")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Entities.Models.Persona", b =>
                {
                    b.Navigation("Facturas");
                });
#pragma warning restore 612, 618
        }
    }
}