using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HipicaNetCore.Data;
using HipicaNetCore.Models;

namespace HipicaNetCore.Repositories
{
    public class RepositoryHipica : IRepositoryHipica
    {
        IHipicaContext context;

        public RepositoryHipica(IHipicaContext context)
        {
            this.context = context;
        }
        public List<Caballo> GetCaballos()
        {
            return this.context.Caballo.ToList();
        }

        public List<Monitor> GetMonitores()
        {
            return this.context.Monitor.ToList();
        }

        public List<Nivel> GetNiveles()
        {
            return this.context.Nivel.ToList();
        }

        public List<Ruta> GetRutas()
        {
            return this.context.Ruta.ToList();
        }

        public Usuario GetUsuario(string email, string password)
        {
            return this.context.Usuario.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public List<Reserva> GetReservas()
        {
            return this.context.Reserva.ToList();
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            this.context.Usuario.Add(usuario);
            this.context.SaveChanges();
        }

        public void RegistrarReserva(Reserva reserva)
        {
            
            this.context.Reserva.Add(reserva);
            this.context.SaveChanges();
        }

    }
}
