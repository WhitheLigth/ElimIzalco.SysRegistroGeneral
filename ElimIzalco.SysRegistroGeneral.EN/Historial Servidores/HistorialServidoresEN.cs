using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Estatus;
using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using ElimIzalco.SysRegistroGeneral.EN.Privilegios;


namespace ElimIzalco.SysRegistroGeneral.EN.Historial_Servidores
{
    public class HistorialServidoresEN
    {
        public int Id { get; set; }
        public MembresiaEN Membresia { get; set; }
        public PrivilegiosEN Privilegio { get; set; }
        public EstatusEN Estatus { get; set; }
    }
}
