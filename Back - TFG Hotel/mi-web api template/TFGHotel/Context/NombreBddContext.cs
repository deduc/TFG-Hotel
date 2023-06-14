using Microsoft.EntityFrameworkCore;
using TFGHotel.Entities;

namespace TFGHotel.Context
{
    public class NombreBddContext : DbContext
    {
        /*
         * Estos atributos son objetos base de datos que trabajaran con <NOMBRE_TABLA> NombreClase
         * y permiten lanzar consultas sql a la BDD
         */
        //public DbSet<Entities/Entidad1> Usuarios { get; set; }

        public NombreBddContext(DbContextOptions options) : base(options) { }

        public NombreBddContext(){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity< Entities / Entidad1 > ()
            //    .HasKey(columna => new { columna.Id_Usuario });
        }
    }
}

