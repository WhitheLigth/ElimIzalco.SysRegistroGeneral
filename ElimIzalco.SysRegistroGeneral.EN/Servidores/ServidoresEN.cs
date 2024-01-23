using ElimIzalco.SysRegistroGeneral.EN.Estatus;
using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using ElimIzalco.SysRegistroGeneral.EN.Privilegios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO


namespace ElimIzalco.SysRegistroGeneral.EN.Servidores
{
    public class ServidoresEN
    {
        public int Id { get; set; }
        public MembresiaEN Membresia { get; set; }
        public PrivilegiosEN Privilegio { get; set; }
        public EstatusEN Estatus { get; set; }
    }
}
