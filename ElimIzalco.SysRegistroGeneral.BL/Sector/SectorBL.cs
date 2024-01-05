using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Sector;

namespace ElimIzalco.SysRegistroGeneral.BL.Sector
{
    public class SectorBL
    {
        // Creamos una Instancia de la clase SectorDAL
        SectorDAL ObjSectorDAL = new SectorDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<SectorEN> ObtenerSector()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjSectorDAL.ObtenerSector();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public SectorEN ObtenerSectorPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjSectorDAL.ObtenerSectorPorId(pId);
        }
    }
}
