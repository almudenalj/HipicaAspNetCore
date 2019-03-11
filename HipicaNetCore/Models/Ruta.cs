using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipicaNetCore.Models
{
    public class Ruta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        public decimal Precio { get; set; }
        public int Id_Nivel { get; set; }
        public string Descripcion { get; set; }
        public string Ruta_Imagen { get; set; }
    }
}
