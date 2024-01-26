using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Supervisores;
using ElimIzalco.SysRegistroGeneral.DAL.Servidores;
using ElimIzalco.SysRegistroGeneral.EN.Servidores;

namespace ElimIzalco.SysRegistroGeneral.BL.Servidores
{
    public class ServidoresBL
    {
        // Creamos una Instancia de la Clase SupervisoresDAL
        ServidoresDAL ObjServidor = new ServidoresDAL();

        // Metodo para Guardar una Nuevo Servidor
        public int GuardarServidor(ServidoresEN pServidorGuardar)
        {
            return ObjServidor.GuardarServidor(pServidorGuardar);
        }
        // Merodo para Modificar un Servidor Existente
        public int ModificarServidor(ServidoresEN pServidorModificar)
        {
            return ObjServidor.ModificarServidor(pServidorModificar);
        }
        // Metodo para Eliminar un Servidor Existente
        public int EliminarServidor(ServidoresEN pServidorEliminar)
        {
            return ObjServidor.EliminarServidor(pServidorEliminar);
        }
        // Metodo Para Validar la Existencia del Servidor
        public int ValidarExistenciaServidor(ServidoresEN pServidorValidar)
        {
            return ObjServidor.ValidarExistenciaServidor(pServidorValidar);
        }
        // Metodo para Obtener todos los Servidores
        public List<ServidoresEN> ObtenerServidores()
        {
            return ObjServidor.ObtenerServidores();
        }
    }
}
