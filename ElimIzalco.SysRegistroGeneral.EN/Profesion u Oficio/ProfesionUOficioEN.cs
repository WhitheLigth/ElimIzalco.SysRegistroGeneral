using ElimIzalco.SysRegistroGeneral.EN.Categoria_Para_Profesion_u_Oficio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElimIzalco.SysRegistroGeneral.EN.Profesion_u_Oficio
{
    public class ProfesionUOficioEN
    {
        public int Id {  get; set; }
        public string Nombre {  get; set; }
        public CategoriaParaProfesionUOficioEN Categoria { get; set; }
    }
}
