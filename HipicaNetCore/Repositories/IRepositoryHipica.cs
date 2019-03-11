using HipicaNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipicaNetCore.Repositories
{
    public interface IRepositoryHipica
    {
        List<Caballo> GetCaballos();
        List<Nivel> GetNiveles();
        List<Monitor> GetMonitores();
        List<Ruta> GetRutas();
        List<Reserva> GetReservas();
        Usuario GetUsuario(string email, string password);
        void RegistrarUsuario(Usuario usuario);
        void RegistrarReserva(Reserva reserva);
    }
}
