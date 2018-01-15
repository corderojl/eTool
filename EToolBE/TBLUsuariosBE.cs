using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EToolBE
{
    public class TBLUsuariosBE
    {
        public int TNumber { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdSector { get; set; }
        public string email { get; set; }
        public int Legajo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Baja { get; set; }
        public string Usergroup { get; set; } 
        public string Sexo { get; set; }
        public int Area { get; set; }
           
    }
}
