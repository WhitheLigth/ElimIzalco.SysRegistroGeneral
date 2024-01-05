using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Zona;

namespace ElimIzalco.SysRegistroGeneral.BL.Zona
{
    public class ZonaBL
    {
        // Creamos una Instancia de la clase ZonaDAL
        ZonaDAL ObjZonaDAL = new ZonaDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datoss
        public List<ZonaEN> ObtenerZona()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjZonaDAL.ObtenerZona();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public ZonaEN ObtenerZonaPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjZonaDAL.ObtenerZonaPorId(pId);
        }
    }
}
