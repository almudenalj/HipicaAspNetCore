using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipicaNetCore.Models
{
    public class Monitor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruta_Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}
