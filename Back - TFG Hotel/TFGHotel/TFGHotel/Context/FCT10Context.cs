﻿using Microsoft.EntityFrameworkCore;
using TFGHotel.Entities;

namespace TFGHotel.Context
{
    public class FCT10Context : DbContext
    {
        /*
         * Estos atributos son objetos base de datos que trabajaran con <NOMBRE_TABLA> NombreClase
         * y permiten lanzar consultas sql a la BDD
         * 
         * !!!! IMPORTANTE ¡¡¡¡
         * LOS NOMBRES DE LOS ATRIBUTOS HAN DE LLAMARSE SÍ O SÍ IGUAL QUE EN LA BASE DE DATOS
         */
        public DbSet<USUARIOS> Usuarios { get; set; }
        public DbSet<CLIENTES> Clientes { get; set; }
        public DbSet<RESERVAS_DE_HABITACIONES> Reservas_De_Habitaciones { get; set; }
        public DbSet<RESERVAS_DE_SERVICIOS> Reservas_De_Servicios { get; set; }
        public DbSet<TIPOS_DE_HABITACIONES> Tipos_De_Habitaciones { get; set; }
        public DbSet<TIPOS_DE_SERVICIOS> Tipos_De_Servicios { get; set; }
        public DbSet<HABITACIONES> Habitaciones { get; set; }
        public DbSet<DATOS_DE_HABITACIONES_DISPONIBLES> Datos_De_Habitaciones_Disponibles { get; set; }
        public DbSet<DATOS_HABITACIONES_TIPOS_FECHAS> Datos_Habitaciones_Tipos_Fechas { get; set; }
        public DbSet<DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES> Datos_Reservas_De_Servicios_Y_Clientes { get; set; }


        public FCT10Context(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Declaro las PK de las tablas|entidades declaradas

            modelBuilder.Entity<USUARIOS>()
                .HasKey(columna => new { columna.ID_USUARIO });

            modelBuilder.Entity<CLIENTES>()
                .HasKey(columna => new { columna.ID_CLIENTE });

            modelBuilder.Entity<RESERVAS_DE_HABITACIONES>()
                .HasKey(columna => new { columna.ID_RESERVA_HABITACION });

            modelBuilder.Entity<RESERVAS_DE_SERVICIOS>()
                //.HasKey(columna => new { columna.Id_Reserva, columna.Id_Cliente, columna.Id_Servicio });
                .HasKey(columna => new { columna.ID_RESERVA_SERVICIO });

            modelBuilder.Entity<TIPOS_DE_HABITACIONES>()
                .HasKey(columna => new { columna.ID_TIPO_DE_HABITACION });

            modelBuilder.Entity<TIPOS_DE_SERVICIOS>()
                .HasKey(columna => new { columna.ID_SERVICIO });

            modelBuilder.Entity<HABITACIONES>()
                .HasKey(columna => new { columna.ID_HABITACION });
            
            modelBuilder.Entity<DATOS_DE_HABITACIONES_DISPONIBLES>()
                .HasKey(columna => new { columna.ID_TIPO_DE_HABITACION });
            
            modelBuilder.Entity<DATOS_HABITACIONES_TIPOS_FECHAS>()
                .HasKey(columna => new { columna.ID_HABITACION });

            modelBuilder.Entity<DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES>()
                .HasKey(columna => new { columna.ID_RESERVA_SERVICIO });

            // fin metodo OnModelCreating
        }

        // fin clase
    }

    // fin namespace
}

