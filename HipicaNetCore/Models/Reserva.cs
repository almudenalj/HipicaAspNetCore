using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipicaNetCore.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int IdNivel { get; set; }
        public int IdCaballo { get; set; }
        public int IdMonitor { get; set; }
        public int IdRuta { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
