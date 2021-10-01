﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Servicio.Datos.Context;

namespace Servicio.Datos.Migrations.Npgsql
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211001155221_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Servicio.Entidad.Models.Comun.Institucion", b =>
                {
                    b.Property<int>("cod_institucion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("character varying(550)");

                    b.Property<string>("siglas")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("cod_institucion");

                    b.ToTable("Institucion", "Comun");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Comun.Sucursales", b =>
                {
                    b.Property<int>("cod_sucursal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("cod_institucion")
                        .HasColumnType("integer");

                    b.Property<string>("sucursal")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("character varying(550)");

                    b.HasKey("cod_sucursal");

                    b.HasIndex("cod_institucion");

                    b.ToTable("Sucursales", "Comun");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.Permisos", b =>
                {
                    b.Property<int>("cod_permiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<char>("cod_estado")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasDefaultValue('V');

                    b.Property<int?>("cod_padre_permiso")
                        .HasColumnType("integer");

                    b.Property<string>("icono")
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<int>("orden")
                        .HasColumnType("integer");

                    b.Property<string>("permiso")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("character varying(550)");

                    b.Property<string>("url_permiso")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("cod_permiso");

                    b.ToTable("Permisos", "Seguridad");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.Roles", b =>
                {
                    b.Property<int>("cod_rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("cod_rol");

                    b.ToTable("Roles", "Seguridad");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.RolesPermisos", b =>
                {
                    b.Property<int>("cod_rol_permiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("cod_rol")
                        .HasColumnType("integer");

                    b.Property<int>("cod_permiso")
                        .HasColumnType("integer");

                    b.HasKey("cod_rol_permiso", "cod_rol", "cod_permiso");

                    b.HasIndex("cod_permiso");

                    b.HasIndex("cod_rol");

                    b.ToTable("RolesPermisos", "Seguridad");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.Usuarios", b =>
                {
                    b.Property<Guid>("cod_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<bool>("esActivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("xcontrasena")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("xusuario")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(true)
                        .HasColumnType("character varying(80)");

                    b.HasKey("cod_usuario");

                    b.ToTable("Usuarios", "Seguridad");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.UsuariosRoles", b =>
                {
                    b.Property<int>("cod_usuario_rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("cod_rol")
                        .HasColumnType("integer");

                    b.Property<Guid>("cod_usuario")
                        .HasColumnType("uuid");

                    b.HasKey("cod_usuario_rol", "cod_rol", "cod_usuario");

                    b.HasIndex("cod_rol");

                    b.HasIndex("cod_usuario");

                    b.ToTable("UsuariosRoles", "Seguridad");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Comun.Sucursales", b =>
                {
                    b.HasOne("Servicio.Entidad.Models.Comun.Institucion", "Institucion")
                        .WithMany("Surcursales")
                        .HasForeignKey("cod_institucion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucion");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.RolesPermisos", b =>
                {
                    b.HasOne("Servicio.Entidad.Models.Seguridad.Permisos", "Permiso")
                        .WithMany("RolesPermisos")
                        .HasForeignKey("cod_permiso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Servicio.Entidad.Models.Seguridad.Roles", "Rol")
                        .WithMany("RolesPermisos")
                        .HasForeignKey("cod_rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.UsuariosRoles", b =>
                {
                    b.HasOne("Servicio.Entidad.Models.Seguridad.Roles", "Rol")
                        .WithMany("UsuariosRoles")
                        .HasForeignKey("cod_rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Servicio.Entidad.Models.Seguridad.Usuarios", "Usuario")
                        .WithMany("UsuariosRoles")
                        .HasForeignKey("cod_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Comun.Institucion", b =>
                {
                    b.Navigation("Surcursales");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.Permisos", b =>
                {
                    b.Navigation("RolesPermisos");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.Roles", b =>
                {
                    b.Navigation("RolesPermisos");

                    b.Navigation("UsuariosRoles");
                });

            modelBuilder.Entity("Servicio.Entidad.Models.Seguridad.Usuarios", b =>
                {
                    b.Navigation("UsuariosRoles");
                });
#pragma warning restore 612, 618
        }
    }
}