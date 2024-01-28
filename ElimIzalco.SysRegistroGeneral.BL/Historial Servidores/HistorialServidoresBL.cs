using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.DAL.Historial_Servidores;
using ElimIzalco.SysRegistroGeneral.EN.Historial_Servidores;


namespace ElimIzalco.SysRegistroGeneral.BL.Historial_Servidores
{
    public class HistorialServidoresBL
    {
        // Creamos la Instancia para Acceder a los metodos
        HistorialServidoresDAL ObjHistorialServidor  = new HistorialServidoresDAL();

        // Metodo para Guardar un Nuevo Registro al Historial
        public int GuardarHistorialServidor(HistorialServidoresEN pHistorialGuardar)
        {
            return ObjHistorialServidor.GuardarHistorialServidor(pHistorialGuardar);
        }
    }
}
