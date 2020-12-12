using Microsoft.EntityFrameworkCore;
using Modelos.Registros;
using Modelos.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Shared.Infrastructure.Persistance
{
    public class IPearContext : DbContext
    {
        public DbSet<TelefonoCiudadEnsanblaje> TelefonoCiudadEnsanblajes { get; set; }
        public DbSet<TelefonoGama> TelefonoGamas { get; set; }
        public DbSet<TelefonoColor> TelefonoColores { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Registro> Registros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-8LQEAT9U\\UDEO;database=IPear;Trusted_Connection=true;");
        }
    }
}
