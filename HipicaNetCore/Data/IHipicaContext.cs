using HipicaNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipicaNetCore.Data
{
    public interface  IHipicaContext
    {
        DbSet<Caballo> Caballo { get; set; }
        DbSet<Monitor> Monitor { get; set; }
        DbSet<Nivel> Nivel { get; set; }
        DbSet<Ruta> Ruta { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<Reserva> Reserva { get; set; }

        int SaveChanges();

        void GuardarCambios();
    }
}
