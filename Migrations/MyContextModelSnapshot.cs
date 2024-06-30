﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperChampiniones.Contexto;

#nullable disable

namespace SuperChampiniones.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("SuperChampiniones.Models.Miembro_Vip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Celular")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ci")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Miembro_Vip");
                });

            modelBuilder.Entity("SuperChampiniones.Models.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EquipoA")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipoB")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Fecha_Hora")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlEscudoA")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlEscudoB")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Partido");
                });

            modelBuilder.Entity("SuperChampiniones.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rol")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SuperChampiniones.Models.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("date");

                    b.Property<int?>("Miembro_VipId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NroRecibo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Sector")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Miembro_VipId");

                    b.HasIndex("PartidoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("SuperChampiniones.Models.Venta", b =>
                {
                    b.HasOne("SuperChampiniones.Models.Miembro_Vip", "Miembro_Vip")
                        .WithMany("Ventas")
                        .HasForeignKey("Miembro_VipId");

                    b.HasOne("SuperChampiniones.Models.Partido", "Partido")
                        .WithMany("Ventas")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperChampiniones.Models.Usuario", "Usuario")
                        .WithMany("Ventas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Miembro_Vip");

                    b.Navigation("Partido");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SuperChampiniones.Models.Miembro_Vip", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("SuperChampiniones.Models.Partido", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("SuperChampiniones.Models.Usuario", b =>
                {
                    b.Navigation("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}
