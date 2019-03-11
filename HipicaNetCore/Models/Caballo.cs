using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HipicaNetCore.Models
{
    public class Caballo
    {        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Id_Nivel { get; set; }
        public string Ruta_Foto { get; set; }
        public string Descripcion { get; set; }
    }
}
