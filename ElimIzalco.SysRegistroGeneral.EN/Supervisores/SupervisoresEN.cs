using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElimIzalco.SysRegistroGeneral.EN.Supervisores
{
    public class SupervisoresEN
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Dui { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
