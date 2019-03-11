using HipicaNetCore.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipicaNetCore.Models
{
    public class HipicaContext : DbContext, IHipicaContext
    {

        public HipicaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Caballo> Caballo { get; set; }
        public DbSet<Monitor> Monitor { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Ruta> Ruta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        public void GuardarCambios()
        {
            this.SaveChanges();
        }
    }
}
